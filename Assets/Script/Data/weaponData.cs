using UnityEngine;

[CreateAssetMenu(fileName = "weaponData", menuName = "Scriptable Objects/weaponData")]
public class weaponData : ScriptableObject
{
    public Weapons[] weapons;
}

[System.Serializable]
public struct Weapons
{
    public long weapon_id;
    public string weapon_name;
    public long weapon_attack;
    public long weapon_attack_id;
    public string weapon_detail;
    public Sprite weapon_skin;
    public GameObject weapon_prefab;
}