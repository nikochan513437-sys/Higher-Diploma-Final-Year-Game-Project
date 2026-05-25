using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class BGMVolumeControl : MonoBehaviour
{
    private AudioSource bgmAudio;
    public AudioClip startBGM;
    public AudioClip CGBGM;
    public AudioClip mapBGM;
    public AudioClip fightingBGM;
    public AudioClip eventBGM;
    public static BGMVolumeControl Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            bgmAudio = GetComponent<AudioSource>();
        }
        else {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (Instance == null || bgmAudio == null)
            return;
        if (scene.name == "SceneStart")
        {
            PlayBGM(startBGM);
        }
        else if (scene.name == "TutorialCG")
        {
            PlayBGM(CGBGM);
        }
        else if (scene.name == "TutorialMap")
        {
            PlayBGM(mapBGM);
        }
        else if (scene.name == "Fighting")
        {
            PlayBGM(fightingBGM);
        }
        else if (scene.name == "Event") {
            PlayBGM(eventBGM);
        }
    }

    void PlayBGM(AudioClip clip) {
        if (bgmAudio != null) {
            if (bgmAudio.clip != clip) {
                bgmAudio.Stop();
                bgmAudio.clip = clip;
                bgmAudio.Play();
            }
        }
    }

    public void OnVolumeChanged(float value) {
        bgmAudio.volume = value;
    }
}
