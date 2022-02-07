using UnityEngine;

namespace BrowserGame2D
{
    public class CharacterController
    {
        private SpriteAnimator _spriteAnimatorCharacter;
        private CharacterModel _characterModel;
        private CharacterWalkerController _characterWalker;
        private CharacterView _characterView;

        public CharacterController(CharacterView characterView)
        {
            _characterView = characterView;
            _characterModel = new CharacterModel();
            _spriteAnimatorCharacter = new SpriteAnimator(_characterModel.configCharacterSpriteAnimations);
            _spriteAnimatorCharacter.StartAnimation(_characterView.SpriteRenderer, _characterModel.startTrack, _characterModel.loopAnimation, _characterModel.speedAnimation);

            _characterWalker = new CharacterWalkerController(_characterView,_spriteAnimatorCharacter,_characterModel);
        }

        public void Update()
        {
            _characterModel.doJump = Input.GetAxis("Vertical") > 0;
            _characterModel.xAxisInput = Input.GetAxis("Horizontal");
            //_characterWalker.Update();
            _spriteAnimatorCharacter.Update();
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _characterWalker.FixedUpdate(fixedDeltaTime);
        }
    }
}
