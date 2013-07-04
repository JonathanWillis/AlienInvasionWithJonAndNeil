using System.Collections.Generic;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion
{
    public interface IArmouryWeapon
    {
        bool IsReloading();
        void DeployTo(IList<IDefenceWeapon> weapons);
        void NewWaveIncoming();
    }

    public class Peashooter500Blaster : IDefenceWeapon, IArmouryWeapon
    {
        private readonly IDefenceWeapon _defenceWeapon;
        private int _reloadCounter;

        public Peashooter500Blaster()
        {
            
        }

        public Peashooter500Blaster(IDefenceWeapon defenceWeapon)
        {
            _defenceWeapon = defenceWeapon;
        }

        public DefenceWeaponType DefenceWeaponType {  get { return DefenceWeaponType.Peashooter500Blaster; }}

        public bool IsReloading()
        {
            return _reloadCounter > 0;
        }

        public void DeployTo(IList<IDefenceWeapon> weapons)
        {
            weapons.Add(_defenceWeapon);
            _reloadCounter = 2;
        }

        public void NewWaveIncoming()
        {
            _reloadCounter--;
        }
    }

    public class Peashooter1000Blaster : IDefenceWeapon, IArmouryWeapon
    {
        private readonly IDefenceWeapon _defenceWeapon;

        public Peashooter1000Blaster()
        {

        }

        public Peashooter1000Blaster(IDefenceWeapon defenceWeapon)
        {
            _defenceWeapon = defenceWeapon;
        }

        public DefenceWeaponType DefenceWeaponType { get { return DefenceWeaponType.Peashooter1000Blaster; } }

        public bool IsReloading()
        {
            return false;
        }

        public void DeployTo(IList<IDefenceWeapon> weapons)
        {
            weapons.Add(_defenceWeapon);
        }

        public void NewWaveIncoming()
        {

        }
    }
}