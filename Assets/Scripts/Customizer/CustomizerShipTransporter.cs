using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizerShipTransporter : MonoBehaviour
{

    public CustomizerSelector selector;

    public static GameObject HullObj;
    public static GameObject TurretObj;

    public static bool inGame = false;
    public bool spawnd = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        HullObj = selector.selectedHull;
        TurretObj = selector.selectedTurret;

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            inGame = true;
        }

        if(inGame)
        {
            ShipConstructor constructor = Transform.FindObjectOfType<ShipConstructor>();

            if(constructor)
            {
                constructor.shipScriptableObj.shipHull = HullObj.GetComponent<SpriteRenderer>().sprite;
                constructor.shipScriptableObj.shipTurret = TurretObj;
                if(!spawnd)
                {
                    constructor.Construct();
                    spawnd = true;
                }
            }
            else
            {
                Debug.LogError("Could not Find The Constructor!");
            }
        }
    }
}
