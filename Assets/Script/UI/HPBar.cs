using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public GameObject hpBar;
    public float leftSpace = 10;
    public float rightSpace = 10;
    public float minWidth = 50;
    public float barY = -20;
    public Result result;
    private Slider slider;
    private RectTransform rect;
    private long currentHP = 1;
    private long maxHP = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = hpBar.GetComponent<Slider>();
        rect = hpBar.GetComponent<RectTransform>(); 
        rect.anchorMin = new Vector2(0, 1);
        rect.anchorMax = new Vector2(0, 1);
        rect.pivot = new Vector2(0, 0.5f);
        slider.value = 1;
        SetBarwidth(0);
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = maxHP;
        slider.value = currentHP;
        if(currentHP <= 0)
        {
            doDeath();
        }
    }
    public void SetHP(long currentHP, long maxHP)
    {
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        if (currentHP <= 0)
        {
            currentHP = 0;
        }
        if (maxHP <= 0)
        {
            maxHP = 1;
        }
        this.currentHP = currentHP;
        this.maxHP = maxHP;
    }
    public void SetBarwidth(float width)
    {
        float availablewidth = Screen.width - leftSpace - rightSpace;
        float finalwidth = Mathf.Min(width, availablewidth);
        finalwidth = Mathf.Max(width, minWidth);
        rect.anchoredPosition = new Vector2(leftSpace, barY);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, finalwidth);
    }

    void doDeath()
    {
        result.ShowResult();
    }

}
