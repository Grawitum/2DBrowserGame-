using UnityEngine;
namespace BrowserGame2D
{
    public class CharacterWalker
    {

        private CharacterView _view;
        private SpriteAnimator _spriteAnimator;
        private CharacterModel _characterModel;

        public CharacterWalker(CharacterView view, SpriteAnimator spriteAnimator, CharacterModel model)
        {
            _view = view;
            _spriteAnimator = spriteAnimator;
            _characterModel = model;
        }

        public void Update()
        {
            _characterModel.doJump = Input.GetAxis("Vertical") > 0;
            _characterModel.xAxisInput = Input.GetAxis("Horizontal");
            var goSideWay = Mathf.Abs(_characterModel.xAxisInput) > _characterModel.movingThresh;

            if (IsGrounded())
            {
                //walking
                if (goSideWay) GoSideWay();
                _spriteAnimator.StartAnimation(_view.SpriteRenderer, goSideWay ? Track.sonic_walk : Track.sonic_idle, true, _characterModel.speedAnimation);

                //start jump
                if (_characterModel.doJump && _characterModel.yVelocity == 0)
                {
                    _characterModel.yVelocity = _characterModel.jumpStartSpeed;
                }
                //stop jump
                else if (_characterModel.yVelocity < 0)
                {
                    _characterModel.yVelocity = 0;
                    _view.gameObject.transform.position = _view.gameObject.transform.position.Change(y: _characterModel.groundLevel);
                }
            }
            else
            {
                //flying
                if (goSideWay) GoSideWay();
                if (Mathf.Abs(_characterModel.yVelocity) > _characterModel.flyThresh)
                {
                    _spriteAnimator.StartAnimation(_view.SpriteRenderer, Track.sonic_jump, true, _characterModel.speedAnimation);
                }
                _characterModel.yVelocity += _characterModel.g * Time.deltaTime;
                _view.gameObject.transform.position += Vector3.up * (Time.deltaTime * _characterModel.yVelocity);
            }
        }

        private void GoSideWay()
        {
            _view.gameObject.transform.position += Vector3.right * (Time.deltaTime * _characterModel.walkSpeed * (_characterModel.xAxisInput < 0 ? -1 : 1));
            _view.gameObject.transform.localScale = (_characterModel.xAxisInput < 0 ? _characterModel.leftScale : _characterModel.rightScale);
        }

        public bool IsGrounded()
        {
            return _view.gameObject.transform.position.y <= _characterModel.groundLevel + float.Epsilon && _characterModel.yVelocity <= 0;
        }



    }
}
