using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;
public class Player : MonoBehaviour
{
	[Header("=== ステータス ===")]
    public pleyerData playerData;
    public long HP, attack,max_HP;
    public float attack_freq,speed;

    private Rigidbody2D rb;

	[Header("=== 武器 ===")]
    [SerializeField]
	weaponData weapon_data;
    public long weapon_count = 0;
    public long[] weapon_levels = new long[10];
    public Weapons[] weapons = new Weapons[10];
    private float[] weapon_cooltimes = new float[10];
    private float[] weapon_lastAttackTimes = new float[10];
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
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI speedText;

    [Header("=== SE ===")]
    public AudioClip get_SE;
    
    PlayerInputActions _playerMoveInput;

    private Vector2 moveVector,moveVector2;

    void Start()
    {
        //playerDataの値を取得して変数に代入
        max_HP = HP = playerData.pleyer_max_HP;
        attack = playerData.pleyer_attack;
        speed = playerData.pleyer_speed;
        attack_freq = playerData.pleyer_attack_freq;
        rb = GetComponent<Rigidbody2D>();
        weapons[0] = weapon_data.weapons[0]; // 初期装備の設定
        weaponUI.SetAll();
        _playerMoveInput = new PlayerInputActions();
        _playerMoveInput.Player.Move.performed += OnInputMove;
        _playerMoveInput.Player.Move.canceled += OnInputMove;
        _playerMoveInput.Player.Move.started += OnInputMove;
        _playerMoveInput.Player.Enable();
        for(int i = 0; i < 10; i++)
        {
            weapon_cooltimes[i] = 1.0f;
        }
    }

    private void OnInputMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
		nowtime += Time.deltaTime * attack_freq;
        Move();
        playerAttack();
    }
    void Update()
    {
        attackText.text = "atk:" + attack;
        speedText.text = "spe:" + speed;
        hpBar.SetHP(HP, playerData.pleyer_max_HP);
        moveVector2 = Vector2.MoveTowards(moveVector2, moveVector, Time.deltaTime * 10f);
        //-9~9,-5~5に移動を制限
        if(transform.position.x < -9)
        {
            transform.position = new Vector3(-9, transform.position.y, transform.position.z);
        }
        if(transform.position.x > 9)
        {
            transform.position = new Vector3(9, transform.position.y, transform.position.z);
        }
        if(transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, -5, transform.position.z);
        }
        if(transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
    }

    //プレイヤーの移動
    void Move()
    {

        rb.MovePosition(rb.position + moveVector2 * speed * Time.deltaTime);
        //画面外に行ったら戻す
    }

    /*
    void playerAttack()
    {
        Transform parent = this.transform;
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
                    {
                        
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
                        SpriteRenderer targetRenderer0 = weapon_objects[i].obj[j].GetComponent<SpriteRenderer>();
                        targetRenderer0.sprite = weapons[i].weapon_skin;
                        weapon_objects[i].obj[j].GetComponent<Attack>().damageAmount = attack * weapons[i].weapon_attack;
                        weapon_objects[i].obj[j].SetActive(true);
						float radius = 1.0f; // 回転半径
						float speed = 2.0f; // 回転速度
						float angle = nowtime * speed + j*(2*(3.141592653589f))/(weapon_levels[i]); // 現在の角度
						Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
						weapon_objects[i].obj[j].transform.position = parent.position + offset;
                    }
                    //Parentの周りを円形に回転
                    }break;                
                case 1:
                {
                        
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
                        SpriteRenderer targetRenderer1 = weapon_objects[i].obj[j].GetComponent<SpriteRenderer>();
                        targetRenderer1.sprite = weapons[i].weapon_skin;
                        weapon_objects[i].obj[j].GetComponent<Attack>().damageAmount = attack * weapons[i].weapon_attack;
                        weapon_objects[i].obj[j].SetActive(true);
                        parent = this.transform;

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
                }break;
                case 2:
                    //時間が経過していたら実行
                    if(nowtime - weapon_lastAttackTimes[i] < weapon_cooltimes[i])
                    {
                        return;
                    }
                    weapon_lastAttackTimes[i] = nowtime;
                    var newbullet = Instantiate(weapons[i].weapon_prefab, this.transform.position, Quaternion.identity);
                    SpriteRenderer targetRenderer = newbullet.GetComponent<SpriteRenderer>();
                    targetRenderer.sprite = weapons[i].weapon_skin;
                    newbullet.GetComponent<Attack>().damageAmount = attack * weapons[i].weapon_attack;

                    //右方向に加速度を与える
                    newbullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(5f, 0f);
                    break;
                case 3:
                    //近距離の敵に自動で照準
                    if(nowtime - weapon_lastAttackTimes[i] < weapon_cooltimes[i])
                    {
                        return;
                    }
                    weapon_lastAttackTimes[i] = nowtime;
                    var newbullet2 = Instantiate(weapons[i].weapon_prefab, this.transform.position, Quaternion.identity);
                    SpriteRenderer targetRenderer3 = newbullet2.GetComponent<SpriteRenderer>();
                    targetRenderer3.sprite = weapons[i].weapon_skin;
                    newbullet2.GetComponent<Attack>().damageAmount = attack * weapons[i].weapon_attack;

                    //右方向に加速度を与える
                    Collider2D[] hitColliders2 = Physics2D.OverlapCircleAll(parent.position, 2f);
                    newbullet2.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(5f, 0f);
                    foreach (var hitCollider in hitColliders2)
                    {

                        if (hitCollider.CompareTag("Enemy"))
                        {
                            Vector3 direction = (hitCollider.transform.position - parent.position).normalized;
                            newbullet2.GetComponent<Rigidbody2D>().linearVelocity = direction * 5f;
                            break;
                        }
                    }
                    break;
                case 4:
                    //持続攻撃
                    break;
        
            }
        }
    }
    */


	//EXPを拾う
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("EXP"))
		{
            AudioManager.Instance.PlaySoundOneShot(get_SE);
			player_exp += other.gameObject.GetComponent<expItem>().exp_amount;
			if(player_exp >= player_level * 5)
			{
				player_exp -= player_level * 5;
				player_level++;
				//レベルアップ時の処理
				//ここでUIを呼ぶ
                UIManager.GetComponent<SelectUpgrade>().ShowSelectUI(weapon_data.weapons);
			}
            //経験値バーに反映
            UIManager.GetComponent<XPBar>().SetXP(player_exp,player_level * 5);
            
			Destroy(other.gameObject);
		}
	}
}
