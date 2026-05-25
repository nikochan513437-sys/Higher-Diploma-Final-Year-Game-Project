using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class TutorialCGSound : MonoBehaviour
{
    AudioSource source;
    public static bool playonce = false;
    public static bool willplay = false;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;
    public AudioClip sound7;
    public AudioClip sound8;
    public AudioClip sound9;
    public AudioClip sound10;
    private void Start()
    {
        playonce = true;
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (playonce&&willplay)
        {
            if (TutorialCGmove.photonum == 1)
            {
                source.PlayOneShot(sound1);
            }
            if (TutorialCGmove.photonum == 2)
            {
                source.PlayOneShot(sound2);
            }
            if (TutorialCGmove.photonum == 3)
            {
                source.PlayOneShot(sound3);
            }
            if (TutorialCGmove.photonum == 4)
            {
                source.PlayOneShot(sound4);
            }
            if (TutorialCGmove.photonum == 5)
            {
                source.PlayOneShot(sound5);
            }
            if (TutorialCGmove.photonum == 6)
            {
                source.PlayOneShot(sound6);
            }
            if (TutorialCGmove.photonum == 7)
            {
                source.PlayOneShot(sound3);
            }
            if (TutorialCGmove.photonum == 8)
            {
                source.PlayOneShot(sound8);
            }
            if (TutorialCGmove.photonum == 9)
            {
                source.PlayOneShot(sound9);
            }
            if (TutorialCGmove.photonum == 10)
            {
                source.PlayOneShot(sound10);
            }
            playonce = false;
        }
    }
}
//to play the CG voice act
