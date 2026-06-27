using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player;
    public GameObject exp;
    public GameObject watermelon_bullet;
    public bossData boss_data;
    public gameData game_data;
    //カメラの取得
    public CameraAction cameraAction;
    public long boss_id;
    public long boss_my_HP;
    public long boss_my_attack;
    public long boss_my_speed;
    public float attack_cooltime;
    private SpriteRenderer myRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boss_id = game_data.now_boss_id;
        boss_my_HP = boss_data.bosses[boss_id].boss_HP * (game_data.gamephase + 1) * (game_data.gamephase + 1);
        boss_my_attack = boss_data.bosses[boss_id].boss_attack * (game_data.gamephase + 1) * (game_data.gamephase + 1);
        boss_my_speed = boss_data.bosses[boss_id].boss_speed;
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sprite = boss_data.bosses[boss_id].boss_skin;
        GetComponent<Attack>().damageAmount = boss_my_attack;
        GetComponent<Attack>().cameraAction = cameraAction;
        switch(game_data.now_boss_id)
        {
        case 0:
        
        break;
        case 1:
        attack_cooltime = 0.5f;
        break;
        case 2:
        
        break;
        case 3:
        
        break;
        default: break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        attack_cooltime -= Time.deltaTime;
        while(transform.position.x > 7)
        {
            transform.position += new Vector3 (1, 0, 0) * boss_my_speed * Time.deltaTime * (-1);
        }
        switch(game_data.now_boss_id)
        {
        case 0:
        
        break;
        case 1:
        if (attack_cooltime < 0)
            {
                GameObject clonedObject = Instantiate(watermelon_bullet, transform.position, Quaternion.identity);
                BossAttack boss_attack = clonedObject.GetComponent<BossAttack>();
                Attack attack = clonedObject.GetComponent<Attack>();
                attack.damageAmount = boss_my_attack;
                attack.cameraAction = cameraAction;
                boss_attack.game_player = player;
                attack_cooltime = 0.5f;
            }
        
        break;
        case 2:
        
        break;
        case 3:
        
        break;
        default: break;
        }

        if(boss_my_HP <= 0)
        {
            // 死亡時の処理
            GameObject clonedObject = Instantiate(exp, transform.position, Quaternion.identity);
            expItem exp_item = clonedObject.GetComponent<expItem>();
            exp_item.exp_amount = 10 * game_data.gamephase;
            game_data.gamephase ++;
            game_data.now_boss_id = UnityEngine.Random.Range(1, boss_data.bosses.Length);
            game_data.phase_time = 0f;
            game_data.is_boss = false;
            Destroy (this.gameObject);
        }
    }
}
