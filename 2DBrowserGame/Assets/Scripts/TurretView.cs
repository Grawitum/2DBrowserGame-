using System.Collections.Generic;
using UnityEngine;

namespace BrowserGame2D
{
    public class TurretView : LevelObjectView
    {
        public Transform GunTransform;

        public List<BulletView> bulletViews;
    }
}
