using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class LevelEnding : MonoBehaviour
{

    public int buildIndex = 0;

    public TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh.text = buildIndex.ToString();
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LevelsButton()
    {
        SceneManager.LoadScene(27);
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(buildIndex);
        AudioManager.instance.Play("Theme");
    }

    public void NextButton()
    {
        StartCoroutine(next_level(.2f));
        SceneManager.LoadScene(buildIndex + 1);
        Control();
    }

    IEnumerator next_level(float duration)
    {
        yield return new WaitForSeconds(duration);
        DOTween.KillAll();
    }

    private void Control()
    {
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        if (buildIndex > saveIndex)
        {
            PlayerPrefs.SetInt("SaveIndex", buildIndex);
        }
    }

    public void AdsButton()
    {

    }
}
