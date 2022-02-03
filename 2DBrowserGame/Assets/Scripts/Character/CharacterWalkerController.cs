using UnityEngine;

namespace BrowserGame2D
{
    public class CharacterWalkerController
    {
        private const string _verticalAxisName = "Vertical";
        private const string _horizontalAxisName = "Horizontal";


        private CharacterView _view;
        private SpriteAnimator _spriteAnimator;
        private CharacterModel _characterModel;

        private readonly ContactsPoller _contactsPoller;

        public CharacterWalkerController(CharacterView view, SpriteAnimator spriteAnimator, CharacterModel model)
        {
            _view = view;
            _spriteAnimator = spriteAnimator;
            _characterModel = model;

            _contactsPoller = new ContactsPoller(_view.Collider2D);
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
                    _spriteAnimator.StartAnimation(_view.SpriteRenderer, Track.sonic_jump_up, true, _characterModel.speedAnimation);
                }
                _characterModel.yVelocity += _characterModel.g * Time.deltaTime;
                _view.gameObject.transform.position += Vector3.up * (Time.deltaTime * _characterModel.yVelocity);

                if (_characterModel.yVelocity < 0) _spriteAnimator.StartAnimation(_view.SpriteRenderer, Track.sonic_jump_down, true, _characterModel.speedAnimation);
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _characterModel.doJump = Input.GetAxis(_verticalAxisName) > 0;
            _characterModel.goSideWay = Input.GetAxis(_horizontalAxisName);
            _contactsPoller.Update();

            var walks = Mathf.Abs(_characterModel.goSideWay) > _characterModel.movingThresh;

            if (walks) _view.SpriteRenderer.flipX = _characterModel.goSideWay < 0;
            var newVelocity = 0f;
            if (walks &&
                (_characterModel.goSideWay > 0 || !_contactsPoller.HasLeftContacts) &&
                (_characterModel.goSideWay < 0 || !_contactsPoller.HasRightContacts))
            {
                newVelocity = fixedDeltaTime * _characterModel.walkSpeed *
                   (_characterModel.goSideWay < 0 ? -1 : 1);
            }
            _view.Rigidbody2D.velocity = _view.Rigidbody2D.velocity.Change(
                 x: newVelocity);
            if (_contactsPoller.IsGrounded && _characterModel.doJump &&
                  Mathf.Abs(_view.Rigidbody2D.velocity.y) <= _characterModel.jumpThresh)
            {
                _view.Rigidbody2D.AddForce(Vector3.up * _characterModel.jumpForse);
            }

            //animations
            if (_contactsPoller.IsGrounded)
            {
                var track = walks ? Track.sonic_walk : Track.sonic_idle;
                _spriteAnimator.StartAnimation(_view.SpriteRenderer, track, true,
                    _characterModel.speedAnimation);
            }
            else if (Mathf.Abs(_view.Rigidbody2D.velocity.y) > _characterModel.flyThresh)
            {
                var track = Track.sonic_jump_up;
                _spriteAnimator.StartAnimation(_view.SpriteRenderer, track, true,
                    _characterModel.speedAnimation);
                if (_view.Rigidbody2D.velocity.y < 0) _spriteAnimator.StartAnimation(_view.SpriteRenderer, Track.sonic_jump_down, true, _characterModel.speedAnimation);
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
