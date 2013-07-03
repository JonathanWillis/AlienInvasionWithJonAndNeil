using System.Collections.Generic;
using System.Linq;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;
using NUnit.Framework;

namespace AlienInvasion
{
    [TestFixture]
    public class GivenAnArmoryLoadedWithTwoPeashooter500s
    {
        private IDefenceWeapon _weapon1;
        private IDefenceWeapon _weapon2;

        [SetUp]
        public void WhenCallingWeaponsForTwice()
        {
            Armoury armory = ArmouryBuilder.From(new IDefenceWeapon[] { new Peashooter500Blaster(), new Peashooter500Blaster() });
            _weapon1 = armory.WeaponsFor(new IAlienInvader[] { new AlienInvader() }).First();
            _weapon2 = armory.WeaponsFor(new IAlienInvader[] { new AlienInvader() }).First();
        }

        [Test]
        public void ThenDifferentWeaponsAreReturnedOnEachCall()
        {
            Assert.That(_weapon1, Is.Not.EqualTo(_weapon2));
        }
    }

    [TestFixture]
    public class GivenAnArmoryLoadedWithTwoPeashooter500sForThreeWaves
    {
        private IDefenceWeapon _weapon1;
        private IDefenceWeapon _weapon3;

        [SetUp]
        public void WhenCallingWeaponsForThreeTimes()
        {
            Armoury armory = ArmouryBuilder.From(new IDefenceWeapon[] { new Peashooter500Blaster(), new Peashooter500Blaster() });
            _weapon1 = armory.WeaponsFor(new IAlienInvader[] { new AlienInvader() }).First();
            armory.WeaponsFor(new IAlienInvader[] {new AlienInvader()});
            _weapon3 = armory.WeaponsFor(new IAlienInvader[] { new AlienInvader() }).First();
        }

        [Test]
        public void ThenDifferentWeaponsAreReturnedOnEachCall()
        {
            Assert.That(_weapon1, Is.EqualTo(_weapon3));
        }
    }

    public class Peashooter500Blaster : IDefenceWeapon, IArmouryWeapon
    {
        private int _reloadCounter;
        public DefenceWeaponType DefenceWeaponType {  get { return DefenceWeaponType.Peashooter500Blaster; }}

        public bool IsReloading()
        {
            return _reloadCounter > 0;
        }

        public void DeployTo(IList<IDefenceWeapon> weapons)
        {
            weapons.Add(this);
            _reloadCounter = 2;
        }

        public void NewWaveIncoming()
        {
            _reloadCounter--;
        }
    }

    public class Peashooter1000Blaster : IDefenceWeapon, IArmouryWeapon
    {
        public DefenceWeaponType DefenceWeaponType { get { return DefenceWeaponType.Peashooter500Blaster; } }

        public bool IsReloading()
        {
            return false;
        }

        public void DeployTo(IList<IDefenceWeapon> weapons)
        {
            weapons.Add(this);
        }

        public void NewWaveIncoming()
        {
           
        }
    }
}