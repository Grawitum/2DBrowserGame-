using UnityEngine;

namespace BrowserGame2D
{
    public class EnimyModel
    {
        public SpriteAnimationsConfig configCharacterSpriteAnimations;

        public Track startTrack = Track.sonic_idle;

        public float speedAnimation = 10f;

        public bool loopAnimation = true;
        public EnimyModel()
        {
            configCharacterSpriteAnimations = Resources.Load<SpriteAnimationsConfig>("EnimySpriteAnimationsConfig");
        }
    }
}
