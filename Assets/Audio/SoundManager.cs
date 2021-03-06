﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DalLib;

namespace DaleranGames.ElectricDreams
{
    public class SoundManager : MonoBehaviour
    {

        protected SoundManager() { }

        public static SoundManager Instance = null;

        public AudioSource efxSource;
        public AudioSource musicSource;


        public float lowPitchRange = 0.95f;
        public float highPitchRange = 1.05f;

        // Use this for initialization
        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public void PlaySingle(AudioClip clip)
        {
            efxSource.clip = clip;
            efxSource.Play();
        }

        public void RandomSFX(params AudioClip[] clips)
        {
            int randomIndex = Random.Range(0, clips.Length);
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);

            efxSource.pitch = randomPitch;
            efxSource.clip = clips[randomIndex];
            efxSource.Play();
        }


    } 
}
