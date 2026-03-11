using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;

    public Pin[] allPins;
    public int score;
    public int throwCounter;
    public int frameCounter;

    void Start()
    {
        Instantiate(ballPrefab);
        
    }

    void Update()
    {

    }

    public void CalculateScore()
    {
        throwCounter += 1; 
        score = 0;

        foreach (Pin x in allPins)
        {
            if (x.isKnockedDown)
            {
                score += 1;               
                x.gameObject.SetActive(false);
            }
        }

        if(score == 10)
        {
            if(throwCounter == 1)
            {
                throwCounter = 2;
                Debug.Log("STRIKE!");
            }

            if(throwCounter == 2)
            {
                Debug.Log("SPARE!");
            }

        }
      
        if(throwCounter == 2)
        {
            throwCounter = 0;
            ResetPins();
            frameCounter += 1;
        }


        Instantiate(ballPrefab);

    }


    void ResetPins()
    {
        foreach(Pin x in allPins)
        {
            x.gameObject.SetActive(true);

            x.transform.position = x.originalPosition;
            x.transform.eulerAngles = Vector3.zero;

        }
    }
}
