using System.Collections.Generic;
using System.Linq;
using AlienInvasion.Client;
using AlienInvasion.Client.AlienInvaders;
using AlienInvasion.Client.DefenceAssets;

namespace AlienInvasion
{
	public class EarthDefender : IEarthDefender
	{

		public DefenceStrategy DefendEarth(IAlienInvasionWave invasionWave)
		{
		    var armoury = new Armoury(invasionWave.WeaponsAvailableForDefence);
		    return new DefenceStrategy(armoury.WeaponsFor(invasionWave.AlienInvaders));
		}
	}

    public class Armoury
    {
        private readonly IDefenceWeapon[] _weaponsAvailableForDefence;

        public Armoury(IDefenceWeapon[] weaponsAvailableForDefence)
        {
            _weaponsAvailableForDefence = weaponsAvailableForDefence;
        }

        public IEnumerable<IDefenceWeapon> WeaponsFor(IAlienInvader[] alienInvaders)
        {
           return _weaponsAvailableForDefence.Take(alienInvaders.Count());
        }
    }
}
