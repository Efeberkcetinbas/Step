using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlarmClockManager : MonoBehaviour
{

    public Text time_text;

    private float timer;

    [SerializeField] private int timer_int;



    private void Start()
    {
        timer = timer_int;
    }

    private void Update()
    {
        time_text.text = timer_int.ToString();

        if (FindObjectOfType<CollisionDetection>().game_is_Stop == false)
        {
            if (timer > 0)
            {
                Timer_CountDown();
            }
            else
            {
                Timer_Reset();
                Debug.Log("Time's UP!!!!!!");
                //FindObjectOfType<FailedManager>().open_Failed_Panel();
            }
        }

        
    }

    void Timer_CountDown()
    {
        timer -= Time.deltaTime;
        timer_int = (int)timer;

    }

    void Timer_Reset()
    {
        timer = 0f;
    }
}
