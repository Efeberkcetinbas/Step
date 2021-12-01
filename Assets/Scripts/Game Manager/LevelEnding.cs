using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEnding : MonoBehaviour
{

    public int buildIndex = 0;

    private void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LevelsButton()
    {
        SceneManager.LoadScene(10);
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(buildIndex);
        AudioManager.instance.Play("Theme");
    }

    public void NextButton()
    {
        SceneManager.LoadScene(buildIndex + 1);
        Control();
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
