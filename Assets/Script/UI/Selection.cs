using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Selection : MonoBehaviour
{
    public Weapons selectionWeapon;
    private Image image;
    private TMP_Text weaponName;
    private TMP_Text weaponText;
    void Awake()
    {
        image = this.transform.Find("Image").gameObject.GetComponentInChildren<Image>();
        weaponName = this.transform.Find("Name").GetComponent<TMP_Text>();
        weaponText = this.transform.Find("Text").GetComponent<TMP_Text>();
    }
    public void SetPalameter()
    {
        image.sprite = selectionWeapon.weapon_skin;
        weaponName.text = selectionWeapon.weapon_name;
        /*
        weaponText.text = selectionWeapon.weapon_setmei;
        */
    }
}
