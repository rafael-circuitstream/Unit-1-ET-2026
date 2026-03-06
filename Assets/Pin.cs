using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool isKnockedDown;


    void Start()
    {
        
    }


    void Update()
    {
        if( Vector3.Angle( transform.up , Vector3.up) > 15 )
        {
            isKnockedDown = true;
        }
    }
}
