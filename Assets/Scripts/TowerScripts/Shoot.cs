using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float cooldown = 2;
    public GameObject projectile;
    public GameObject bulletSpownPoint;
    public float towerRange;
    public bool canShoot = true;
    bool hasEnemy;

    float cd;
   
    // Start is called before the first frame update
    void Start()
    {
        cd = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            return;
        }
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position,Vector3.left,out hit, towerRange))
            {
                if (hit.transform.tag == "Enemy")
                {
                    if (cd <= 0 )
                    {
                        cd = cooldown;
                        Instantiate(projectile, bulletSpownPoint.transform.position, Quaternion.identity);
                    }
                    hasEnemy = true;
                }
                else if (hit.transform.tag == "Tower")
                {
                    Shoot shoo = hit.transform.gameObject.GetComponent<Shoot>();
                    if (shoo.hasEnemy)
                    {
                        hasEnemy = true;
                    }
                    else
                    {
                        hasEnemy = false;
                    }
                }
                else
                {
                    hasEnemy = false;
                }
            }
            else
            {
                hasEnemy = false;
            }
            if (hasEnemy)
            {
                if (cd <= 0)
                {
                    cd = cooldown;
                    Instantiate(projectile, bulletSpownPoint.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
