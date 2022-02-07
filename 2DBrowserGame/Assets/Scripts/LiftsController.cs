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
            //Debug.Log(contactView.name);
            if (_liftViews.Contains(contactView))
            {
                //Debug.Log("lift");
                _jointMotor = contactView.gameObject.GetComponent<SliderJoint2D>().motor;
                //Debug.Log(_jointMotor.motorSpeed);
                _jointMotor.motorSpeed *= -1;
                //Debug.Log(_jointMotor.motorSpeed);
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
