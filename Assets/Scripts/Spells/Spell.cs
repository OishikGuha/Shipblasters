using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spell : MonoBehaviour
{

    public string spellName;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Summon()
    {
        transform.DOScale(2, 2).From(0);
    }
}
