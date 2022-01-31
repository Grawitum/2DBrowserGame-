namespace BrowserGame2D
{
    public class TurretController
    {
        private TurretView _turretView;
        private AimingGunController _aimingGun;

        private BulletsEmitterController _bulletsEmitter;

        public TurretController(TurretView turretView, CharacterView characterView)
        {
            _turretView = turretView;
            //_turretModel = new CharacterModel();

            _aimingGun = new AimingGunController(_turretView.GunTransform, characterView.transform);

            _bulletsEmitter = new BulletsEmitterController(_turretView.bulletViews, _turretView.GunTransform);


        }

        public void Update()
        {
            _aimingGun.Update();
            _bulletsEmitter.Update();
        }
    }
}
