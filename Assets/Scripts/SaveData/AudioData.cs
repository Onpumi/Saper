using TMPro;
using UnityEngine;

public class AudioData : SavingData<AudioSetups>
{
    public AudioData( string key )
    {
        base.Key = key;
    }
    
    public void SetupValue( TypesAudio typesAudio, bool value )
    {
        _dataSetups.SetupValue(typesAudio,value);
        Save();
    }

    public bool GetValue(TypesAudio typesAudio)
    {
        return _dataSetups.GetValue(typesAudio);
    }
}




