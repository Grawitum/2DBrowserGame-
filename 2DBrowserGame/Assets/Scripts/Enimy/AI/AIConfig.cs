using System;
using UnityEngine;

namespace BrowserGame2D
{
    [Serializable]
    public struct AIConfig
    {
        public float speed;
        public float minDistanceToTarget;
        public Transform[] waypoints;
    }
}

