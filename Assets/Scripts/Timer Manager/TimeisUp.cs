using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeisUp : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Timer(FindObjectOfType<AlarmClockManager>().timer_int));
    }

    void Update()
    {
        if (FindObjectOfType<CollisionDetection>().game_is_Stop == true)
        {
            StopAllCoroutines();

            //İşe yaramadı.
            //StopCoroutine(Timer(FindObjectOfType<AlarmClockManager>().timer_int));
        }
    }

    //AlarmClockManagerdaki timerimizi buradaki time'a eşitliyoruz. Bu sayede alarmClockManager sadece kalan zamanı gösterirken aslında caroutine ile burada zamanın azaldığına bakıyoruz.
    IEnumerator Timer(int time)
    {
        yield return new WaitForSeconds(time);
        FailedManager.instance.open_Failed_Panel();
    }


}
