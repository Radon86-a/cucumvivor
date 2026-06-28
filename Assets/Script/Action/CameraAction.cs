using UnityEngine;
using System.Collections;

public class CameraAction : MonoBehaviour
{
    public GameObject camera;
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }
    public void HitStop(float duration)
    {
        StartCoroutine(HitStopCoroutine(duration));
    }
    public void Flash(SpriteRenderer sr)
    {
        StartCoroutine(FlashCoroutine(sr));
    }

    IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;

            camera.transform.localPosition = new Vector3(x, y, -10);

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        camera.transform.localPosition = new Vector3(0,0,-10);
    }
    IEnumerator HitStopCoroutine(float duration)
    {
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = 1;
    }
    IEnumerator FlashCoroutine(SpriteRenderer sr)
    {
        for (int i = 0; i < 5; i++)
        {
            if (sr == null)break;
            sr.enabled = false;
            yield return new WaitForSeconds(0.05f);

            if (sr == null)break;
            sr.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
