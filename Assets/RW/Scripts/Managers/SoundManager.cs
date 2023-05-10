using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Vars
    public static SoundManager Instance; 
    public AudioClip shootClip; 
    public AudioClip sheepHitClip; 
    public AudioClip sheepDroppedClip;
    private Vector3 cameraPosition;

    // Awake runs before the start method
    void Awake()
    { 
        // Initialize instance
        Instance = this; 

        // Cache main camera position
        cameraPosition = Camera.main.transform.position;
    }

    // Other methods
    private void PlaySound(AudioClip clip) 
    {
        // Play the clip at the camera position (since it is static)
        AudioSource.PlayClipAtPoint(clip, cameraPosition); 
    }

    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }
}
