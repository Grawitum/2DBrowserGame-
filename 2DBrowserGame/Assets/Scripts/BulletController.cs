using UnityEngine;

namespace BrowserGame2D
{
    public class BulletController 
    {
        private BulletView _view;
        private BulletModel _bulletModel;

        public BulletController(BulletView view)
        {
            _view = view;
            _bulletModel = new BulletModel();
            _view.SetVisible(false);
        }

        public void Update()
        {
            if (IsGrounded())
            {
                SetVelocity(_bulletModel.velocity.Change(y: -_bulletModel.velocity.y * _bulletModel.velocityDownImpuls));
                _view.gameObject.transform.position = _view.gameObject.transform.position.Change(y: _bulletModel.groundLevel + _bulletModel.radius);
            }
            else
            {
                SetVelocity(_bulletModel.velocity + Vector3.up * _bulletModel.g * Time.deltaTime);
                _view.gameObject.transform.position += _bulletModel.velocity * Time.deltaTime;
            }
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _view.gameObject.transform.position = position;
            SetVelocity(velocity);
            _view.SetVisible(true);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _bulletModel.velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _bulletModel.velocity);
            var axis = Vector3.Cross(Vector3.left, _bulletModel.velocity);
            _view.gameObject.transform.rotation = Quaternion.AngleAxis(angle, axis);

        }

        private bool IsGrounded()
        {
            return _view.gameObject.transform.position.y <= _bulletModel.groundLevel + _bulletModel.radius + float.Epsilon && _bulletModel.velocity.y <= 0;
        }

    }
}
