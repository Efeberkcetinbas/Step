using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LightsClosing : MonoBehaviour
{
    [SerializeField] private float turn_dark_speed;

    void Start()
    {
        gameObject.GetComponent<Image>().DOFade(1f, turn_dark_speed);
    }

    

}
