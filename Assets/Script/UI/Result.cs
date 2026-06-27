using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    public GameObject result;
    public TextMeshProUGUI killText;
    public gameData game_data;
    void Start()
    {
        result.SetActive(false);
    }
    public void ShowResult()
    {
        result.SetActive(true);
        killText.text = "撃破数:" + game_data.kill_enemy;
        Time.timeScale = 0f;
    }
}
