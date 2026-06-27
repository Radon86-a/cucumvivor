using UnityEngine;

public class Enemymanager : MonoBehaviour
{
    public gameData game_data;
    public enemyData enemy_data;
    public GameObject enemy_prefab;
    public GameObject game_player;
    public GameObject Enemy_bullet;
    public bool is_boss;
    public float cooltime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game_data.now_boss_id = Random.Range(0, enemy_data.enemies.Length - 1);
        game_data.game_time = 0f;
        game_data.phase_time = 0f;
        switch(game_data.now_boss_id)
        {
        case 0:
        if(cooltime <0)
        {
            cooltime = 2.5f;
        }
        break;
        case 1:
        break;
        default: break;
        }
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
        //ダミーボスの場合の雑魚敵
        if(cooltime <0)
        {
            for(long i = 0; i < 3; i++)
            {
            GameObject clonedObject = Instantiate(enemy_prefab, new Vector3(10, 5 - 5 * i, 0), Quaternion.identity);
            enemy enemy_ = clonedObject.GetComponent<enemy>();
            enemy_.my_id = 0;
            enemy_.player = game_player;
            enemy_.enemy_bullet = Enemy_bullet;
            }
            cooltime = 2;
        }
        break;
        case 1:
        break;
        default: break;
        }
    }
}
