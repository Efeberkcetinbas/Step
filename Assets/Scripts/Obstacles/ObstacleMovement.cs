using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{

    //DoTween instance null hatası almaya devam ediyorum. Çözüm getiremedim.


    [SerializeField]
    private float old_x, old_y, old_z, x, y, z;

    [SerializeField]
    private float duration;

    [SerializeField]
    private Ease setEase;

    private static ObstacleMovement instance { get; set; }
    //1.12.2021
    //Fakat singleton pattern kullandığım için tek bir obje oluşturuyorum. Yani obstacle movement koduna sahip sadece 1 objem sahnede olabiliyor. 

    private void Start()
    {

        //DontDestroyOnLoad sayesinde null hatası almıyorum. Check ettiğim için.
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
            Movement_Loop();
        }

        else
        {
            Destroy(gameObject);
        }

    }

    void Movement_Loop()
    {
        transform
            .DOMove(new Vector3(x, y, z), duration).OnComplete(() => transform.DOMove(new Vector3(old_x, old_y, old_z), duration))
            .SetEase(setEase)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DOTween.Kill(transform);
            Debug.Log("Player'a çarptık");
        }
    }
}
