using UnityEngine;

namespace BrowserGame2D
{
    public class CharacterController
    {
        private SpriteAnimator _spriteAnimatorCharacter;
        private CharacterModel _characterModel;

        public CharacterController(SpriteRenderer characterView)
        {
            _characterModel = new CharacterModel();
            _spriteAnimatorCharacter = new SpriteAnimator(_characterModel.configCharacterSpriteAnimations);
            _spriteAnimatorCharacter.StartAnimation(characterView, _characterModel.startTrack, _characterModel.loopAnimation, _characterModel.speedAnimation);
        }

        public void Update()
        {
            _spriteAnimatorCharacter.Update();
        }
    }
}
