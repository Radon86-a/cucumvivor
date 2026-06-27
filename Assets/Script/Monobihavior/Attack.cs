using UnityEngine;
using TMPro;
public class Attack : MonoBehaviour
{
    //味方の攻撃か敵の攻撃か
    
    public bool isEnemyAttack = false;

    //ダメージ量
    public long damageAmount = 0;
    public float cooltime = 0.0f;
    private float lastAttackTime = 0.0f;
    //ダメージのタイプ
    //攻撃時に消える/持続ダメージ
    public bool disappearOnAttack = true;

    
    float nowtime = 0.0f;
    public DamagePopup dp;
    void Start()
    {
        dp = GetComponent<DamagePopup>();
        if(dp!=null)dp.ImMaster = true;
    }



    //攻撃の当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //敵の攻撃か味方の攻撃かで判定
        if(isEnemyAttack)
        {
            // 敵の攻撃の場合、プレイヤーに当たったらダメージを与える
            if(collision.CompareTag("Player"))
            {
                if(nowtime - lastAttackTime < cooltime)
                {
                    return;
                }
                lastAttackTime = nowtime;
                Player player = collision.GetComponent<Player>();
                if(player != null)
                {
                    player.HP -= damageAmount;
                    if(disappearOnAttack)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
        else
        {
            // 味方の攻撃の場合、敵に当たったらダメージを与える
            if(collision.CompareTag("Enemy"))
            {
                if(nowtime - lastAttackTime < cooltime)
                {
                    return;
                }
                lastAttackTime = nowtime;
                enemy enemy = collision.GetComponent<enemy>();
                if(enemy != null)
                {
                    enemy.my_HP -= damageAmount;
                    if(dp!=null)dp.showDamage(damageAmount, enemy.transform.position);
                    if(disappearOnAttack)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    //ダメージ表示部分
    private void Update()
    {
        //変なところにいたら消去
        if(transform.position.x > 20 || transform.position.x < -20 || transform.position.y > 20 || transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

}
