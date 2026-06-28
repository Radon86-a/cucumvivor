using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public AudioClip click_SE;
    public void ChangeScene(string sceneName)
    {
        AudioManager.Instance.PlaySoundOneShot(click_SE);
        SceneManager.LoadScene(sceneName);
    }
}