using UnityEngine;

public class Enemymanager : MonoBehaviour
{
    public gameData game_data;
    public enemyData enemy_data;
    public bossData boss_data;
    public GameObject enemy_prefab;
    public GameObject game_player;
    public GameObject Enemy_bullet;
    public GameObject boss_prefab;
    public long until_boss = 60;
    public long on_boss;
    public float cooltime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game_data.kill_enemy = 0;
        game_data.now_boss_id = UnityEngine.Random.Range(1, boss_data.bosses.Length);
        game_data.game_time = 0f;
        game_data.phase_time = 0f;
        game_data.gamephase = 0;
        game_data.is_boss = false;
        switch(game_data.now_boss_id)
        {
        case 0:
        if(cooltime <0)
        {
            cooltime = 2.5f;
        }
        break;
        case 1:
        if(cooltime <0)
        {
            cooltime = 3.0f;
        }
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
        if(cooltime < 0 && game_data.is_boss == false)
        {
            for(long i = 0; i < 3; i++)
            {
            MakeEnemy(new Vector3(10, 5 - 5 * i, 0), 0);
            }
            cooltime = 3.0f;
        }
        if(game_data.phase_time > until_boss && game_data.is_boss == false)
            {
                game_data.is_boss = true;
                MakeBoss(new Vector3(8, 0, 0));
            }
        break;
        case 1:
        if(cooltime <0 && game_data.is_boss == false)
        {
            for(long i = 0; i < 2 ;i++)
            {
            MakeEnemy(new Vector3(10, 5 - 10 * i, 0), 1);
            }
            if(game_data.phase_time > 30 && game_data.gamephase < 1)
            {
            MakeEnemy(new Vector3(10, 0, 0), 1);
            }
            if(game_data.phase_time > 30 && game_data.gamephase >= 1)
            {
            MakeEnemy(new Vector3(10, 0, 0), 4);
            MakeEnemy(new Vector3(-10, 0, 0), 1);
            }
            cooltime = 3;
        }
        if(game_data.phase_time > until_boss && game_data.is_boss == false)
            {
                game_data.is_boss = true;
                MakeBoss(new Vector3(8, 0, 0));
            }
        break;
        case 2:
        if(cooltime <0 && game_data.is_boss == false)
        {
            for(long i = 0; i < 2 ;i++)
            {
            MakeEnemy(new Vector3(10, 5 - 10 * i, 0), 2);
            }
            if(game_data.phase_time > 30 && game_data.gamephase < 1)
            {
            MakeEnemy(new Vector3(10, 0, 0), 1);
            }
            if(game_data.phase_time > 30 && game_data.gamephase >= 1)
            {
            MakeEnemy(new Vector3(10, 0, 0), 4);
            MakeEnemy(new Vector3(-10, 0, 0), 1);
            }
            cooltime = 3;
        }
        if(game_data.phase_time > until_boss && game_data.is_boss == false)
            {
                game_data.is_boss = true;
                MakeBoss(new Vector3(8, 0, 0));
            }
        break;
        case 3:
        if(cooltime <0 && game_data.is_boss == false)
        {
            for(long i = 0; i < 2 ;i++)
            {
            MakeEnemy(new Vector3(10, 5 - 10 * i, 0), 3);
            }
            if(game_data.phase_time > 60 && game_data.gamephase < 1)
            {
            MakeEnemy(new Vector3(10, 0, 0), 1);
            }
            if(game_data.phase_time > 60 && game_data.gamephase >= 1)
            {
            MakeEnemy(new Vector3(10, 0, 0), 4);
            MakeEnemy(new Vector3(-10, 0, 0), 1);
            }
            cooltime = 3;
        }
        if(game_data.phase_time > until_boss && game_data.is_boss == false)
            {
                game_data.is_boss = true;
                MakeBoss(new Vector3(8, 0, 0));
            }
        break;
        default: break;
        }
    }

    //敵生成用のメソッド
    void MakeEnemy(Vector3 iti,long id)
    {
        GameObject clonedObject = Instantiate(enemy_prefab, iti, Quaternion.identity);
        enemy enemy_ = clonedObject.GetComponent<enemy>();
        enemy_.my_id = id;
        enemy_.player = game_player;
        enemy_.enemy_bullet = Enemy_bullet;
    }
    void MakeBoss(Vector3 iti)
    {
        GameObject clonedObject = Instantiate(boss_prefab, iti, Quaternion.identity);
        Boss boss = clonedObject.GetComponent<Boss>();
        boss.boss_id = game_data.now_boss_id;
        boss.player = game_player;
    }
}
