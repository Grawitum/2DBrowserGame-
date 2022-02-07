using UnityEngine;

namespace BrowserGame2D
{
    public class CharacterModel
    {
        public SpriteAnimationsConfig configCharacterSpriteAnimations;

        public Track startTrack = Track.sonic_idle;

        public float speedAnimation = 10f;
        public float jumpStartSpeed = 8f;

        public float jumpForse = 350;
        public float jumpThresh = 0.1f;


        public float movingThresh = 0.1f;
        public float flyThresh = 1f;

        public float g = -10f;

        public bool loopAnimation = true;

        public float xAxisInput = 0;
        public bool doJump = false;

        public float walkSpeed = 150f;

        public float goSideWay = 0;

        public float groundLevel = 0.45f;
        public float yVelocity = 0;

        public Vector3 leftScale = new Vector3(-1, 1, 1);
        public Vector3 rightScale = new Vector3(1, 1, 1);
        public CharacterModel()
        {
            configCharacterSpriteAnimations = Resources.Load<SpriteAnimationsConfig>("CharacterSpriteAnimationsConfig");
        }
    }
}
