using System;
using UnityEngine;

[System.Serializable]
public class GameSetups 
{
    public bool _generationMinesAfterFirstStepOn;
    public int _gameDifficulty;
    public bool _vibrationOn;
    public float _scaleBricks;

    public GameSetups()
    {
        _generationMinesAfterFirstStepOn = true;
        _gameDifficulty = (int)TypesGame.MediumGame;
        _vibrationOn = true;
    }
    

    public void SetupOptionValue(TypesGame typeGame)
    {
        _gameDifficulty = (int)typeGame;
    }

    public void SetupOptionValue( TypesOption typeOption, bool value)
    {
        if (typeOption == TypesOption.Vibration)
        {
            _vibrationOn = value;
        }
        else if ( typeOption == TypesOption.GenerationMinesAfterFirstStep )
        {
            _generationMinesAfterFirstStepOn = value;
        }
        else throw new ArgumentException("typeOption is need be to Vibration or GenerationMinesAfterFirstStep");
    }

    public void SetupOptionValue(TypesOption typeOption, float value)
    {
         if ( typeOption == TypesOption.SizeCells )  
             _scaleBricks = value;
         else
             throw new ArgumentException("TypeOption need be set to  SizeCells");
    }

    public int GetDifficultGameValue()
    {
        return _gameDifficulty;
    }

    public float GetOptionValue(TypesOption typeOption)
    {
         switch(typeOption)
        {
            case TypesOption.Vibration : return _vibrationOn ? (1f) : (0f);
            case TypesOption.SizeCells : return _scaleBricks;
            case TypesOption.GenerationMinesAfterFirstStep : return _generationMinesAfterFirstStepOn ? (1f) : (0f);
            default :
                throw new ArgumentException("GetOptionValue is wrong!"); 
        }
    }
    
     
    
    
}