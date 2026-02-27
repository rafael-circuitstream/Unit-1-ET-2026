using UnityEngine;

public class FirstCode : MonoBehaviour
{
    public Transform ballTransform;
    public Rigidbody ballRigidbody;
    public Transform aimTransform;
    public int throwForce;

    void Start()
    {
        
    }

    void Update()
    {
        if(ballTransform.position.x > -0.45f)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ballTransform.Translate(-Time.deltaTime, 0, 0);
            }
        }

        if(ballTransform.position.x < 0.45f)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                ballTransform.Translate(Time.deltaTime, 0, 0);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ballRigidbody.AddForce( aimTransform.forward * throwForce );
            aimTransform.gameObject.SetActive(false);

        }

    }
}
