using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentsUI : MonoBehaviour
{

    public CustomizerSelector selector;
    [Space]
    public Text HullTextName;
    public Text TurretTextName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HullTextName.text = selector.selectedHull.name;
        TurretTextName.text = selector.selectedTurret.name;
    }
}
