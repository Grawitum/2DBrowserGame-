using UnityEngine;

namespace BrowserGame2D
{

    public class Lessons : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private SpriteRenderer _back;
        //[SerializeField]
        //private SomeView _someView;
        //add links to test views <1>

        private ParalaxManager _paralaxManager;

        private SpriteAnimator _spriteAnimator;
        //private SomeManager _someManager;
        //add links to some logic managers <2>

        private void Start()
        {
            //SomeConfig config = Resources.Load("SomeConfig", typeof(SomeConfig))as   SomeConfig;
            //load some configs here <3>

            _paralaxManager = new ParalaxManager(_camera.transform, _back.transform);

            SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsConfig");
            _spriteAnimator = new SpriteAnimator(config);
            //_someManager = new SomeManager(config);
            //create some logic managers here for tests <4>
        }

        //_spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.sonic_walk, true, 10);  //Старт анимации

        private void Update()
        {
            _paralaxManager.Update();

            _spriteAnimator.Update();
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

