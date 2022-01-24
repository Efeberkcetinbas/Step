using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CongManager : MonoBehaviour
{
    public static CongManager instance { get; private set; }

    public GameObject cong_Panel;

    [SerializeField] private int level_score;
    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        cong_Panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Burada caroutine ile setActive hale getirirsin. Hareketsiz bırakırsın.
            ScoreManagement.instance.score_increase(level_score);
            StartCoroutine(open_Cong_Panel(2));
        }
    }

    /// <summary>
    /// Do tween hatasını çözümlemek için Caroutine yapısı kullanıldı.
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator open_Cong_Panel(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        cong_Panel.SetActive(true);

        //2.12.2021 Eklendi.
        DOTween.KillAll();
    }
}
