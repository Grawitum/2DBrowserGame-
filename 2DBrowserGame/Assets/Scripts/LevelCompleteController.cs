using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrowserGame2D
{
    public class LevelCompleteController : IDisposable
    {
        private Vector3 _startPosition;
        private LevelObjectView _characterView;
        private List<LevelObjectView> _deathZones;
        private List<LevelObjectView> _winZones;

        public LevelCompleteController(LevelObjectView characterView, List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
        {
            _startPosition = characterView.Transform.position;
            characterView.OnLevelObjectContact += OnLevelObjectContact;

            _characterView = characterView;
            _deathZones = deathZones;
            _winZones = winZones;
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_deathZones.Contains(contactView))
            {
                _characterView.Transform.position = _startPosition;
            }
            if (_winZones.Contains(contactView))
            {
                Debug.Log("Win");
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
