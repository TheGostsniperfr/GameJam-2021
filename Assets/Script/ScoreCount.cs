using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public int scoreCount;
    public Text scoreCountDisplay;
    public Text GMscoreCountDisplay;

    public void addScore(int score)
    {
        scoreCount += score;
        scoreCountDisplay.text = scoreCount.ToString();
        GMscoreCountDisplay.text = scoreCount.ToString();
    }
}
