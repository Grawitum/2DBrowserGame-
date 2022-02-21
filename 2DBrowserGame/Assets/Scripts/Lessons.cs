using System.Collections.Generic;
using UnityEngine;

namespace BrowserGame2D
{
    public class Lessons : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _back;
        [SerializeField]
        private CharacterView _characterView;
        [SerializeField]
        private EnimyView _enimyView;

        [SerializeField]
        private TurretView _turretView;

        [SerializeField]
        private List<LevelObjectView> _coinViews;

        [SerializeField]
        private List<LevelObjectView> _deathZones;

        [SerializeField]
        private List<LevelObjectView> _winZones;

        [SerializeField]
        private List<LevelObjectView> _liftViews;

        [SerializeField]
        private List<LevelObjectView> _turnTriggers;

        private Camera _camera;
        private ParalaxManager _paralaxManager;

        private CharacterController _characterController;
        private EnimyController _enimyController;

        private TurretController _turretController;
        private CoinsController _coinsController;

        private LevelCompleteController _levelCompleteController;
        private LiftsController _liftsController;

        private float _fixedDeltaTime;

        [SerializeField]
        private GenerateLevelView _generateLevelView;

        private GeneratorLevelController _generatorLevelController;

        private float _deltaTime;

        private void Awake()
        {
            _generatorLevelController = new GeneratorLevelController(_generateLevelView);
            _generatorLevelController.Awake();
        }

        private void Start()
        {
            _camera = Camera.main;
            _paralaxManager = new ParalaxManager(_camera.transform, _back.transform);

            _characterController = new CharacterController(_characterView);
            _enimyController = new EnimyController(_enimyView);

            _turretController = new TurretController(_turretView,_characterView);
            _coinsController = new CoinsController(_characterView, _coinViews);
            _levelCompleteController = new LevelCompleteController(_characterView, _deathZones, _winZones);

            _liftsController = new LiftsController(_liftViews,_turnTriggers);
        }

        private void Update()
        {
            _deltaTime = Time.deltaTime;

            _paralaxManager.Update();
            _characterController.Update(_deltaTime);
            _enimyController.Update(_deltaTime);
            _turretController.Update(_deltaTime);
            _coinsController.Update(_deltaTime);
        }

        private void FixedUpdate()
        {
            _fixedDeltaTime = Time.fixedDeltaTime;

            _characterController.FixedUpdate(_fixedDeltaTime);
            _enimyController.FixedUpdate();
        }

        private void OnDestroy()
        {
            _coinsController.Dispose();
            _levelCompleteController.Dispose();
            _liftsController.Dispose();
        }
    }
}

