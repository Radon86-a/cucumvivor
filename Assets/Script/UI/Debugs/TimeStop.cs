using UnityEngine;

public class TimeStop : MonoBehaviour
{
    private bool isstop;
    public void TimeToggle()
    {
        if (isstop)
        {
            Time.timeScale = 1f;
            isstop = false;
        }
        else
        {
            isstop = true;
            Time.timeScale = 0f;
        }
    }
}
