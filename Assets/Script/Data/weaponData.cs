using UnityEngine;

[CreateAssetMenu(fileName = "weaponData", menuName = "Scriptable Objects/weaponData")]
public class weaponData : ScriptableObject
{
    public Weapons[] weapons;
}

[System.Serializable]
public struct Weapons
{
    public string weapon_name;
    public string weapon_detail;
    public Sprite weapon_skin;
    public GameObject weapon_prefab;
}