using UnityEngine;

public class DebugCameraShake : MonoBehaviour
{
    public CameraAction cameraAction;
    public float duration;
    public float magnitude;
    public void shake()
    {
        cameraAction.Shake(duration,magnitude);
    }
}
