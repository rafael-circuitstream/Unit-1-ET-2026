using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool isKnockedDown;


    void Start()
    {
        
    }


    void Update()
    {
        Debug.Log(transform.rotation.eulerAngles);

        if( Vector3.Angle(Vector3.zero, transform.rotation.eulerAngles) > 15 )
        {
            isKnockedDown = true;
        }
    }
}
