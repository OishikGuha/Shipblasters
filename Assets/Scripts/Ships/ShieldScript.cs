using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{

    public Animator anim;
    public BoxCollider2D shieldCollider;
    public BoxCollider2D triggerShieldCollider;
    public LayerMask enemyBullet;
    public float cooldown;
    public bool canTurnOn;
    public bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        canTurnOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // this shit is hard
        if(isOn && canTurnOn)
        {
            shieldCollider.enabled = true;
            triggerShieldCollider.enabled = true;
            anim.SetBool("On", true);

            StartCoroutine("Cooldown");
        }
        else
        {
            shieldCollider.enabled = false;
            triggerShieldCollider.enabled = false;
            anim.SetBool("On", false);

        }

        LookAtMouse();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy Bullet")
        {
            Destroy(other.gameObject);
        }
    }

    public void TurnOn()
    {
        isOn = true;
    }


    void LookAtMouse()
    {       
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookAt = mouseScreenPosition;

        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canTurnOn = false;
        isOn = false;
        yield return new WaitForSeconds(cooldown);
        canTurnOn = true;
    }
}
