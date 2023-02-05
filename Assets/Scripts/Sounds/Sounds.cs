using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
    
public class Sounds : SerializedMonoBehaviour
{
    //[SerializeField] private GameState _gameState;
    [SerializeField] private GameField _gameField;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Dictionary<TypesAudio, AudioClip> _clips;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio( TypesAudio typesAudio)
    {
        _audioSource.clip = _clips[typesAudio];
            if( _gameField.DataSetting.AudioData.GetValue(typesAudio))
            _audioSource.Play();
    }

    
}

