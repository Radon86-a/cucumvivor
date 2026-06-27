using UnityEngine;

public class Attack : MonoBehaviour
{
    //味方の攻撃か敵の攻撃か
    bool isEnemyAttack = false;

    //ダメージ量
    public long damageAmount = 0;
    public float cooltime = 0.0f;
    private float lastAttackTime = 0.0f;
    //ダメージのタイプ
    //攻撃時に消える/持続ダメージ
    public bool disappearOnAttack = true;

    //移動タイプ
    //- 0:プレイヤー追従型　プレイヤーの周りを回る
    // - 1:近距離攻撃
    // - 2:遠距離に固定の方向に弾を飛ばす（右方向）
    // - 3:近距離の敵に自動で照準
    // - 4:持続攻撃
    public int moveType = 0;
    //ターゲットのTransform
    public Transform targetTransform = null;
    //親の位置
    public Transform parentTransform = null;
    

    //攻撃の移動ベクトル
    public Vector2 moveVector = Vector2.zero;
    
    float nowtime = 0.0f;
    void Start()
    {
        
    }

    void Update()
    {
        nowtime += Time.deltaTime;
        switch(moveType)
        {
            case 0:
                //追従型
                //Parentの周りを円形に回転
                Transform parent = parentTransform;
                if(parent != null)
                {
                    float radius = 1.0f; // 回転半径
                    float speed = 2.0f; // 回転速度
                    float angle = nowtime * speed; // 現在の角度
                    Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
                    transform.position = parent.position + offset;
                }
                break;
            case 1:
                //近距離攻撃
                break;
            case 2:
                //遠距離に固定の方向に弾を飛ばす（右方向）
                transform.position += (Vector3)moveVector * Time.deltaTime;
                break;
            case 3:
                //近距離の敵に自動で照準
                break;
            case 4:
                //持続攻撃
                break;
        }
    }

    //攻撃の当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(nowtime - lastAttackTime < cooltime)
        {
            return;
        }
        lastAttackTime = nowtime;
        //敵の攻撃か味方の攻撃かで判定
        if(isEnemyAttack)
        {
            //敵の攻撃の場合、プレイヤーに当たったらダメージを与える
            // if(collision.CompareTag("Player"))
            // {
            //     Player player = collision.GetComponent<Player>();
            //     if(player != null)
            //     {
            //         player.hp -= damageAmount;
            //         if(disappearOnAttack)
            //         {
            //             Destroy(gameObject);
            //         }
            //     }
            // }
        }
        else
        {
            //味方の攻撃の場合、敵に当たったらダメージを与える
            // if(collision.CompareTag("Enemy"))
            // {
            //     Enemy enemy = collision.GetComponent<Enemy>();
            //     if(enemy != null)
            //     {
            //         player.hp -= damageAmount;
            //         if(disappearOnAttack)
            //         {
            //             Destroy(gameObject);
            //         }
            //     }
            // }
        }
    }


}
