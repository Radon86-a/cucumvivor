using UnityEngine;

[CreateAssetMenu(fileName = "enemyData", menuName = "Scriptable Objects/enemyData")]
public class enemyData : ScriptableObject
{
    public Enemies[] enemies;
    
}

[System.Serializable]
public struct Enemies
    {
        public long enemy_id;
        public long enemy_HP;
        public string emeny_name;
        public long enemy_attack;
        public long enemy_speed;
        public long enemy_attack_id;
        public Sprite enemy_skin;
    }
