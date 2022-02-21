namespace BrowserGame2D
{
    public class EnimyController
    {
        private SpriteAnimator _spriteAnimatorEnimy;
        private EnimyModel _enimyModel;
        private LevelObjectView _view;
        public EnimyController(EnimyView enimyView)
        {
            _view = enimyView;
            _enimyModel = new EnimyModel();
            _spriteAnimatorEnimy = new SpriteAnimator(_enimyModel.configCharacterSpriteAnimations);
            _spriteAnimatorEnimy.StartAnimation(enimyView.SpriteRenderer, _enimyModel.startTrack,_enimyModel.loopAnimation, _enimyModel.speedAnimation);
        }

        public void Update(float deltaTime)
        {
            _spriteAnimatorEnimy.Update(deltaTime);
        }

        public void FixedUpdate()
        {
            _view.SpriteRenderer.flipX = _view.Rigidbody2D.velocity.x > 0 ? false : true;

            if (_view.Rigidbody2D.velocity.x != 0)
                _spriteAnimatorEnimy.StartAnimation(_view.SpriteRenderer, Track.sonic_walk, _enimyModel.loopAnimation, _enimyModel.speedAnimation); 
            else
                _spriteAnimatorEnimy.StartAnimation(_view.SpriteRenderer, _enimyModel.startTrack, _enimyModel.loopAnimation, _enimyModel.speedAnimation);
        }
    }
}
