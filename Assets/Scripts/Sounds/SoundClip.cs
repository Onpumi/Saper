using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClip : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    public AudioClip Clip => _clip;
}
