using Pathfinding;
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

        private SimplePatrolAIController _simplePatrolAIController;
        private StalkerAIController _stalkerAI;

        private void Start()
        {
            _simplePatrolAIController = new SimplePatrolAIController(_simplePatrolAIView, new SimplePatrolAIWaypointController(_simplePatrolAIConfig));
            _stalkerAI = new StalkerAIController(_stalkerAIView, new StalkerAIWaypointController(_stalkerAIConfig), _stalkerAISeeker, _stalkerAITarget);
            InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);
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

    }
}

