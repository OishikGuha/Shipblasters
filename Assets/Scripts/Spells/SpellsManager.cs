using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsManager : MonoBehaviour
{

    public List<GameObject> spells;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SummonSpell( string spellName )
    {
        GameObject spell = FindSpell(spellName); 

        GameObject spellInst = Instantiate(spell);
        spellInst.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        spellInst.GetComponent<Spell>().Summon();   
    }

    public GameObject FindSpell(string spellName)
    {
        GameObject spell = null;

        for (int i = 0; i < spells.Count; i++)
        {
            Spell objSpell = spells[i].GetComponent<Spell>();
            if(objSpell.spellName == spellName)
            {
                spell = spells[i];
            }
        }

        return spell;
    }
}
