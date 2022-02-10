using System;
using UnityEngine;

namespace BrowserGame2D
{
    public class SimplePatrolAIController
    {
        private readonly LevelObjectView _view;
        private readonly SimplePatrolAIWaypointController _waypointController;

        public SimplePatrolAIController(LevelObjectView view, SimplePatrolAIWaypointController model)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _waypointController = model != null ? model : throw new ArgumentNullException(nameof(model));
        }

        public void FixedUpdate()
        {
            var newVelocity = _waypointController.CalculateVelocity(_view.Transform.position) * Time.fixedDeltaTime;
            _view.Rigidbody2D.velocity = newVelocity;
        }
    }
}
