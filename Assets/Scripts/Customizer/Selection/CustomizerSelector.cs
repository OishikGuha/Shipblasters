using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CustomizerSelector : MonoBehaviour
{
    public CustomizerList customizerList;
    public InputField nameInput;
    public SaveDropdown savesDropdown;
    [Space]
    public GameObject selectedHull;
    public int selectedHullIndex;
    [Space]
    public GameObject selectedTurret;
    public int selectedTurretIndex;
    [Header("Values")]
    public string shipName;
    public float speed;
    
    private void Start() 
    {

    }

    private void Update() 
    {
        shipName = nameInput.text;

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
        Debug.Log(savesDropdown.dropdown.value);
        ShipData data = savesDropdown.shipDatas[savesDropdown.dropdown.value];

        selectedHullIndex = data.shipToken[0];
        selectedTurretIndex = data.shipToken[1];

        speed = data.speed;
    }
}
