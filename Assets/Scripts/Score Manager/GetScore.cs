using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GetScore : MonoBehaviour
{

    //public Text score_text;

    public Text score_text;

    public float duration;


    private void Start()
    {
        DOVirtual.Float(0f, ScoreManagement.instance.score, duration, OnValueUpdate);
    }

    void OnValueUpdate(float v)
    {
        score_text.text = Mathf.Floor(v).ToString();
    }

    /*void Update()
    {
       //Update satın almalarda kullanacağın zaman aktif edersin.
       score_text.text = ScoreManagement.instance.score.ToString();
    }*/
}
