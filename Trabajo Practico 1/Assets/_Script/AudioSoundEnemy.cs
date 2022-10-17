using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundEnemy : MonoBehaviour
{
    public float playAudioDelay;
    private float timeBetweenSounds;
    private float lastPlay;
    AudioSource audioSource;
    Life m_life;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        m_life = GetComponent<Life>();
    }
    void Start()
    {
        timeBetweenSounds = audioSource.clip.length + playAudioDelay;
    }

    private void Update()
    {
        if (m_life.isAlive)
        {
            if (lastPlay <= Time.time)
            {
                audioSource.Play();
                lastPlay = Time.time + timeBetweenSounds;
            }
        }else if(audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    
}
