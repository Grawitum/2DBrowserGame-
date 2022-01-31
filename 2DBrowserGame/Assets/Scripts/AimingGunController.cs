using UnityEngine;

namespace BrowserGame2D
{
    public class AimingGunController
    {
        Transform _gunTransform;
        Transform _characterTransform;

        public AimingGunController(Transform gunTransform, Transform characterTransform)
        {
            _gunTransform = gunTransform;
            _characterTransform = characterTransform;
        }

        public void Update()
        {
            var dir = _characterTransform.position - _gunTransform.position;
            var angle = Vector3.Angle(Vector3.down, dir);
            var axis = Vector3.Cross(Vector3.down, dir);
            _gunTransform.rotation = Quaternion.AngleAxis(angle, axis);
        }
    }
}
