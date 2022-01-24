using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FailedManager : MonoBehaviour
{
    public static FailedManager instance { get; private set; }

    public GameObject failed_Panel;


    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        failed_Panel.SetActive(false);
    }

    public void open_Failed_Panel()
    {
        StartCoroutine(Open_Failed(.1f));
        //Bu sayede diğer kodlardaki tweenlerde null hatasını önlüyorum.
        DOTween.KillAll();
        Debug.Log("Opened Failed");
    }

    /// <summary>
    /// Do tween hatasını çözümlemek için Caroutine yapısı kullanıldı.
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator Open_Failed(float time)
    {
        AudioManager.instance.Play("fail");
        AudioManager.instance.Stop("Theme");
        yield return new WaitForSecondsRealtime(time);
        failed_Panel.SetActive(true);
    }
}
