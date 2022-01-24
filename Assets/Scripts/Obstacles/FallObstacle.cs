using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObstacle : MonoBehaviour
{

    [SerializeField]
    private GameObject red;



    [SerializeField]
    private float falling_time = 2f;

    void Start()
    {
        red.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(fall_Time(falling_time));
        }
    }

    private IEnumerator fall_Time(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        red.SetActive(true);
    }
}
