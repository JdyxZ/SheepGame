using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySoundOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Public vars
    public GameObject soundPlayer;

    // Private vars
    private AudioSource sound;

    // Start is called before the first frame update
    private void Start()
    {
        sound = soundPlayer.GetComponent<AudioSource>();
    }

    // Handle triggers
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(sound)
            sound.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (sound)
            sound.Stop();
    }
}
