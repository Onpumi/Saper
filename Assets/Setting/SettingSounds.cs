using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSounds:ISettings
{
    private Sounds _sounds;
    private SoundType _soundType;
    

    public SettingSounds(Sounds sounds, SoundType soundType)
    {
        _sounds = sounds;
        _soundType = soundType;
    }

    public void Save( bool value )
    {
        _sounds.SetResolveSound(_soundType, value );        
    }

    public void Load()
    {
        
    }
    
}
