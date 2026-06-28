using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    public GameObject result;
    public TextMeshProUGUI killText;
    public TextMeshProUGUI scoreText;
    public gameData game_data;
    void Start()
    {
        result.SetActive(false);
    }
    public void ShowResult()
    {
        game_data.is_gaming = false;
        result.SetActive(true);
        killText.text = "撃破数:" + game_data.kill_enemy;
        scoreText.text = "スコア:" + game_data.score;
        Time.timeScale = 0f;
    }
}
