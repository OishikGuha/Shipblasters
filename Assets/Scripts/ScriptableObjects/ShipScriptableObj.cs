using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "Ship")]
public class ShipScriptableObj : ScriptableObject
{
    public string shipName;
    public Sprite shipHull;
    public GameObject shipTurret;
    [Space]
    public float speed;
}
