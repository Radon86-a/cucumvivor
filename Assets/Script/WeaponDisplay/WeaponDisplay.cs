using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class WeaponDisplay : MonoBehaviour
{
    public weaponData weaponDatabase;   // ScriptableObject
    public TextMeshProUGUI nameText;    // 武器名
    public TextMeshProUGUI detailText;  // 説明文
    public Image weaponImage;           // 画像

    public void ShowWeapon(int id)
    {
        // 指定IDの武器データを取得
        Weapons w = weaponDatabase.weapons[id];

        // UI に反映
        nameText.text = w.weapon_name;
        detailText.text = w.weapon_detail;
        weaponImage.sprite = w.weapon_skin;
    }
}

