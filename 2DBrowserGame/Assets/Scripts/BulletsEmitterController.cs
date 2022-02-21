using System.Collections.Generic;
using UnityEngine;

namespace BrowserGame2D
{
    public class BulletsEmitterController 
    {
        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transform;

        private int _currentIndex;
        private float _timeTillNextBullet;

        private BulletsEmitterModel _bulletsEmitterModel;

        public BulletsEmitterController(List<BulletView> bulletViews, Transform transform)
        {
            _bulletsEmitterModel = new BulletsEmitterModel();
            _timeTillNextBullet = _bulletsEmitterModel.delay;
            _transform = transform;
            foreach (var bulletView in bulletViews)
            {
                _bullets.Add(new BulletController(bulletView));
            }
        }

        public void Update(float deltaTime)
        {
            if (_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= deltaTime;
            }
            else
            {
                _timeTillNextBullet = _bulletsEmitterModel.delay;
                _bullets[_currentIndex].Throw(_transform.position, -_transform.up * _bulletsEmitterModel.startSpeed);
                _currentIndex++;
                if (_currentIndex >= _bullets.Count) _currentIndex = 0;
            }
            _bullets.ForEach(bullet => bullet.Update());
        }
    }
}
