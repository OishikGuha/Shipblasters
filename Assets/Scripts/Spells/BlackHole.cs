using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlackHole : MonoBehaviour
{

    public List<string> tags;
    public float range;

    public List<GameObject> objToPull = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));

        for (int i = 0; i < obj.Length; i++)
        {
            GameObject g = (GameObject)obj[i];

            if(tags.Contains(g.tag) && Vector2.Distance(g.transform.position, transform.position) <= range)
            {
                objToPull.Add(g);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objToPull.Count; i++)
        {
            if(objToPull[i] != null)
            {
                Pull(objToPull[i].GetComponent<Rigidbody2D>());
            }
        }
    }

    void Pull(Rigidbody2D rb)
    {
        Vector2 diff = rb.position - (Vector2)transform.position;
        rb.AddForce(-diff * 3);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(tags.Contains(col.tag))
            Destroy(col.gameObject);

    }
}
