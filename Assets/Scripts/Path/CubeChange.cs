using UnityEngine;
using DG.Tweening;

public class CubeChange : MonoBehaviour
{

    public bool is_Green;

    [SerializeField]
    private MeshRenderer mr;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");

            if (is_Green)
                mr.material.DOColor(Color.green, 0.2f);
            else
                mr.material.DOColor(Color.red, 0.2f);
        }
    }
}
