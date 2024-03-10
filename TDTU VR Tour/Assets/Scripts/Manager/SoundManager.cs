using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private Sound[] backgoundSound, sfxSounds;
    [SerializeField] private AudioSource backgoundSource, sfxSource;
    
    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        PlayBackgroundSound("Background");
    }

    public void PlayBackgroundSound(String audioName) {
        Sound sound = Array.Find(backgoundSound, sound => sound.nameAudio == audioName);
        if (sound == null) {
            Debug.Log("Sound: " + audioName + " not found!");
        }
        backgoundSource.clip = sound.audioClip;
        backgoundSource.Play();
    }

    public void PlaySFXSound(String audioName) {
        Sound sound = Array.Find(sfxSounds, sound => sound.nameAudio == audioName);
        if (sound == null) {
            Debug.Log("Sound: " + audioName + " not found!");
        }
        sfxSource.clip = sound.audioClip;
        sfxSource.Play();
    }

    public void backgroundVolume(float volume) {
        backgoundSource.volume = volume;
    }

    public void SFXVolume(float volume) {
        sfxSource.volume = volume;
    }
}
