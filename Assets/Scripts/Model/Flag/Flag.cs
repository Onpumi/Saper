using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flag
{

    private ICellView _cellView;
    private FlagView _flagView; 
    public bool Value { get; private set; }

   public Flag( ICellView cellView, FlagView flagView)
   {
       Value = false;
       _cellView = cellView;
       _flagView = flagView;
   }

   public bool SetFlag( ContainerMines containerMines)
   {
       var countFlags = containerMines.CountFlags;

       if (countFlags <= 0 && Value == false)
       {
           return Value;
       }
       else if (countFlags <= 0 && Value == true)
       {
           Value = false;
           RemoveFlag();
           containerMines.SetCountFlags(1);
           return true;
       }
       
       else if ( countFlags > 0 && Value == false)
       {
           containerMines.SetCountFlags(-1);
           return AddFlag();
       }
       
       else if (countFlags > 0 && Value == true)
       {
           containerMines.SetCountFlags(1);
           return RemoveFlag();
       }

       else return Value;
      
   }


   private bool RemoveFlag() => Value = _cellView.InitFlag(false);

   private bool AddFlag() => Value = _cellView.InitFlag(true);



}
