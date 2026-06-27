using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject result;
    void Start()
    {
        result.SetActive(false);
    }
    public void ShowResult()
    {
        result.SetActive(true);
    }
}
