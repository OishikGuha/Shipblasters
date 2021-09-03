using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{

    public SpellsManager spellsManager;
    public KeyCode blackHoleKey = KeyCode.Alpha1;

    // Start is called before the first frame update
    void Start()
    {
        spellsManager = FindObjectOfType<SpellsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(blackHoleKey))
        {
            spellsManager.SummonSpell("Black Hole");
        }
    }
}
