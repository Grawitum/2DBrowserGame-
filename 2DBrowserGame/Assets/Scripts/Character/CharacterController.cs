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

        public void Update(float deltaTime)
        {
            _characterModel.doJump = Input.GetAxis(AxisManager.VERTICAL) > 0;
            _characterModel.xAxisInput = Input.GetAxis(AxisManager.HORIZONTAL);
            _spriteAnimatorCharacter.Update(deltaTime);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _characterWalker.FixedUpdate(fixedDeltaTime);
        }
    }
}
