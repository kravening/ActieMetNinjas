using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AudioSourceController : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> audioList = new List<AudioClip>();
    [SerializeField]
    private float audioVolume;
    [SerializeField]
    private bool autoStopSound;
    [SerializeField]
    private bool randomisePitch;
    [SerializeField]
    private float minPitch;
    [SerializeField]
    private float maxPitch;


    private AudioSource audioSource;
    private int lastIndexPlayed;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioVolume;
        if (audioList.Count != 0)
        {
            lastIndexPlayed = Random.Range(0, audioList.Count);
        }
        else
        {
            Debug.Log("there is nothing in the audioList you dingus");
        }
    }

    public void ChangeAudioSourceByIndex(int index)
    {
        if (index <= audioList.Count && audioList.Count != 0)
        {
            if (autoStopSound)
            {
                audioSource.Stop();	//stop sound here
            }
            RandomisePitch();
            audioSource.clip = audioList[index];					 //change sound here
            audioSource.Play();									 //play sound here
        }
        else
        {
            Debug.Log("index given is too large, or there might be nothing in the audioList you dingus");
        }
    }

    public void ChangeAudioSourceRandom()
    {
        int randomIndex = Random.Range(0, audioList.Count);
        if (audioList.Count != 0)
        {
            if (randomIndex == lastIndexPlayed)
            {//check if last sound played is the same
                randomIndex = Random.Range(0, audioList.Count); 		 //reroll int
            }
            if (autoStopSound)
            {
                audioSource.Stop();	//stop sound here
            }
            RandomisePitch();
            audioSource.clip = audioList[randomIndex];				 //change sound here
            audioSource.Play();                                     //play sound here
            lastIndexPlayed = randomIndex;                           // sets new lastPlayedIndex
        }
        else
        {
            Debug.Log("there is nothing in the audioList you dingus");
        }

    }

    private void RandomisePitch()
    {
        if (randomisePitch)
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
        }
    }
}
