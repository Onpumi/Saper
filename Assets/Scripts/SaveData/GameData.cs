
using SaveData;

public class GameData : SavingData<GameSetups>
{
    public GameData( string key, GameField gameField )
    {
        base.Key = key;
        DataSetups._scaleBricks = gameField.CalculateScale();
       
    }

    
    public void SetupOptionValue( TypesGame typeGame )
    {
        DataSetups.SetupOptionValue(typeGame);
        Save();
    }

    public void SetupOptionValue(TypesOption typeOption, bool value)
    {
        DataSetups.SetupOptionValue(typeOption, value);
        Save();
    }
    
    public void SetupOptionValue(TypesOption typeOption, float value)
    {
        DataSetups.SetupOptionValue(typeOption, value);
        Save();
    }


    public float GetOptionValue(TypesOption typeOption)
    {
        return DataSetups.GetOptionValue(typeOption);
    }

    public int GetDifficultValue()
    {
        return DataSetups.GetDifficultGameValue();
    }

    public void InitScale(float scale) => DataSetups._scaleBricks = scale;
    
}