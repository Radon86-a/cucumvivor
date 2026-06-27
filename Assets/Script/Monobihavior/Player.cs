using UnityEngine;
using System.Collections.Generic;
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

    [Header("=== UI ===")]
    [SerializeField]
    public HPBar hpBar;
    public GameObject UIManager;
    public Weapon weaponUI;



    void Start()
    {
        //playerDataの値を取得して変数に代入
        HP = playerData.pleyer_max_HP;
        attack = playerData.pleyer_attack;
        speed = playerData.pleyer_speed;
        attack_cooltime = playerData.pleyer_attack_cooltime;
        rb = GetComponent<Rigidbody2D>();
        weaponUI.SetAll();
    }

    void FixedUpdate()
    {
		nowtime += Time.deltaTime;
        Move();
        playerAttack();
    }
    void Update()
    {
        hpBar.SetHP(HP, playerData.pleyer_max_HP);
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
						if(weapon_objects[i].obj != null)
						{
							for(long j = 0; j < weapon_objects[i].obj.Length; j++)
							{
								if(weapon_objects[i].obj[j] != null)
								{
									Destroy(weapon_objects[i].obj[j]);
								}
							}
						}
						//weapon_levels[i]の数だけGameObjectを生成してweapon_objects[i].objに格納
						weapon_objects[i].obj = new GameObject[weapon_levels[i]];
					}
                    for(long j = 0; j < weapon_levels[i]; j++)
                    {
                        if (weapon_objects[i].obj[j] == null)
                        {
                            weapon_objects[i].obj[j] = Instantiate(weapons[i].weapon_prefab, this.transform.position, Quaternion.identity);
                        }
                        weapon_objects[i].obj[j].GetComponent<Attack>().damageAmount = attack * weapons[i].weapon_attack;
                        weapon_objects[i].obj[j].SetActive(true);
                        Transform parent = this.transform;
						float radius = 1.0f; // 回転半径
						float speed = 2.0f; // 回転速度
						float angle = nowtime * speed + j*(2*(3.141592653589f))/(weapon_levels[i]); // 現在の角度
						Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
						weapon_objects[i].obj[j].transform.position = parent.position + offset;
                    }
                    //Parentの周りを円形に回転
                    break;
                
                case 1:
                    //近距離攻撃
                    if(weapon_objects[i].obj== null || weapon_objects[i].obj.Length != weapon_levels[i])
					{
						if(weapon_objects[i].obj != null)
						{
							for(long j = 0; j < weapon_objects[i].obj.Length; j++)
							{
								if(weapon_objects[i].obj[j] != null)
								{
									Destroy(weapon_objects[i].obj[j]);
								}
							}
						}
						//weapon_levels[i]の数だけGameObjectを生成してweapon_objects[i].objに格納
						weapon_objects[i].obj = new GameObject[weapon_levels[i]];
					}
                    for(long j = 0; j < 1; j++)
                    {
                        if (weapon_objects[i].obj[j] == null)
                        {
                            weapon_objects[i].obj[j] = Instantiate(weapons[i].weapon_prefab, this.transform.position, Quaternion.identity);
                        }
                        weapon_objects[i].obj[j].GetComponent<Attack>().damageAmount = attack * weapons[i].weapon_attack;
                        weapon_objects[i].obj[j].SetActive(true);
                        Transform parent = this.transform;

                        //Phisics2D.OverLapCIrcleAllで近距離の敵を取得してそっちの向きに攻撃オブジェクトを動かす
                        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(parent.position, 2f);
                        foreach (var hitCollider in hitColliders)
                        {
                            if (hitCollider.CompareTag("Enemy"))
                            {
                                Vector3 direction = (hitCollider.transform.position - parent.position).normalized;
                                weapon_objects[i].obj[j].transform.position = parent.position + direction;
                                break;
                            }
                        }


						// float radius = 1.0f; // 回転半径
						// float speed = 2.0f; // 回転速度
						// float angle = nowtime * speed + j*(2*(3.141592653589f))/(weapon_levels[i]); // 現在の角度
						// Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
						// weapon_objects[i].obj[j].transform.position = parent.position + offset;
                    }
                    break;
                case 2:
                    //遠距離に固定の方向に弾を飛ばす（右方向）
                    // transform.position += (Vector3)moveVector * Time.deltaTime;
                    if(weapon_objects[i].obj== null || weapon_objects[i].obj.Length != weapon_levels[i])
					{
						if(weapon_objects[i].obj != null)
						{
							for(long j = 0; j < weapon_objects[i].obj.Length; j++)
							{
								if(weapon_objects[i].obj[j] != null)
								{
									Destroy(weapon_objects[i].obj[j]);
								}
							}
						}
						//weapon_levels[i]の数だけGameObjectを生成してweapon_objects[i].objに格納
						weapon_objects[i].obj = new GameObject[weapon_levels[i]];
					}
                    for(long j = 0; j < 1; j++)
                    {
                        if (weapon_objects[i].obj[j] == null)
                        {
                            weapon_objects[i].obj[j] = Instantiate(weapons[i].weapon_prefab, this.transform.position, Quaternion.identity);
                        }
                        weapon_objects[i].obj[j].GetComponent<Attack>().damageAmount = attack * weapons[i].weapon_attack;
                        weapon_objects[i].obj[j].SetActive(true);
                        Transform parent = this.transform;

                        //右方向に加速度を与える
                        weapon_objects[i].obj[j].GetComponent<Rigidbody2D>().linearVelocity = new Vector2(5f, 0f);
                        //右に行ったら消す
                        if(weapon_objects[i].obj[j].transform.position.x > 10f)
                        {
                            Destroy(weapon_objects[i].obj[j]);
                        }
                    }
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
                UIManager.GetComponent<SelectUpgrade>().ShowSelectUI(weapon_data.weapons);
			}
			Destroy(other.gameObject);
		}
	}
}
