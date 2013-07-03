using System.Collections.Generic;
using System.Linq;
using AlienInvasion.Client;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion
{
	public class EarthDefender : IEarthDefender
	{
	    private Dictionary<IDefenceWeapon[], Armoury> _armouries;

	    public EarthDefender()
	    {
            _armouries = new Dictionary<IDefenceWeapon[], Armoury>();
	    }

	    public DefenceStrategy DefendEarth(IAlienInvasionWave invasionWave)
		{
            
            if (!_armouries.ContainsKey(invasionWave.WeaponsAvailableForDefence))
            {
                _armouries.Add(invasionWave.WeaponsAvailableForDefence, ArmouryBuilder.From(invasionWave.WeaponsAvailableForDefence));
            }


	        var armoury = _armouries[invasionWave.WeaponsAvailableForDefence];
		    return new DefenceStrategy(armoury.WeaponsFor(invasionWave.AlienInvaders));
		}
	}

    public interface IArmouryWeapon
    {
        bool IsReloading();
        void DeployTo(IList<IDefenceWeapon> weapons);
        void NewWaveIncoming();
    }

    public class Armoury
    {
        private readonly List<IArmouryWeapon> _weaponsAvailableForDefence;

        public Armoury()
        {
            _weaponsAvailableForDefence = new List<IArmouryWeapon>();
        }

        public IEnumerable<IDefenceWeapon> WeaponsFor(IAlienInvader[] alienInvaders)
        {
            var weaponsToFire = new List<IDefenceWeapon>();
            var invaderCount = alienInvaders.Count();
            NewWaveIncoming();
            foreach (var weapon in _weaponsAvailableForDefence)
            {
                if (!weapon.IsReloading())
                    weapon.DeployTo(weaponsToFire);
               
                if (invaderCount == weaponsToFire.Count)
                    break;
            }
            return weaponsToFire;
        }

        private void NewWaveIncoming()
        {
            foreach (var weapon in _weaponsAvailableForDefence)
            {
                weapon.NewWaveIncoming();
            }
        }

        public void Add(IArmouryWeapon weapon)
        {
            _weaponsAvailableForDefence.Add(weapon);
        }
    }

    public class ArmouryBuilder
    {
        public static Armoury From(IEnumerable<IDefenceWeapon> weapons)
        {
            var armoury = new Armoury();
            foreach (var defenceWeapon in weapons)
            {
                switch (defenceWeapon.DefenceWeaponType)
                {
                    case DefenceWeaponType.Peashooter500Blaster:
                        armoury.Add(new Peashooter500Blaster());
                        break;
                    case DefenceWeaponType.Peashooter1000Blaster:
                        armoury.Add(new Peashooter1000Blaster());
                        break;
                }
            }
            return armoury;
        }
    }
}
