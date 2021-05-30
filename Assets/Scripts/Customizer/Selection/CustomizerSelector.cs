using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CustomizerSelector : MonoBehaviour
{
    public CustomizerList customizerList;
    [Space]
    public GameObject selectedHull;
    public int selectedHullIndex;
    [Space]
    public GameObject selectedTurret;
    public int selectedTurretIndex;
    [Header("Values")]
    public float speed;
    
    private void Start() 
    {
              
    }

    private void Update() 
    {
        selectedHullIndex = LoopNumber(selectedHullIndex, 0, customizerList.hulls.Count - 1);
        selectedTurretIndex = LoopNumber(selectedTurretIndex, 0, customizerList.turrets.Count - 1);

        SelectHull();
        SelectTurret();
    }

    void SelectHull()
    {
        selectedHull = customizerList.hulls[selectedHullIndex].gameObject;  
    }   

    void SelectTurret()
    {
        selectedTurret = customizerList.turrets[selectedTurretIndex].gameObject;
    }

    int LoopNumber(int num, int min, int max)
    {
        if(num < min)
        {
            num = max;
        }
        if(num > max)
        {
            num = min;
        }

        return num;
    }

    // Increments and Decrement Functions
    public void IncrementHull()
    {
        selectedHullIndex++;
    }

    public void DecrementHull()
    {
        selectedHullIndex--;
    }

    public void IncrementTurret()
    {
        selectedTurretIndex++;
    }

    public void DecrementTurret()
    {
        selectedTurretIndex--;
    }

    public void ChangeSpeedBy(float pSpeed)
    {
        speed += pSpeed;
    }

    // Save and Load
    public void SaveShip()
    {
        CustomizerSaveSystem.Save(this);
    }

    public void LoadShip()
    {
        ShipData data = CustomizerSaveSystem.Load();

        selectedHullIndex = data.shipToken[0];
        selectedTurretIndex = data.shipToken[1];

        speed = data.speed;
    }
}