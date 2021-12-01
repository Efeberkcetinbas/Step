using DG.Tweening;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    private MeshRenderer mr;


    [SerializeField]
    private float y_ex;

    [SerializeField]
    private float move_y;

    [SerializeField]
    private float move_x;

    [SerializeField]
    private float move_z;

    public bool game_is_Stop = false;


    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("green"))
        {
            mr.material.DOColor(Color.green,0.01f);
        }
        else if (collision.gameObject.CompareTag("red"))
        {
            mr.material.DOColor(Color.red, 0.01f);
            FailedManager.instance.open_Failed_Panel();
            game_is_Stop = true;
            //Her levelde obstacle kullanmıyorsun. Bu yapı yanlış.
            //DOTween.Kill(FindObjectOfType<ObstacleMovement>().transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            gameObject.transform.DOMoveY(y_ex, 1f);
            AudioManager.instance.Play("success"); 
            //gameObject.transform.DOScaleY(0.1f, .5f);
        }

        if (other.gameObject.CompareTag("MoveY"))
        {
            gameObject.transform.DOMoveY(move_y, 1f);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("MoveX"))
        {
            gameObject.transform.DOMoveX(move_x, 1f);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("MoveZ"))
        {
            gameObject.transform.DOMoveZ(move_z, 1f);
            other.gameObject.SetActive(false);
        }
    }
}
