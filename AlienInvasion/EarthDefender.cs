using System.Linq;
using AlienInvasion.Client;

namespace AlienInvasion
{
	public class EarthDefender : IEarthDefender
	{

		public DefenceStrategy DefendEarth(IAlienInvasionWave invasionWave)
		{
		    return new DefenceStrategy(invasionWave.WeaponsAvailableForDefence.Take(invasionWave.AlienInvaders.Count()));
		}
	}
}
