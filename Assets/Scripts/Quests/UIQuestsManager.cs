using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIQuestsManager : MonoBehaviour
{

    public QuestsManager questsManager;
    public GameObject checkBox;

    List<GameObject> instQuestObjs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        questsManager = FindObjectOfType<QuestsManager>();
        MakeUIQuests();
        Debug.Log(instQuestObjs.Count);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < questsManager.quests.Count; i++)
        {   
            TextMeshProUGUI objText = instQuestObjs[i].GetComponent<TextMeshProUGUI>();
            Toggle objCheck = instQuestObjs[i].GetComponentInChildren<Toggle>();

            objCheck.isOn = questsManager.quests[i].completed;
            objText.text = questsManager.quests[i].questName;
        }
    }

    void MakeUIQuests()
    {
        for (int i = questsManager.quests.Count - 1; i >= 0 ; i--)
        {
            GameObject instObj = Instantiate(checkBox);
            instObj.transform.SetParent(transform);
            instObj.transform.position = new Vector2(transform.position.x, transform.position.y + (i*50));
            instObj.transform.localScale = transform.localScale;
            
            TextMeshProUGUI objText = instObj.GetComponent<TextMeshProUGUI>();
            Toggle objCheck = instObj.GetComponentInChildren<Toggle>();
            
            instQuestObjs.Add(instObj);

            objCheck.isOn = questsManager.quests[i].completed;
            objText.text = questsManager.quests[i].questName;
        }
    }
}
