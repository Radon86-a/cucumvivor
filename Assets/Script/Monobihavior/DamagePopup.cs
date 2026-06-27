using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float lifetime = 1.0f;
    private Vector3 moveVector = new Vector3(0, 2f, 0);

    [System.NonSerialized]
    public bool ImMaster = false;
    public void showDamage(long damage, Vector3 position)
    {
        position += new Vector3(Random.Range(-0.3f,0.3f), 0, 0);
        GameObject popup = new GameObject("DamagePopup");

        popup.transform.position = position;

        TextMeshPro tmp = popup.AddComponent<TextMeshPro>();
        tmp.text = damage.ToString();
        tmp.fontSize = 5;
        tmp.alignment = TextAlignmentOptions.Center;

        DamagePopup dp = popup.AddComponent<DamagePopup>();
        dp.textMesh = tmp;
    }
    void Update()
    {
        if(ImMaster == true)
        {
            return; 
        }
        transform.position += moveVector * Time.deltaTime;

        lifetime -= Time.deltaTime;

        Color color = textMesh.color;
        color.a = lifetime;
        textMesh.color = color;

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
