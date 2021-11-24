using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public int buildIndex = 0;

    private void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(next_Scene(2));
        }
    }

    /// <summary>
    /// Do tween hatasını çözümlemek için Caroutine yapısı kullanıldı.
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator next_Scene(float time)
    {
        yield return new WaitForSeconds(time);
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        if (buildIndex > saveIndex)
        {
            PlayerPrefs.SetInt("SaveIndex", buildIndex);
        }

        if (buildIndex == 10)
        {
            SceneManager.LoadScene(0);
        }

        else
        {
            SceneManager.LoadScene(buildIndex + 1);
        }
    }

   





}
