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
    [SerializeField]
    Weapon weaponUI;
    public AudioClip hyoji_SE;
    public AudioClip decide_SE;
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
        AudioManager.Instance.PlaySoundOneShot(hyoji_SE);
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
        AudioManager.Instance.PlaySoundOneShot(decide_SE);
        //SendSelectedWeaponData(selections[selectedID]);
        selectUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SendSelectedWeaponToLoad(Weapons weapons)
    {
        //weapon選ばれたら実行
        this.GetComponent<weaponsLoadScript>().SelectedWeaponLoad(weapons);
    }
    
    /*
    id+12
| id  | 名前             | 対象 | 上昇幅 | 説明                | 実装 |
| --- | ---------------- | ---- | ------ | ------------------- | ---- |
| 0   | ダミーアイテム   | 1    | -100   | ダミーのアイテム    | 済   |
| 1   | きゅうりの冠     | 0    | +100   | 最大HPを100増やす   | 未   |
| 2   | 全休り           | 0    | ×1.5   | 最大HPを1.2倍する   | 未   |
| 3   | 杞憂り           | 3    | +2     | 移動速度を2増やす   | 未   |
| 4   | 緩急り           | 4    | +1     | 攻撃頻度を1増やす   | 未   |
| 5   | きゅうり缶       | 1    | +20%   | 最大HPの20%回復する | 未   |
| 6   | 救急救命きゅうり | 1    | +50%   | 最大HPの50%回復する | 未   |
| 7   | きゅうりソード   | 2    | ×1.5   | 攻撃力を1.5倍する   | 未   |
| 8   | 精霊馬           | 3    | ×1.5   | 移動速度を1.5倍する | 未   |
| 9   | きゅうりの漬物   | 2    | +20    | 攻撃力を20増やす    | 未   |
| 10  | きゅうリング     | 2    | ×2.0   | 攻撃力を二倍する    | 未   |
| 11  | 柑橘きゅうり     | 0,2  | ×1.2   | 栄養満点！          | 未   |
|     |                  |      |        |                     |      |
    */
    public void SendSelectedWeaponData(Weapons selectedWeapon)
    {
        if (selectedWeapon.use_as_item)
        {
            //アイテムとして使用する場合の処理
            switch(selectedWeapon.weapon_id)
            {
                case 13:
                    //きゅうりの冠
                    player.max_HP += 100;
                break;
                case 14:
                    //ぜんきゅうり
                    player.max_HP = (long)(player.max_HP* 1.2f);
                break;
                case 15:
                    //杞憂り
                    player.speed += 2;
                break;
                case 16:
                    //緩急り
                    player.attack_freq *= 0.8f;
                break;
                case 17:
                    //きゅうり缶
                    player.HP += (long)(player.max_HP * 0.2f);
                break;
                case 18:
                    //救急救命きゅうり
                    player.HP += (long)(player.max_HP * 0.8f);
                break;
                case 19:
                    //きゅうりソード
                    player.attack = (long)(player.attack * 1.5f);
                break;
                case 20:
                    //精霊馬
                    player.speed *= 1.5f;
                break;
                case 21:
                    //きゅうりの漬物
                    player.attack += 20;
                break;
                case 22:
                    //きゅうリング
                    player.attack *= 2;
                break;
                case 23:
                    //柑橘きゅうり
                    player.max_HP = (long)(player.max_HP * 1.2f);
                    player.attack = (long)(player.attack * 1.2f);
                break;


                
                
                default:
                    print("未実装のアイテムです。");
                    break;
            }
            return;
        }
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
                weaponUI.SetAll();
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
        weaponUI.SetAll();
    }

}
