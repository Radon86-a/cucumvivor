using UnityEngine;

public class SelectUpgrade : MonoBehaviour
{
    public GameObject selectUI;
    public Selection selections1;
    public Selection selections2;
    public Selection selections3;
    private Weapons[] selections = new Weapons[3];
    private int selectedID = 0;
    void Start()
    {
        selectUI.SetActive(false);
    }
    public void ShowSelectUI(Weapons[] selections)
    {
        SetSelections(selections);
        selectUI.SetActive(true);
        SetAllSelection();
        Time.timeScale = 0f;
    }
    private void SetEachSelection(Weapons weapon,Selection selection)
    {
        selection.selectionWeapon = weapon;
        selection.SetPalameter();
    }
    private void SetAllSelection()
    {
        SetEachSelection(selections[0],selections1);
        SetEachSelection(selections[1],selections2);
        SetEachSelection(selections[2],selections3);
    }

    public void SetSelections(Weapons[] selections)
    {
        if (selections.Length != 3)
        {
            Debug.LogError("不適切な配列です");
        }
        else
        {
            this.selections = selections;
        }
    }
    public void Selected(int selectedID)
    {
        SendSelectedWeaponData(selections[selectedID]);
        selectUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SendSelectedWeaponData(Weapons selectedWeapon)
    {
        //選択された武器のデータをplayerの伝える関数
        //仮設置
        Debug.Log(selectedWeapon.weapon_name);
    }
}
