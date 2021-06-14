using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDropdown : MonoBehaviour
{

    public Dropdown dropdown;
    public ShipData[] shipDatas;

    // Start is called before the first frame update
    void Start()
    {
        CustomizerSaveSystem.OnSave.AddListener(RefreshList);

        dropdown = GetComponent<Dropdown>();

        shipDatas = CustomizerSaveSystem.ReadFiles();

        for (int i = 0; i < shipDatas.Length; i++)
        {
            dropdown.options.Add(new Dropdown.OptionData(shipDatas[i].shipName));
        }
    }

    public void RefreshList()
    {
        // don't misunderstand the string, the list wont refresh if the dropdown's text says "i hate gamers"
        dropdown.options.RemoveAll(dropdown => dropdown.text != "I hate gamers");

        shipDatas = CustomizerSaveSystem.ReadFiles();

        for (int i = 0; i < shipDatas.Length; i++)
        {
            dropdown.options.Add(new Dropdown.OptionData(shipDatas[i].shipName));
        }
    }
}
