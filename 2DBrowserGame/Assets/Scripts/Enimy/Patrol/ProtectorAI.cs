﻿using Pathfinding;
using System;
using UnityEngine;

namespace BrowserGame2D
{
    public class ProtectorAI : IProtector
    {
        private readonly LevelObjectView _view;
        private readonly PatrolAIWaypointController _model;
        private readonly AIDestinationSetter _destinationSetter;
        private readonly AIPatrolPath _patrolPath;

        private bool _isPatrolling;

        public ProtectorAI(LevelObjectView view, PatrolAIWaypointController model, AIDestinationSetter destinationSetter, AIPatrolPath patrolPath)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
            _destinationSetter = destinationSetter != null ? destinationSetter : throw new ArgumentNullException(nameof(patrolPath));
            _patrolPath = patrolPath != null ? patrolPath : throw new ArgumentNullException(nameof(model));
        }

        public void Init()
        {
            _destinationSetter.target = _model.GetNextTarget();
            _isPatrolling = true;
            _patrolPath.TargetReached += OnTargetReached;
        }

        public void Deinit()
        {
            _patrolPath.TargetReached -= OnTargetReached;
        }

        private void OnTargetReached(object sender, EventArgs e)
        {
            _destinationSetter.target = _isPatrolling
                ? _model.GetNextTarget()
                : _model.GetClosestTarget(_view.Transform.position);
        }

        public void StartProtection(GameObject invader)
        {
            _isPatrolling = false;
            _destinationSetter.target = invader.transform;
        }

        public void FinishProtection(GameObject invader)
        {
            _isPatrolling = true;
            _destinationSetter.target = _model.GetClosestTarget(_view.Transform.position);
        }
    }
}
