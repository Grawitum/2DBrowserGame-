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
        //add links to test views <1>

        private Camera _camera;
        private ParalaxManager _paralaxManager;

        private CharacterController _characterController;
        private EnimyController _enimyController;

        private TurretController _turretController;
        private CoinsController _coinsController;

        private LevelCompleteController _levelCompleteController;

        private float _fixedDeltaTime;

        //private SomeManager _someManager;
        //add links to some logic managers <2>

        private void Start()
        {
            //SomeConfig config = Resources.Load("SomeConfig", typeof(SomeConfig))as   SomeConfig;
            //load some configs here <3>
            _camera = Camera.main;
            _paralaxManager = new ParalaxManager(_camera.transform, _back.transform);

            _characterController = new CharacterController(_characterView);
            _enimyController = new EnimyController(_enimyView);

            _turretController = new TurretController(_turretView,_characterView);
            _coinsController = new CoinsController(_characterView, _coinViews);

            _levelCompleteController = new LevelCompleteController(_characterView,_deathZones,_winZones);

            //_someManager = new SomeManager(config);
            //create some logic managers here for tests <4>
        }

        private void Update()
        {
            _paralaxManager.Update();

            _characterController.Update();
            _enimyController.Update();

            _turretController.Update();
            _coinsController.Update();
            //_someManager.Update();
            //update logic managers here <5>
        }

        private void FixedUpdate()
        {
            _fixedDeltaTime = Time.fixedDeltaTime;
            _characterController.FixedUpdate(_fixedDeltaTime);
            //_someManager.FixedUpdate();
            //update logic managers here <6>
        }

        private void OnDestroy()
        {
            //_someManager.Dispose();
            //dispose logic managers here <7>
        }

    }
}

