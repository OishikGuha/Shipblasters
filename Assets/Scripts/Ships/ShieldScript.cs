using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{

    public Animator anim;
    public BoxCollider2D shieldCollider;
    public BoxCollider2D triggerShieldCollider;
    public bool isOn;
    public float cooldownDelay;
    public LayerMask enemyBullet;

    bool canBeOn;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            shieldCollider.enabled = true;
            triggerShieldCollider.enabled = true;
            anim.SetBool("On", isOn);
        }
        else
        {
            shieldCollider.enabled = false;
            triggerShieldCollider.enabled = false;
            anim.SetBool("On", isOn);
        }

        LookAtMouse();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(other.gameObject.layer);
        if(other.gameObject.tag == "Enemy Bullet")
        {
            Destroy(other.gameObject);
        }
    }

    public void TurnOn()
    {
        isOn = true;
        shieldCollider.enabled = true;
        triggerShieldCollider.enabled = true;
    }

    public void TurnOff()
    {
        isOn = false;
        shieldCollider.enabled = false;
        triggerShieldCollider.enabled = false;
    }

    void LookAtMouse()
    {       
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookAt = mouseScreenPosition;

        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }
}
