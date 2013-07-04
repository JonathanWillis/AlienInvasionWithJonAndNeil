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

    [TestFixture]
    public class GivenAnArmoryLoadedWithASinglePeashooter1000
    {
        private IDefenceWeapon _inputWeapon;
        private IDefenceWeapon _outputWeapon;

        [SetUp]
        public void WhenCallingWeaponFor()
        {
            _inputWeapon = new Peashooter1000Blaster();
            Armoury armoury = ArmouryBuilder.From(new IDefenceWeapon[] {_inputWeapon});
            _outputWeapon = armoury.WeaponsFor(new IAlienInvader[] {new AlienInvader()}).First();
        }

        [Test]
        public void ThenTheSameWeaponUsedToCreateTheArmoryIsReturned()
        {
            Assert.That(_outputWeapon, Is.SameAs(_inputWeapon));
        }
    }
}