using UnityEngine;
using System.Collections.Generic;

public class SoundEffectManager : MonoBehaviour {

    public AudioSource audioSource;
    public AudioSource loopingAudioSource;
    public AudioClip[] clipList = new AudioClip[4];         // Size of array can be changed in Unity Editor
    public Dictionary<string, AudioClip> clipDict = new Dictionary<string, AudioClip>();

	// Use this for initialization
	void Start() 
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        loopingAudioSource = gameObject.GetComponent<AudioSource>();
        foreach (AudioClip clip in clipList)
        {
            clipDict.Add(clip.name, clip);
        }
	}

    public void PlaySoundEffect(string name, float volume)
    {
        audioSource.PlayOneShot(clipDict[name], volume);
    }

    public void PlaySoundEffectLoop(string name, float volume)
    {
        loopingAudioSource.clip = clipDict[name];
        loopingAudioSource.Play();
    }

    public void StopSoundEffectLoop()
    {
        loopingAudioSource.Stop();
    }

}
