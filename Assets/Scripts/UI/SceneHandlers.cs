using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandlers : MonoBehaviour
{
    [SerializeField] RectTransform fader;


    private void Start()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() =>
          {
              fader.gameObject.SetActive(false);
          });
    }
}
