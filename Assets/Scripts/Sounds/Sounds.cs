using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
    
public class Sounds : SerializedMonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Dictionary<SoundsPlaying, AudioClip> _clips;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayAudio( SoundsPlaying typeSound)
    {
        _audioSource.clip = _clips[typeSound];
        _audioSource.Play();
    }
    
    
    
}

public enum SoundsPlaying
{
    EXPLODE,
    CLICK,
    FLAG,
    EMPTY
}