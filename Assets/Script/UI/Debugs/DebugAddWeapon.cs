using UnityEngine;
using TMPro;
using Unity.Multiplayer.Center.Common;

public class DebugAddWeapon : MonoBehaviour
{
    public int slot;
    public int weapon;
    public int level;
    public Weapon weaponUI;
    public weaponData weaponData;
    public void SetWeapon()
    {
        if (weapon < 0)
        {
            weaponUI.changeweapon(slot, new Weapons());
        }
        else
        {
            weaponUI.changeweapon(slot, weaponData.weapons[weapon]);
        }
        weaponUI.changeLevel(slot, level);
        weaponUI.SetAll();
    }
}
