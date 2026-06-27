using UnityEngine;

public class Enemymanager : MonoBehaviour
{
    public gameData game_data;
    public enemyData enemy_data;
    public GameObject enemy_prefab;
    public GameObject game_player;
    public bool is_boss;
    public float cooltime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game_data.now_boss_id = Random.Range(0, enemy_data.enemies.Length - 1);
        game_data.game_time = 0f;
        game_data.phase_time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        game_data.game_time += Time.deltaTime;
        game_data.phase_time += Time.deltaTime;
        cooltime -= Time.deltaTime;
        switch(game_data.now_boss_id)
        {
        case 0:
        if(cooltime <0)
        {
            GameObject clonedObject = Instantiate(enemy_prefab, new Vector3(10, 0, 0), Quaternion.identity);
            enemy enemy_ = clonedObject.GetComponent<enemy>();
            enemy_.my_id = 0;
            enemy_.player = game_player;
            cooltime = 2;
        }
        break;
        default: break;
        }
    }
}
