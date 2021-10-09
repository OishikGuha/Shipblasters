using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUIManager : MonoBehaviour
{

    public DebugManager debugManager;
    public Dropdown dropdown;
    public Button executeButton;
    public InputField debugInput;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < debugManager.debugItems.Count; i++)
        {
            dropdown.options.Add(new Dropdown.OptionData(debugManager.debugItems[i].name));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExecuteAction()
    {
        debugManager.Execute(dropdown.options[dropdown.value].text);
    }
}
