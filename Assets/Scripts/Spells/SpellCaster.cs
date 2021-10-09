using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{

    public SpellsManager spellsManager;
    public KeyCode blackHoleKey = KeyCode.Alpha1;
    public float cooldown;

    public bool canTurnOn = true;
    public bool isOn = false;
    UIPowers powers;

    // Start is called before the first frame update
    void Start()
    {
        spellsManager = FindObjectOfType<SpellsManager>();
        powers = FindObjectOfType<UIPowers>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(blackHoleKey) && canTurnOn)
        {
            isOn = true;
            spellsManager.SummonSpell("Black Hole");
            powers.FindAndRun("BlackHole", (int)cooldown);
        }

        if(isOn && canTurnOn)
        {
            StartCoroutine("Cooldown");
        }
    }

    IEnumerator Cooldown()
    {
        canTurnOn = false;
        isOn = false;
        yield return new WaitForSeconds(cooldown);
        canTurnOn = true;
    }
}
