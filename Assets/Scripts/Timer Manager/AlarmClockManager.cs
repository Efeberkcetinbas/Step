﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlarmClockManager : MonoBehaviour
{
    [SerializeField]
    private Text time_text;


    //Timerları textMesh yaptığın zaman bu yapıyı kullan.
    /*[SerializeField]
    private TextMeshProUGUI time_textMesh;*/

    private float timer;

    public int timer_int;



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
            }
        }
    }


    //Sadece zaman akışı kod.
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
