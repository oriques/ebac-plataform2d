using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTriggerTransition : MonoBehaviour
{

    public AudioMixerSnapshot snapshot01;
    public AudioMixerSnapshot snapshot02;

    public string tagToCompare = "Player";
    public float timeTransition = .1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToCompare))
        {
            snapshot02.TransitionTo(timeTransition);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToCompare))
        {
            snapshot01.TransitionTo(timeTransition);
        }
    }
}
    
