using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioClipPlay : MonoBehaviour
{
    AudioSource source;
    public AudioClip PlayerATK;
    public AudioClip PlayerGetSheild;
    public AudioClip PlayerGetHit;
    public static AudioSource S;
    public static AudioClip ATK;
    public static AudioClip GetSheild;
    public static AudioClip GetHit;
    private void Start()
    {
        S=GetComponent<AudioSource>();
        ATK = PlayerATK;
        GetSheild=PlayerGetSheild;
        GetHit=PlayerGetHit;
    }
    public static void PlayClipATK()
    {
        if (S != null)
            S.PlayOneShot(ATK);
    }
    public static void PlayClipGetShield()
    {
        if (S != null)
            S.PlayOneShot(GetSheild);
    }
    public static void PlayClipGetHit()
    {
        if (S != null)
            S.PlayOneShot(GetHit);
    }
}
