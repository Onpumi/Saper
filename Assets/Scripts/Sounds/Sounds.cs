using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
    
public class Sounds : SerializedMonoBehaviour, ISaveObject
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Dictionary<SoundType, AudioClip> _clips;

    private Dictionary<SoundType, bool> _resolvesClip;


    public void Save( bool value)
    {
        
    }

    public void Load()
    {
        
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        

        _resolvesClip = new Dictionary<SoundType, bool>();

        foreach (SoundType typeSound  in SoundType.GetValues(typeof(SoundType)) )
        {
            _resolvesClip[typeSound] = true;
        }
    }

    private void OnEnable()
    {
        _resolvesClip = new Dictionary<SoundType, bool>();
        foreach (SoundType typeSound  in SoundType.GetValues(typeof(SoundType)) )
        {
            _resolvesClip[typeSound] = true;
        }

    }

    public void PlayAudio( SoundType typeSound)
    {
        //var clip = _clips[typeSound];
        _audioSource.clip = _clips[typeSound];
        if (_resolvesClip[typeSound])
        {
//              _audioSource.PlayOneShot(clip);
            _audioSource.Play();
        }
    }

    public void SetResolveSound( SoundType typeSound, bool value )
    {
        _resolvesClip[typeSound] = value;
    }
    
    
    
}

public enum SoundType
{
    Explode,
    Click,
    Flag,
    Empty
}