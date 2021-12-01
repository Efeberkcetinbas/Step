using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    public List<Button> levelButtons;


    public bool isDelete;

    void Start()
    {


        if (isDelete)
            PlayerPrefs.DeleteAll();

        int saveIndex = PlayerPrefs.GetInt("SaveIndex");

        for(int i=0; i<levelButtons.Count; i++)
        {
            if (i <= saveIndex)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void LevelSelection()
    {
        int level = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        SceneManager.LoadScene(level);
    }

    public void nextPanel()
    {
        // Array ile tut panelleri.
        //DoTween yapısı kullan.

    }

}
