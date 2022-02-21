using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrowserGame2D
{
    public class LiftsController : IDisposable
    {
        private List<LevelObjectView> _liftViews;
        private List<LevelObjectView> _turnTriggers;
        private JointMotor2D _jointMotor;

        public LiftsController(List<LevelObjectView> liftViews, List<LevelObjectView> turnTriggers)
        {
            _liftViews = liftViews;
            _turnTriggers = turnTriggers;
            foreach (LevelObjectView objectView in _turnTriggers)
            {
                objectView.OnLevelObjectContact += OnLevelObjectContact;
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_liftViews.Contains(contactView))
            {
                _jointMotor = contactView.gameObject.GetComponent<SliderJoint2D>().motor;
                _jointMotor.motorSpeed *= -1;
                contactView.gameObject.GetComponent<SliderJoint2D>().motor = _jointMotor;
            }
        }

        public void Dispose()
        {
            foreach (LevelObjectView objectView in _turnTriggers)
            {
                objectView.OnLevelObjectContact -= OnLevelObjectContact;
            }
        }
    }
}
