using UnityEngine;

[CreateAssetMenu(fileName = "weaponData", menuName = "Scriptable Objects/weaponData")]
public class weaponData : ScriptableObject
{
    public Weapons[] weapons;
}

[System.Serializable]
public struct Weapons
{
    public bool use_as_item;
    public long weapon_id;
    public string weapon_name;
    public long weapon_attack;
    public long weapon_attack_id;
    public string weapon_detail;
    
    public float weapon_attack_freq; //攻撃頻度
    public float weapon_attack_speed; // 弾速
    public Sprite weapon_skin;
    public GameObject weapon_prefab;
}