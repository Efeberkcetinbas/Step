using DG.Tweening;
using System.Collections;
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

    [SerializeField]
    private GameObject _jumpEffect;

    public bool game_is_Stop;


   


    private void Start()
    {
        game_is_Stop = true;
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
            StartCoroutine(Tween_Kill(.5f));
            StartCoroutine(Open_Failed(1f));
            //Timer'a oyunun durduğunu haber veriyoruz.
            game_is_Stop = true;
            
            //Her levelde obstacle kullanmıyorsun. Bu yapı yanlış.
            //DOTween.Kill(FindObjectOfType<ObstacleMovement>().transform);
        }

        else if (collision.gameObject.CompareTag("start"))
        {
            game_is_Stop = false;
        }
    }

    private IEnumerator Tween_Kill(float wait_time)
    {
        yield return new WaitForSecondsRealtime(wait_time);
        DOTween.KillAll();
    }

    //DOTween hatası önlendi.
    private IEnumerator Open_Failed(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        FailedManager.instance.open_Failed_Panel();
    }


    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("green"))
        {
            collision.gameObject.transform.DOMoveY(-8,1f);
            Debug.Log("sdasdsad");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Portal"))
        {
            gameObject.transform.DOMoveY(y_ex, 1f);
            AudioManager.instance.Play("success");
            game_is_Stop = true;
            //gameObject.transform.DOScaleY(0.1f, .5f);
        }

        if (other.gameObject.CompareTag("MoveY"))
        {
            //Particle Effect
            Instantiate(_jumpEffect, transform.position, Quaternion.identity);
            gameObject.transform.DOMoveY(move_y, 1f);
            AudioManager.instance.Play("Up");
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("MoveX"))
        {
            gameObject.transform.DOMoveX(move_x, 1f);
            AudioManager.instance.Play("Up");
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("MoveZ"))
        {
            //ParticleEffect
            gameObject.transform.DOMoveZ(move_z, 1f);
            AudioManager.instance.Play("Up");
            other.gameObject.SetActive(false);
        }
    }
}
