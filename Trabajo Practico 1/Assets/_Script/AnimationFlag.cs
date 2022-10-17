using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFlag : MonoBehaviour
{
    public bool throwGranade =true;
    public bool tossGranade = false;

    public GameObject shootLight;
    private AudioSource m_AudioSource;


    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void SetGranadeFlag()
    {
        throwGranade = false;
    }

    public void TossGranade()
    {
        tossGranade = true;
    }

    public void Shoot()
    {
        m_AudioSource.Play();
        shootLight.SetActive(true);
    }

    public void DisableShootLight()
    {
        shootLight.SetActive(false);
    }

}
