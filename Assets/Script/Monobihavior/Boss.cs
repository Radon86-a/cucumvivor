using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player;
    public GameObject exp;
    public bossData boss_data;
    public gameData game_data;
    public long boss_id;
    public long boss_my_HP;
    public long boss_my_attack;
    public long boss_my_speed;
    private SpriteRenderer myRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boss_my_HP = boss_data.bosses[boss_id].boss_HP * (game_data.gamephase + 1) * (game_data.gamephase + 1);
        boss_my_attack = boss_data.bosses[boss_id].boss_attack * (game_data.gamephase + 1) * (game_data.gamephase + 1);
        boss_my_speed = boss_data.bosses[boss_id].boss_speed;
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sprite = boss_data.bosses[boss_id].boss_skin;
    }

    // Update is called once per frame
    void Update()
    {
        while(transform.position.x > 7)
        {
            transform.position += new Vector3 (1, 0, 0) * boss_my_speed * Time.deltaTime * (-1);
        }
        switch(game_data.now_boss_id)
        {
        case 0:
        
        break;
        case 1:
        
        break;
        default: break;
        }

        if(boss_my_HP <= 0)
        {
            // 死亡時の処理
            GameObject clonedObject = Instantiate(exp, transform.position, Quaternion.identity);
            expItem exp_item = clonedObject.GetComponent<expItem>();
            exp_item.exp_amount = 1;
            game_data.gamephase ++;
            Destroy (this.gameObject);
        }
    }
}
