using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public gameData game_data;
    public long bullet_speed = 3;
    public GameObject game_player;
    public Vector3 now_palyer_position;
    public Vector3 normalizedDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //プレイヤーの位置の計算
        now_palyer_position = game_player.transform.position;
        Vector3 direction = now_palyer_position - transform.position;
        direction.z = 0f;
        normalizedDirection = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += normalizedDirection * bullet_speed * Time.deltaTime;
        if(game_data.is_boss == false)
        {
            Destroy (this.gameObject);
        }
        if(transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy (this.gameObject);
        }
    }
}
