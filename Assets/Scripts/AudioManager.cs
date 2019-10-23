using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip ringCrossClip;
    public AudioClip playerDestroyedClip;

    GameManager gameManager;
    AudioSource gameAudioSource;

    void Start () {
        RingController.ringCrossed += PlayRingCrossAudio;
        gameAudioSource = GetComponent<AudioSource>();
        gameManager = GetComponent<GameManager>();
    }
	
	void PlayRingCrossAudio()
    {
        if (!gameManager.gameOver)
        {
            gameAudioSource.clip = ringCrossClip;
            gameAudioSource.Play();
        }
    }

    public void PlayPlayerDestroyAudio()
    {
        gameAudioSource.clip = playerDestroyedClip;
        gameAudioSource.Play();
    }
}
