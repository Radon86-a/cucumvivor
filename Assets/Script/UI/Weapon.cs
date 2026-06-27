using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
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
        for(int i = 0; i < player.weapon_counts; i++)
        {
            
        }
    }
    public void SetLevel()
    {
        for (int i = 0; i < 5; i++)
        {
            if (levels[i] <= 0)
            {
                levelObj[i].text = "";
            }
            else
            {
                levelObj[i].text = "LV." + levels[i].ToString();
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
