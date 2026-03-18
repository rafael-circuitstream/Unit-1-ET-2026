using UnityEngine;
using TMPro;

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
    public TextMeshProUGUI finalScoreText;

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

        int lastScore = score;

        score = 0;

        foreach (Pin x in allPins)
        {
            if (x.isKnockedDown)
            {
                score += 1;
                x.gameObject.SetActive(false);
            }
        }

        if (throwCounter == 1)
        {
            allUIFrames[frameCounter].firstThrowScore.text = score.ToString();
        }

        if(throwCounter == 2)
        {
            allUIFrames[frameCounter].secondThrowScore.text = (score - lastScore).ToString();
        }

        if (score == 10)
        {
            if (throwCounter == 2)
            {
                Debug.Log("SPARE!");
                allUIFrames[frameCounter].secondThrowScore.text = "/";
            }

            if (throwCounter == 1)
            {
                throwCounter = 2;
                Debug.Log("STRIKE!");
                allUIFrames[frameCounter].firstThrowScore.text = "";
                allUIFrames[frameCounter].secondThrowScore.text = "X";
            }
        }

        if(throwCounter == 2)
        {
            totalScore += score;
            allUIFrames[frameCounter].totalScore.text = totalScore.ToString();
            throwCounter = 0;
            ResetPins();
            frameCounter += 1;
            
        }

        Instantiate(ballPrefab);

        if(frameCounter == 10)
        {
            gameOverScreen.SetActive(true);
            finalScoreText.text = totalScore.ToString();
        }
    }


    void ResetPins()
    {
        foreach(Pin x in allPins)
        {
            x.gameObject.SetActive(true);
            x.isKnockedDown = false;
            x.transform.position = x.originalPosition;
            x.transform.eulerAngles = Vector3.zero;

        }
    }
}
