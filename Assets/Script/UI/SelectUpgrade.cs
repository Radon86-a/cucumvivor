using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectUpgrade : MonoBehaviour
{
    [SerializeField]
    public weaponData weaponData;
    public GameObject selectUI;
    public Selection selections1;
    public Selection selections2;
    public Selection selections3;
    private Weapons[] selections = new Weapons[3];
    private int selectedID = 0;
    [SerializeField]
    Player player;
    void Start()
    {
        selectUI.SetActive(false);
    }
    private void selectionRandom()
    {
        //武器の中からランダムに3つ選ぶ。重複を除外
        List<Weapons> weaponList = new List<Weapons>(weaponData.weapons);
        for (int i = 0; i < selections.Length; i++)
        {
            int randomIndex = Random.Range(0, weaponList.Count);
            selections[i] = weaponList[randomIndex];
            weaponList.RemoveAt(randomIndex);
        }


    }
    public void ShowSelectUI(Weapons[] selections)
    {
        selectionRandom();
        // SetSelections(selections);
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
        print("選択された武器id"+selectedWeapon.weapon_id+"名前"+selectedWeapon.weapon_name);
        //playerに選択された武器のデータを送る処理
        
        //まずすでにその武器を持っているか確認する
        for(int i = 0; i < player.weapon_count; i++)
        {
            if(player.weapons[i].weapon_id == selectedWeapon.weapon_id)
            {
                //すでに持っている場合はレベルを上げる
                player.weapon_levels[i]++;
                print("武器のレベルを上げました。現在のレベル"+player.weapon_levels[i]);
                return;
            }
        }
        //持っていなかったら追加
        if(player.weapon_count < player.weapons.Length)
        {
            player.weapons[player.weapon_count] = selectedWeapon;
            player.weapon_levels[player.weapon_count] = 1;
            player.weapon_count++;
            print("武器を追加しました。現在の武器数"+player.weapon_count);
        }
        else
        {
            print("武器を追加できません。現在の武器数"+player.weapon_count);
        }
    }
}
