using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    //Singleton
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //Her levelde tekrar oluşturmak yerine böyle bir yol.
        DontDestroyOnLoad(gameObject);

        foreach(Sounds s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();

            //Bu sayede Audio Managerda verdiğimiz özellikleri çekiyoruz.
            //Çektiğimiz özellikleride AudioSource Componentinin özelliklerine atıyoruz.
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pithch;
            s.source.loop = s.is_Loop;
        }
    }

    private void Start()
    {
        //Arka plan müziği
        Play("Theme");
    }

    public void Play(string name)
    {
        //Gireceğimiz name ile sesimizin ismi aynı olmalı.
        Sounds s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + "not found!");
            return;
        }

        s.source.Play();
    }

}
