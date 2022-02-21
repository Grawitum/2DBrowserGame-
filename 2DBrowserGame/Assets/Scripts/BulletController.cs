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
                _view.SetVisible(false);
            }
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _view.SetVisible(false);
            _view.gameObject.transform.position = position;
            _view.Rigidbody2D.velocity = Vector2.zero;
            _view.Rigidbody2D.angularVelocity = 0;
            _view.Rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
            _view.SetVisible(true);
        }

        private bool IsGrounded()
        {
            return _view.gameObject.transform.position.y <= _bulletModel.groundLevel + _bulletModel.radius + float.Epsilon && _bulletModel.velocity.y <= 0;
        }
    }
}
