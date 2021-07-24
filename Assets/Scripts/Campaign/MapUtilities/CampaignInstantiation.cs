using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignInstantiation : MonoBehaviour
{

    public GameObject marker;
    [Space]
    public KeyCode markerKey;
    [Space]
    public Transform markerParent;

    CampaignManager campaignManager;
    // Start is called before the first frame update
    void Start()
    {
        campaignManager = FindObjectOfType<CampaignManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(markerKey))
        {
            Instantiate(marker, campaignManager.pointer.transform.position, Quaternion.identity, markerParent);
            Debug.Log("pressed key: " + markerKey);
        }
    }
}
