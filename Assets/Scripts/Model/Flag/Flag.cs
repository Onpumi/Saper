using System.Collections;
using System.Collections.Generic;
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

   public bool SetFlag( int countFlags)
   {
       if (Value == false && countFlags <= 0) return !Value;
       Value = !Value;
       _cellView.InitFlag( Value );
       return Value;
   }
}
