using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Music : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    public AudioClip songOne;
    public AudioClip songTwo;
    public AudioClip songThree;

    private AudioSource audioSource;
    private List<AudioClip> clips;
    private int currentSong;
    
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = songOne;
        audioSource.loop = true;
        audioSource.Play();

        clips = new List<AudioClip>();
        clips.Add(songOne);
        clips.Add(songTwo);
        clips.Add(songThree);
        currentSong = 0;
    }

    private void Next()
    {
        if (currentSong == clips.Count - 1)
        {
            audioSource.clip = clips[0];
            currentSong = 0;
        }
        else
        {
            audioSource.clip = clips[currentSong + 1];
            currentSong++;
        }

        audioSource.loop = true;
        audioSource.Play();
    }

    private void Previous()
    {
        if (currentSong == 0)
        {
            audioSource.clip = clips[clips.Count - 1];
            currentSong = clips.Count - 1;
        }
        else
        {
            audioSource.clip = clips[currentSong - 1];
            currentSong--;
        }

        audioSource.loop = true;
        audioSource.Play();
    }

    private void GetSongName()
    {
        textMeshProUGUI.text = audioSource.clip.name;
    }
}
