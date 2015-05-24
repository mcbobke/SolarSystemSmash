using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Code by Vincent
/// Generic music player for levels, uses BgmTrack objects.
/// Supports multiple tracks in a single level using BgmChangeTrack objects.
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour {

    public float bgmStartDelayInSeconds = 0.0f;
    public float tempo = 128.0f;
    public int numBeatsPerClip = 64;
    public float volume = 0.7f;
    public AudioClip[] clipList = new AudioClip[5];  // You can change the size of this list in the Unity editor

    private int index;
    private int flip = 0;
    private double nextEventTime;
    private AudioSource[] audioSources = new AudioSource[2];

	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject child = new GameObject("BgmPlayerChild");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent<AudioSource>() as AudioSource;
            audioSources[i].volume = volume;
        }

        index = 0; 

        nextEventTime = AudioSettings.dspTime + bgmStartDelayInSeconds;
	}
	
	// Update is called once per frame
	void Update () 
    {
        double time = AudioSettings.dspTime;

        if (time + 1.0f > nextEventTime)
        {
            // Debug.Log("Playing clip of index " + index);
            audioSources[flip].clip = clipList[index];
            audioSources[flip].PlayScheduled(nextEventTime);

            index = GetNextClipIndex(index);

            nextEventTime += 60.0f / tempo * numBeatsPerClip;

            flip = 1 - flip;
        }
	}

    int GetNextClipIndex(int currentindex)
    {
        if (currentindex + 1 == 5)
        {
            return 1;
        }
        else
        {
            return currentindex + 1;
        }
    }
    
}
