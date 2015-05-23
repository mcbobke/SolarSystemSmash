using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundEffectManager : MonoBehaviour {

    public AudioSource audioSource;
    public AudioSource loopingAudioSource;
    public AudioClip[] clipList = new AudioClip[4];         // Size of array can be changed in Unity Editor
    public Dictionary<string, AudioClip> clipDict = new Dictionary<string, AudioClip>();

    private bool fadingOut = false;         // Messy, but I don't know another way to do it at the moment

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

    //TODO: fix this
    public void StopLoopingPlayback()
    {
        StartCoroutine("FadeOutLoopingEffect");
    }

    public IEnumerable ResetLoopingAudioSource()
    {
        while (fadingOut)
        {
            yield return null;
        }
        loopingAudioSource.Stop();
        loopingAudioSource.volume = 1.0f;
        yield return null;
    }

    public IEnumerable FadeOutLoopingEffect()
    {
        fadingOut = true;
        while (loopingAudioSource.volume > 0.1f)
        {
            loopingAudioSource.volume -= 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
        fadingOut = false;
    }
}
