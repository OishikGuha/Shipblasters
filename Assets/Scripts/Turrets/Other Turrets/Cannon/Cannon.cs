using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public KeyCode shootKey;
    public GameObject cannonBall;
    public Direction dir;
    public GameObject fireParticle;

    public enum Direction {left, right};
    public float cooldown;
    public bool canShoot = true;   
    
    UIPowers powers;

    // Start is called before the first frame update
    void Start()
    {
        powers = FindObjectOfType<UIPowers>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if(canShoot)
        {
            AudioManager.Play("CannonFire");

            GameObject obj = Instantiate(cannonBall, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            CannonBall canIPutMyBallsInYoJaw = obj.GetComponent<CannonBall>();

            canIPutMyBallsInYoJaw.rotation = new Quaternion(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z, 1);
            if(dir == Direction.left)
            {
                canIPutMyBallsInYoJaw.dir = CannonBall.Direction.left;
            }
            else
            {
                canIPutMyBallsInYoJaw.dir = CannonBall.Direction.right;
            }
            
            GameObject fire = Instantiate(fireParticle, transform.position, transform.rotation, transform);

            canShoot = false;
            StartCoroutine("ShootCooldown");

            powers.FindAndRun("Cannon", (int)cooldown);
        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
