using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public static ScoreManagement instance { get; private set; }

    public int score;

    public bool delete;


    private void Awake()
    {

        score = PlayerPrefs.GetInt("Score");

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        if (delete)
            PlayerPrefs.DeleteAll();
    }

    /*public int score_increase_point(int point)
    {
        return score += point;
    }*/

    public void score_increase(int point)
    {
        score += point;
        //score += PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", score);
    }

    
}
