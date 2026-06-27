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
        killText.text = "撃破数:" + game_data.kill_enemy;
    }
    public void ShowResult()
    {
        result.SetActive(true);
        Time.timeScale = 0f;
    }
}
