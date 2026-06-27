using UnityEngine;

public class DebugSelect : MonoBehaviour
{
    public GameObject UIManager;
    public weaponData weaponData;
    private Weapons[] debugweapons = new Weapons[3];
    void Awake()
    {
        debugweapons[0] = weaponData.weapons[0];
        debugweapons[1] = weaponData.weapons[0];
        debugweapons[2] = weaponData.weapons[0];
    }
    public void ShowSelect()
    {
        UIManager.GetComponent<SelectUpgrade>().ShowSelectUI(debugweapons);
    }
}
