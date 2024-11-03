using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int score;
    public bool isLeaderboarding;

    [Header("Score Get Methods")]
    public Timer timer;

    private void Update()
    {
        if (timer != null)
        {
            score = (int)timer.time;
        }
    }

    public void AddScore(float change)
    {
        score += (int)change;
    }

    public void SetScore(float newScore)
    {
        score = (int)newScore;
    }
}
