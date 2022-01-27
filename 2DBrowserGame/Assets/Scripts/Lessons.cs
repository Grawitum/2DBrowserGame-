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
        //add links to test views <1>

        private Camera _camera;
        private ParalaxManager _paralaxManager;

        private CharacterController _characterController;
        private EnimyController _enimyController;

        //private SomeManager _someManager;
        //add links to some logic managers <2>

        private void Start()
        {
            //SomeConfig config = Resources.Load("SomeConfig", typeof(SomeConfig))as   SomeConfig;
            //load some configs here <3>
            _camera = Camera.main;
            _paralaxManager = new ParalaxManager(_camera.transform, _back.transform);

            _characterController = new CharacterController(_characterView.SpriteRenderer);
            _enimyController = new EnimyController(_enimyView.SpriteRenderer);

            //_someManager = new SomeManager(config);
            //create some logic managers here for tests <4>
        }

        private void Update()
        {
            _paralaxManager.Update();

            _characterController.Update();
            _enimyController.Update();
            //_someManager.Update();
            //update logic managers here <5>
        }

        private void FixedUpdate()
        {
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

