using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArmControl : MonoBehaviour
{

    private InputManager _input;
    private CollisionDetection _collision;


    private void Awake()
    {
        _collision = FindObjectOfType<CollisionDetection>();
        _input = FindObjectOfType<InputManager>();
    }

    private void Start()
    {
        transform.DOScaleY(1.4f, 0.2f).OnComplete(() => transform.DOScaleY(1f, 0.2f)).SetLoops(-1,LoopType.Yoyo);
    }
    
     /*private void Update()
     {
         //Hatayı alıyorum dotween. Maxtweens Reached hatası. Update'de tween çağırıldığında çok obje görüyor.
         if (_input.is_Moving == true)
         {
             transform.DOScaleY(1.4f, 0.2f).OnComplete(() => transform.DOScaleY(1f, 0.2f));
             //Burada hatalıyım.
         }
     }*/
}
