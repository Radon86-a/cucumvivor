using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    public GameObject audioManager;
    void Awake()
    {
        audioManager = GameObject.Find("AudioManager");
    }
    public void changeVolume()
    {
        audioManager.GetComponent<AudioSource>().volume 
            = this.gameObject.GetComponent<Slider>().value;
    }
}
