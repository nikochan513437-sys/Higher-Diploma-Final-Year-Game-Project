using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class TutorialCGSound : MonoBehaviour
{
    AudioSource source;
    public static bool playonce = false;
    public static bool willplay = false;
    public AudioClip[] CGsoundList;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (playonce&&willplay)
        {
            source.PlayOneShot(CGsoundList[TutorialCGmove.photonum]);
            playonce = false;
        }
    }
}
//to play the CG voice act
