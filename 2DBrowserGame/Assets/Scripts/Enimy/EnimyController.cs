using UnityEngine;

namespace BrowserGame2D
{
    public class EnimyController
    {
        private SpriteAnimator _spriteAnimatorEnimy;
        private EnimyModel _enimyModel;
        public EnimyController(EnimyView enimyView)
        {
            _enimyModel = new EnimyModel();
            _spriteAnimatorEnimy = new SpriteAnimator(_enimyModel.configCharacterSpriteAnimations);
            _spriteAnimatorEnimy.StartAnimation(enimyView.SpriteRenderer, _enimyModel.startTrack,_enimyModel.loopAnimation, _enimyModel.speedAnimation);
        }

        public void Update()
        {
            _spriteAnimatorEnimy.Update();
        }
    }
}
