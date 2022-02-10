using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

namespace BrowserGame2D
{
    public class EnemiesConfigurator : MonoBehaviour
    {
        [Header("Simple AI")]
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private LevelObjectView _simplePatrolAIView;

        [Header("Stalker AI")]
        [SerializeField] private AIConfig _stalkerAIConfig;
        [SerializeField] private LevelObjectView _stalkerAIView;
        [SerializeField] private Seeker _stalkerAISeeker;
        [SerializeField] private Transform _stalkerAITarget;

        [Header("Protector AI")]
        [SerializeField] private LevelObjectView _protectorAIView;
        [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
        [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
        [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
        [SerializeField] private Transform[] _protectorWaypoints;

        private SimplePatrolAIController _simplePatrolAIController;

        private StalkerAIController _stalkerAI;

        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;

        private void Start()
        {
            _simplePatrolAIController = new SimplePatrolAIController(_simplePatrolAIView, new SimplePatrolAIWaypointController(_simplePatrolAIConfig));
            _stalkerAI = new StalkerAIController(_stalkerAIView, new StalkerAIWaypointController(_stalkerAIConfig), _stalkerAISeeker, _stalkerAITarget);
            InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);

            _protectorAI = new ProtectorAI(_protectorAIView, new PatrolAIWaypointController(_protectorWaypoints), _protectorAIDestinationSetter, _protectorAIPatrolPath);
            _protectorAI.Init();

            _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector> { _protectorAI });
            _protectedZone.Init();

        }

        private void FixedUpdate()
        {
            if (_simplePatrolAIController != null) _simplePatrolAIController.FixedUpdate();
            if (_stalkerAI != null) _stalkerAI.FixedUpdate();
        }

        private void RecalculateAIPath()
        {
            _stalkerAI.RecalculatePath();
        }

        private void OnDestroy()
        {
            _protectorAI.Deinit();
            _protectedZone.Deinit();
        }
    }
}

