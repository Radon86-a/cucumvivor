using UnityEngine;

public class Player : MonoBehaviour
{
    public pleyerData playerData;
    public long HP, attack, speed, attack_cooltime;

    private float attack_timer = 0.0f;
    private Rigidbody2D rb;

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
        Move();
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
        attack_timer += Time.deltaTime * attack_cooltime;
        if(attack_timer < 1.0f)
        {
            return;
        }
        attack_timer = 0.0f;
        //ここに攻撃処理を書く
    }
}
