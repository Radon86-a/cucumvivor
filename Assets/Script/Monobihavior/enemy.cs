using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject exp;
    public enemyData enemy_data;
    public gameData game_data;
    public long my_id;
    public long my_HP;
    public long my_attack;
    public long my_attack_id;
    public long my_speed;
    public float attack_cooltime;
    private SpriteRenderer myRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期値の取得
        my_HP = (game_data.gamephase + 1) * enemy_data.enemies[my_id].enemy_HP;
        my_attack = (game_data.gamephase + 1) * enemy_data.enemies[my_id].enemy_attack;
        my_attack_id = enemy_data.enemies[my_id].enemy_attack_id;
        my_speed = enemy_data.enemies[my_id].enemy_speed;
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sprite = enemy_data.enemies[my_id].enemy_skin;
    }

    // Update is called once per frame
    void Update()
    {
        if(my_attack_id == 0)
        {
            Vector3 direction = player.transform.position - transform.position + new Vector3 (1.0f, 0, 0);
            direction.z = 0f;
            Vector3 normalizedDirection = direction.normalized;
            transform.position += normalizedDirection * my_speed * Time.deltaTime;
        }
        if(my_attack_id == 1)
        {
            Vector3 direction = player.transform.position - transform.position + new Vector3 (4, 0, 0);
            direction.z = 0f;
            Vector3 normalizedDirection = direction.normalized;
            transform.position += normalizedDirection * my_speed * Time.deltaTime;
            attack_cooltime += Time.deltaTime;
            if(attack_cooltime < 0)
            {
                //敵の遠距離攻撃
            }
        }

        if(my_HP <= 0)
        {
            // 死亡時の処理
            GameObject clonedObject = Instantiate(exp, transform.position, Quaternion.identity);
            expItem exp_item = clonedObject.GetComponent<expItem>();
            exp_item.exp_amount = 1;
            Destroy (this.gameObject);
        }
    }
}
