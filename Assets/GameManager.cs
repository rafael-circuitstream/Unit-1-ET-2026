using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;

    public Pin[] allPins;
    public int score;

    void Start()
    {
        Instantiate(ballPrefab);

    }

    void Update()
    {

    }

    public void CalculateScore()
    {
        score = 0;

        foreach (Pin x in allPins)
        {
            if (x.isKnockedDown)
            {
                score += 1;
                x.gameObject.SetActive(false);
            }
        }

        Instantiate(ballPrefab);

    }
}
