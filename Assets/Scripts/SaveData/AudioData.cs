using TMPro;
using UnityEngine;
using SaveData;

public class AudioData : SavingData<AudioSetups>
{
    public AudioData( string key )
    {
        base.Key = key;
    }
    
    public void SetupValue( TypesAudio typesAudio, bool value )
    {
        DataSetups.SetupValue(typesAudio,value);
        Save();
    }

    public bool GetValue(TypesAudio typesAudio)
    {
        return DataSetups.GetValue(typesAudio);
    }
}




