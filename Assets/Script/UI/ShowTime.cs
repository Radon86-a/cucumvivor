using UnityEngine;
using TMPro;

public class ShowTime : MonoBehaviour
{
    public TMP_Text timetext;
    public gameData gameData;
    void Update()
    {
        timetext.text = gameData.game_time.ToString("F2") + "sec";
    }
}
