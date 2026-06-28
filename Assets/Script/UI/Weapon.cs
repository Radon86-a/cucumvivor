using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
    const int maxWeapon = 5;
    public Player player;
    public Weapons[] holdWeapons = new Weapons[5];
    public Image[] slotObj = new Image[5];
    public int[] levels = new int[5];
    public TMP_Text[] levelObj = new TMP_Text[5];

    public void SetAll()
    {
        SetImage();
        SetLevel();
    }
    public void SetImage()
    {
        for(int i = 0;i < maxWeapon;i++)
        {
            if(i < player.weapon_count)
            {
                slotObj[i].sprite = player.weapons[i].weapon_skin;
                slotObj[i].color = new Color(slotObj[i].color.r,slotObj[i].color.g,slotObj[i].color.b,1f);
            }
            else
            {
                slotObj[i].sprite = null;
                slotObj[i].color = new Color(slotObj[i].color.r,slotObj[i].color.g,slotObj[i].color.b,0f);
            }
        }
    }
    public void SetLevel()
    {
        for (int i = 0; i < maxWeapon; i++)
        {
            long lv = player.weapon_levels[i];
            if (lv <= 0 || i >= player.weapon_count)
            {
                levelObj[i].text = "";
            }
            else
            {
                levelObj[i].text = "LV." + lv.ToString();
            }
        }
    }
    public void changeweapon(int slot, Weapons weapons)
    {
        holdWeapons[slot] = weapons;
    }
    public void changeLevel(int slot, int num)
    {
        levels[slot] = num;
    }

}
