using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizerShipTransporter : MonoBehaviour
{

    public CustomizerSelector selector;

    public static GameObject HullObj;
    public static GameObject TurretObj;
    public static float speed;

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

        if(SceneManager.GetActiveScene().name == "Main")
        {
            inGame = true;
        }
        else
        {
            selector = FindObjectOfType<CustomizerSelector>();

            HullObj = selector.selectedHull;
            TurretObj = selector.selectedTurret;
            speed = selector.speed;

            inGame = false;
        }            

        if(inGame)
        {
            ShipConstructor constructor = Transform.FindObjectOfType<ShipConstructor>();

            if(constructor)
            {
                constructor.shipScriptableObj.shipHull = HullObj.GetComponent<SpriteRenderer>().sprite;
                constructor.shipScriptableObj.shipCollider = HullObj.GetComponent<BoxCollider2D>();
                constructor.shipScriptableObj.shipTurret = TurretObj;
                constructor.shipScriptableObj.speed = speed;
                if(!spawnd)
                {
                    constructor.Construct();
                    spawnd = true;
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.LogError("Could not Find The Constructor!");
            }
        }
    }
}
