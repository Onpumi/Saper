using System;
using System.Collections.Generic;
using UnityEngine;

public static class IntExtensions
{
    public static int TryThrowIfLessThanZero(this int number)
    {
        if (number < 0)
            throw new ArgumentException("Number can't be less than zero");

        return number;
    }
}
