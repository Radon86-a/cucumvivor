using UnityEngine;

[CreateAssetMenu(fileName = "bossData", menuName = "Scriptable Objects/bossData")]
public class bossData : ScriptableObject
{
    public Bosses[] bosses;
}

[System.Serializable]
public struct Bosses
{
    public long boss_id;
    public long boss_HP;
    public string boss_name;
    public long boss_attack;
    public long boss_speed;
    public long boss_attack_id;
    public Sprite boss_skin;
}