using UnityEngine;

public class expItem : MonoBehaviour
{
    public GameObject player;
    public long exp_amount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = player.transform.position - transform.position;
        if(direction.x * direction.x + direction.y * direction.y < 2.5)
        {
        direction.z = 0f;
        Vector3 normalizedDirection = direction.normalized;
        transform.position += normalizedDirection * 2.0f * Time.deltaTime;
        }else
        {
            transform.Translate(-2.0f * Time.deltaTime, 0, 0f); 
        }
        if(transform.position.x < -10)
        {
            Destroy (this.gameObject);
        }
    }
}
