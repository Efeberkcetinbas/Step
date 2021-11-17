using DG.Tweening;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    private MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("green"))
        {
            Debug.Log("Greendeyiz");
            mr.material.DOColor(Color.green,0.2f);
        }
        else if (collision.gameObject.CompareTag("red"))
        {
            Debug.Log("Reddeyiz");
            mr.material.DOColor(Color.red, 0.2f);
        }
    }
}
