using UnityEngine;

namespace BrowserGame2D
{
    public class BulletModel
    {
        public float radius = 0.3f;
        public Vector3 velocity;
        public float velocityDownImpuls = 0.7f;

        public float groundLevel = 0;
        public float g = -10;
    }
}
