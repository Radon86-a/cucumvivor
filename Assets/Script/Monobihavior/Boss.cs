using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player;
    public long boss_my_HP;
    public GameObject exp;
    public bossData boss_data;
    public gameData game_data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boss_my_HP <= 0)
        {
            // 死亡時の処理
            GameObject clonedObject = Instantiate(exp, transform.position, Quaternion.identity);
            expItem exp_item = clonedObject.GetComponent<expItem>();
            exp_item.exp_amount = 1;
            Destroy (this.gameObject);
        }
    }
}
