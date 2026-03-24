using UnityEngine;

public class CameraChangeTrigger : MonoBehaviour
{
    public GameObject closeUpCamera;

    void OnTriggerEnter(Collider other)
    {
        closeUpCamera.SetActive(true);
        Invoke("HideCloseUpCamera", 4f);
    }

    void HideCloseUpCamera()
    {
        closeUpCamera.SetActive(false);
    }
}
