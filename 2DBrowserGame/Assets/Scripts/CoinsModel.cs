using UnityEngine;

namespace BrowserGame2D
{
    public class CoinsModel
    {
        public SpriteAnimationsConfig configCharacterSpriteAnimations;

        public Track startTrack = Track.coin_rotation;

        public int colectCoins = 0;

        public CoinsModel()
        {
            configCharacterSpriteAnimations = Resources.Load<SpriteAnimationsConfig>("CoinSpriteAnimationsConfig");
        }
    }
}
