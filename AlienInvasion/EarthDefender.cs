using System.Collections.Generic;
using AlienInvasion.Client;
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
}
