using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionManager : MonoBehaviour
{

    public List<GameObject> objectsToReflect;
    public List<GameObject> instObjs;

    public bool reflectPlayer;
    GameObject player;

    bool addedPlayerToList;
    GameObject instPlayer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectsToReflect.Count; i++)
        {
            
            GameObject instObj;
            Reflect(objectsToReflect[i], out instObj);

            instObjs.Add(instObj);
        }
    }


    void Update()
    {
        if(reflectPlayer)
        {    
            player = GameManager.FindShipFromCustomizer().gameObject;
            if(!addedPlayerToList && player != null)
            {
                ReflectPlayer();
                objectsToReflect.Add(player);
                instObjs.Add(instPlayer);
                addedPlayerToList = true;
            }
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        for(int i = 0; i < instObjs.Count; i++)
        {
            if(instObjs[i] != null)
            {        
                Debug.Log(i);
                instObjs[i].transform.position = Vector2.down * 1 + (Vector2)objectsToReflect[i].transform.position;
                instObjs[i].transform.rotation = objectsToReflect[i].transform.rotation;
            }
            else
            {
                instObjs.Remove(instObjs[i]);
            }
        }
    }

    public void Reflect(GameObject obj, out GameObject objOut)
    {
        GameObject instObj = Instantiate(obj, obj.transform);

        if(instObj.transform.childCount > 0)
        {
            for (int j = 0; j < instObj.transform.childCount; j++)
            {
                Destroy(instObj.transform.GetChild(j).gameObject);
            }
        }

        Component[] components = instObj.GetComponents(typeof(Component));
        for (int k = 0; k < components.Length; k++)
        {
            if(components[k] is SpriteRenderer)
            {
                
            }
            else
            {
                Destroy(components[k]);
            }
        }
        
        SpriteRenderer sr = instObj.GetComponent<SpriteRenderer>();
        sr.sortingOrder = -10;
        sr.flipY = true;
        sr.color = new Color(1,1,1,0.1f);

        instObj.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y - 1);

        objOut = instObj;
    }

    void ReflectPlayer()
    {
        Reflect(player, out instPlayer);
    }
}
