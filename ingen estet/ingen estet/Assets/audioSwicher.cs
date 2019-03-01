using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSwicher : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BossMusic;
    public AudioClip NormalMusic;

    public bool copy;
    public bool playing;
    // Update is called once per frame
    void Update()
    {
        copy = GameObject.FindGameObjectWithTag("Floor").GetComponent<SpawnBoss>().BossIsAcctive;

        if(copy && !playing)
        {
            changeMusic(BossMusic);
        }
        else if(!playing)
        {
            changeMusic(NormalMusic);
        }
    }

    void changeMusic(AudioClip AC)
    {
        audioSource.Stop();
        audioSource.clip = AC;
        audioSource.Play();
        playing = true;
    }
}
