using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("=== ステータス ===")]
    public pleyerData playerData;
    public long HP, attack, speed, attack_cooltime;

    private float attack_timer = 0.0f;
    private Rigidbody2D rb;

	[Header("=== 武器 ===")]
    [SerializeField]
	weaponData weapon_data;
    public long weapon_count = 0;
    public long[] weapon_levels = new long[10];
    public Weapons[] weapons = new Weapons[10];
    //武器のオブジェクト（二次元動的配列）
	public Weaponobj[] weapon_objects = new Weaponobj[10];
	public struct Weaponobj
	{
		public GameObject[] obj;
	};
	float nowtime = 0.0f;

	[Header("=== レベルとexp ===")]
	public long player_level = 1;
	public long player_exp = 0;


    void Start()
    {
        //playerDataの値を取得して変数に代入
        HP = playerData.pleyer_max_HP;
        attack = playerData.pleyer_attack;
        speed = playerData.pleyer_speed;
        attack_cooltime = playerData.pleyer_attack_cooltime;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
		nowtime += Time.deltaTime;
        Move();
        playerAttack();
    }

    //プレイヤーの移動
    void Move()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + new Vector2(moveX, moveY) * speed * Time.deltaTime);

    }


    void playerAttack()
    {
        // attack_timer += Time.deltaTime * attack_cooltime;
        // if(attack_timer < 1.0f)
        // {
        //     return;
        // }
        // attack_timer = 0.0f;
        //ここに攻撃処理を書く
        for(long i = 0; i < weapon_count; i++)
        {
			if(weapons[i].weapon_prefab == null)
			{
				weapons[i] = weapon_data.weapons[i];
			}
            switch(weapons[i].weapon_attack_id)
            {
                case 0:
                    //追従型
					if(weapon_objects[i].obj== null || weapon_objects[i].obj.Length != weapon_levels[i])
					{
						//weapon_levels[i]の数だけGameObjectを生成してweapon_objects[i].objに格納
						weapon_objects[i].obj = new GameObject[weapon_levels[i]];
					}
                    for(long j = 0; j < weapon_levels[i]; j++)
                    {
                        if (weapon_objects[i].obj[j] == null)
                        {
                            weapon_objects[i].obj[j] = Instantiate(weapons[i].weapon_prefab, this.transform.position, Quaternion.identity);                        
                        }
                        weapon_objects[i].obj[j].SetActive(true);
                        Transform parent = this.transform;
						float radius = 1.0f; // 回転半径
						float speed = 2.0f; // 回転速度
						float angle = nowtime * speed; // 現在の角度
						Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
						weapon_objects[i].obj[j].transform.position = parent.position + offset;
                    }
                    //Parentの周りを円形に回転
                    break;
                case 1:
                    //近距離攻撃
                    break;
                case 2:
                    //遠距離に固定の方向に弾を飛ばす（右方向）
                    // transform.position += (Vector3)moveVector * Time.deltaTime;
                    break;
                case 3:
                    //近距離の敵に自動で照準
                    break;
                case 4:
                    //持続攻撃
                    break;
        
            }
        }
    }

	//EXPを拾う
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("EXP"))
		{
			player_exp += other.gameObject.GetComponent<expItem>().exp_amount;
			if(player_exp >= player_level * 10)
			{
				player_exp -= player_level * 10;
				player_level++;
				//レベルアップ時の処理
				//ここでUIを呼ぶ
			}
			Destroy(other.gameObject);
		}
	}
}
