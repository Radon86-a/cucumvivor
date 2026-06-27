using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public GameObject xpBar;
    private Slider slider;
    private long currentXP = 1;
    private long maxXP = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = xpBar.GetComponent<Slider>();
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = maxXP;
        slider.value = currentXP;
    }
    public void SetXP(long currentXP, long maxXP)
    {
        if (currentXP > maxXP)
        {
            currentXP = maxXP;
        }
        if (currentXP <= 0)
        {
            currentXP = 0;
        }
        if (maxXP <= 0)
        {
            maxXP = 1;
        }
        this.currentXP = currentXP;
        this.maxXP = maxXP;
    }
}
