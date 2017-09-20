/*================================================================
Product:    bastra
Developer:  Onur Tanrıkulu
Company:    Onur Tanrikulu
Date:       17/10/2016 14:35

Copyright (c) 2016 Onur Tanrikulu. All rights reserved.
================================================================*/

using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    public static SoundManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlaySingleClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void SetVolume(bool set)
    {
        if (set) audioSource.volume = 1;
        else audioSource.volume = 0;
    }
}
