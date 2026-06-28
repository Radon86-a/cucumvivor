using System.Collections.Generic;
using UnityEngine;

public class weaponsLoadScript : MonoBehaviour
{
    public List<GameObject> havingweaponObj = new List<GameObject>();
    public List<Weapons> havingweapons = new List<Weapons>();
    public void SelectedWeaponLoad(Weapons weapon)
    {
        havingweaponObj.Add(Instantiate(weapon.weapon_prefab,transform));
        havingweapons.Add(weapon);
    }
    public void LevelUpWeaponLoad(Weapons weapon)
    {
        foreach(Weapons listWeapon in havingweapons)
        {
            if(listWeapon == weapon)
            {
                
            }
        }
    }
}
