using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrowserGame2D
{
    public class CoinsController : IDisposable
    {
        private const float _animationsSpeed = 10;

        private LevelObjectView _characterView;
        private SpriteAnimator _spriteAnimator;
        private List<LevelObjectView> _coinViews;

        private CoinsModel _coinsModel;

        public CoinsController(LevelObjectView characterView, List<LevelObjectView> coinViews)
        {
            _coinsModel = new CoinsModel();
           _characterView = characterView;
            _spriteAnimator = new SpriteAnimator(_coinsModel.configCharacterSpriteAnimations);
            _coinViews = coinViews;
            _characterView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (var coinView in coinViews)
            {
                _spriteAnimator.StartAnimation(coinView.SpriteRenderer, Track.coin_rotation, true, _animationsSpeed);
            }
        }

        public void Update(float deltaTime)
        {
            _spriteAnimator.Update(deltaTime);
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView.SpriteRenderer);
                GameObject.Destroy(contactView.gameObject);

                _coinsModel.colectCoins++;
                Debug.Log("Coins: " + _coinsModel.colectCoins);
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
