using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   
    public AudioSource audioSource; 
    public AudioClip[] audioClips; 
    private List<AudioClip> shuffledClips;
    private int currentClipIndex = 0;

    void Start()
    {
      
        shuffledClips = new List<AudioClip>(audioClips);

       
        ShuffleList(shuffledClips);

     
        PlayNextClip();
    }

    
    void PlayNextClip()
    {
        
        if (currentClipIndex < shuffledClips.Count)
        {
           
            audioSource.clip = shuffledClips[currentClipIndex];
            
            
            audioSource.Play();
            
         
            currentClipIndex++;
        }
        else
        {
          
            currentClipIndex = 0;
            ShuffleList(shuffledClips);
            PlayNextClip();
        }
    }

    void Update()
    {
       
        if (!audioSource.isPlaying)
        {
           
            PlayNextClip();
        }
    }

  
    void ShuffleList(List<AudioClip> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            AudioClip temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}

