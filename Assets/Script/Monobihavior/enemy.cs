using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject exp;
    public GameObject enemy_bullet;
    public GameObject deathParticle;
    public enemyData enemy_data;
    public gameData game_data;
    //カメラの取得
    public CameraAction cameraAction;
    public AudioClip killed_SE;
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
        //接触ダメージの設定
        GetComponent<Attack>().damageAmount = my_attack;
        GetComponent<Attack>().cameraAction = cameraAction;
    }

    // Update is called once per frame
    void Update()
    {
        if (my_attack_id == 0)
        {
            Vector3 direction = player.transform.position - transform.position;
            if(direction.x * direction.x + direction.y * direction.y > 0.4)
            {
            direction.z = 0f;
            Vector3 normalizedDirection = direction.normalized;
            transform.position += normalizedDirection * my_speed * Time.deltaTime;
            }
        }
        if (my_attack_id == 1)
        {
            Vector3 direction = player.transform.position - transform.position + new Vector3(4, 0, 0);
            direction.z = 0f;
            Vector3 normalizedDirection = direction.normalized;
            transform.position += normalizedDirection * my_speed * Time.deltaTime;
            attack_cooltime -= Time.deltaTime;
            if (attack_cooltime < 0)
            {
                GameObject clonedObject = Instantiate(enemy_bullet, transform.position, Quaternion.identity);
                EnemyAttack enemy_attack = clonedObject.GetComponent<EnemyAttack>();
                Attack attack = clonedObject.GetComponent<Attack>();
                attack.cameraAction = cameraAction;
                attack.damageAmount = my_attack;
                enemy_attack.game_player = player;
                attack_cooltime = 2;
            }
        }

        if(game_data.is_boss == true)
        {
            Destroy(this.gameObject);
        }
        if (my_HP <= 0)
        {
            // 死亡時の処理
            GameObject clonedObject = Instantiate(exp, transform.position, Quaternion.identity);
            expItem exp_item = clonedObject.GetComponent<expItem>();
            exp_item.exp_amount = 1;
            exp_item.player = player;
            Instantiate(deathParticle,transform.position,Quaternion.identity);
            game_data.kill_enemy ++;
            AudioManager.Instance.PlaySoundOneShot(killed_SE);
            Destroy(this.gameObject);
        }
    }
}
