using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipData 
{
    // first number indicates hull
    // second number indicates turret
    public int[] shipToken = new int[2];

    public ShipData(CustomizerSelector selector)
    {
        shipToken[0] = selector.selectedHullIndex;
        shipToken[1] = selector.selectedTurretIndex;
    }
}
