using UnityEngine;

namespace BrowserGame2D
{
    public class CharacterModel
    {
        public SpriteAnimationsConfig configCharacterSpriteAnimations;

        public Track startTrack = Track.sonic_idle;

        public float speedAnimation = 10f;

        public bool loopAnimation = true;
        public CharacterModel()
        {
            configCharacterSpriteAnimations = Resources.Load<SpriteAnimationsConfig>("CharacterSpriteAnimationsConfig");
        }
    }
}
