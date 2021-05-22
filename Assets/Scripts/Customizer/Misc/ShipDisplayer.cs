using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDisplayer : MonoBehaviour
{

    public GameObject HullDisplay;
    public GameObject TurretDisplay;
    [Space]
    public CustomizerSelector selector;

    GameObject prevHull;
    GameObject prevTurret;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(selector.selectedHull != prevHull || selector.selectedTurret != prevTurret)
        {
            Clear();
            Display();
        }
    }

    void Display()
    {
        prevHull = selector.selectedHull;
        prevTurret = selector.selectedTurret;

        Instantiate(selector.selectedHull, HullDisplay.transform);
        GameObject turret = Instantiate(selector.selectedTurret, TurretDisplay.transform);

        if(turret.transform.childCount >= 1)
        {
            for (int i = 0; i < turret.transform.childCount; i++)
            {
                if(turret.transform.GetChild(i).GetComponent<Turret>())
                {
                    turret.transform.GetChild(i).GetComponent<Turret>().enabled = false;
                }
            }
        }
        else
        {
            turret.GetComponent<Turret>().enabled = false;
        }
    }
    
    void Clear()
    {
        if(HullDisplay.transform.childCount >= 1)
        {
            Destroy(HullDisplay.transform.GetChild(0).gameObject);
        }

        if(TurretDisplay.transform.childCount >= 1)
        {
            Destroy(TurretDisplay.transform.GetChild(0).gameObject);
        }
    }
}
