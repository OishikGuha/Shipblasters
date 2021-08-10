using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MissileTarget : MonoBehaviour
{

    public bool isActive;
    public float minDistance;

    Vector2 mousePos;
    SpriteRenderer sr;
    public Transform origin;
    public Transform[] enemies;

    public Transform targettedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        origin = FindObjectOfType<ShipController>().transform;
        GetEnemyList();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetEnemyList(); 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targettedEnemy = GetEnemy();

        if(targettedEnemy != null)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

        Active();
    }

    void Active()
    {
        if(isActive)
        {
            sr.enabled = true;
            transform.position = targettedEnemy.position;
            SinScale();
            transform.Rotate(0f,0f,-.1f);
        }
        else
        {
            sr.enabled = false;
        }
    }

    public Transform GetEnemy()
    {
        Transform enemy = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i] != null)
                if(Vector2.Distance(mousePos, enemies[i].position) < minDistance)
                {
                    enemy = enemies[i];
                    break;
                }
                else
                {
                    enemy = null;
                }
        }

        return enemy;
    }

    public void GetEnemyList()
    {
        EnemyShip[] tempEnemy = FindObjectsOfType<EnemyShip>();
        enemies = new Transform[tempEnemy.Length];
        for (int i = 0; i < tempEnemy.Length; i++) {enemies[i] = tempEnemy[i].transform;}
    }

    public void SinScale()
    {
        float s = Mathf.Sin(Time.time * 2) * 4f;
        s = Mathf.Clamp(s, 1f, 2f);
        
        transform.localScale = Vector3.one * s;
    }
}
