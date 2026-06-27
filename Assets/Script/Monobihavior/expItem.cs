using UnityEngine;

public class expItem : MonoBehaviour
{
    public long exp_amount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-2.0f * Time.deltaTime, 0, 0f); 
        float x = transform.position.x;
        if(x < -10)
        {
            Destroy (this.gameObject);
        }
    }
}
