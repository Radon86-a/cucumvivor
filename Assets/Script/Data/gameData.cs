using UnityEngine;

[CreateAssetMenu(fileName = "gameData", menuName = "Scriptable Objects/gameData")]
public class gameData : ScriptableObject
{
    public long gamephase;
    public long now_boss_id;
    public float game_time;
    public float phase_time;
    public long kill_enemy;
    public bool is_boss;
    public long score;
    public bool is_gaming;
}
