using UnityEngine;

public class FirstCode : MonoBehaviour
{
    public Transform ballTransform;
    public Rigidbody ballRigidbody;
    public Transform aimTransform;
    public int throwForce;
    public bool blockInput;
    public AudioSource rollingBallAudio;

    void Start()
    {

    }

    void Update()
    {
        if (blockInput)
        {
            return;
        }

        if (ballTransform.position.x > -0.45f)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ballTransform.Translate(-Time.deltaTime, 0, 0);
            }
        }

        if (ballTransform.position.x < 0.45f)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                ballTransform.Translate(Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rollingBallAudio.Play();
            blockInput = true;
            ballRigidbody.AddForce(aimTransform.forward * throwForce);
            aimTransform.gameObject.SetActive(false);
            Invoke("BallReachTheEnd", 15);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ball is about to respawn");

        Invoke("BallReachTheEnd", 4);
    }

    void BallReachTheEnd()
    {
        //////
        FindAnyObjectByType<GameManager>().CalculateScore();
        Destroy(gameObject);
    }
}
