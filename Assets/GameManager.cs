using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;

    public Pin[] allPins;
    public int score;
    public int totalScore;

    public int throwCounter;
    public int frameCounter;

    public GameObject gameOverScreen;

    public UIFrame[] allUIFrames;


    void Start()
    {
        Instantiate(ballPrefab);

        int temporaryCounter = 1;

        foreach(UIFrame x in allUIFrames)
        {
            x.frameNumber.text = temporaryCounter.ToString();
            temporaryCounter += 1;

            x.firstThrowScore.text = "";
            x.secondThrowScore.text = "";
            x.totalScore.text = "";
        }
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
            totalScore += score;
        }

        Instantiate(ballPrefab);

        if(frameCounter == 10)
        {
            gameOverScreen.SetActive(true);
        }
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
