using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
    
public class Sounds : SerializedMonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Dictionary<TypeSave, AudioClip> _clips;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
    }

    public void PlayAudio( TypeSave typeSave)
    {
        _audioSource.clip = _clips[typeSave];
            if( _gameState.AudioData.GetValue(typeSave))
            _audioSource.Play();
    }

    
}

public enum TypeSave
{
    Explode,
    Click,
    Flag,
    Empty
}