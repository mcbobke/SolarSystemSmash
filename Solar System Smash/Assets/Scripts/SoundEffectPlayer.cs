using UnityEngine;
using System.Collections.Generic;

public class SoundEffectPlayer : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip[] clipList = new AudioClip[4];         // Size of array can be changed in Unity Editor
    public Dictionary<string, AudioClip> clipDict = new Dictionary<string, AudioClip>();

	// Use this for initialization
	void Start() 
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        foreach (AudioClip clip in clipList)
        {
            clipDict.Add(clip.name, clip);
        }
	}

    public void PlaySoundEffect(string name, float volume = 0.8f)
    {
        audioSource.PlayOneShot(clipDict[name], volume);
    }

}
