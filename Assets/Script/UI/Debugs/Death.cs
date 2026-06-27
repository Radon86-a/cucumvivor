using UnityEngine;

public class Death : MonoBehaviour
{
    public HPBar hPBar;
    public void doDeath()
    {
        hPBar.SetHP(0,10);
    }
}
