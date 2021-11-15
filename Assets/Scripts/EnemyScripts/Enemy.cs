using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float value;
    public float damage;
    public float cooldown;
    public bool canMove = true;
    public float range;
    public enum Types { Blowing, Other };
    public Types Type;

    float slowCd;
    float initSpeedValue;
    float cd;
    

    void Start()
    {
        slowCd = cooldown;
        initSpeedValue = speed;
    }
    void Update()
    {
        EnemyDamage();
        EnemyMove();
    }
    void EnemyDamage()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;
            if (speed <= 0)
            {
                slowCd -= Time.deltaTime;
            }
        }
       
        Vector3 rayCastSpawn = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z);
       
        RaycastHit hit;

        if (Physics.Raycast(rayCastSpawn, Vector3.right,out hit, range))
        {
            if (hit.transform.tag == "Tower")
            {
                if (Type == Types.Other)
                {
                    if (cd <= 0)
                    {
                        Health helth = hit.transform.gameObject.GetComponent<Health>();
                        helth.health -= damage;
                        cd = cooldown;
                    }
                }
                if (Type == Types.Blowing)
                {
                    Health helth = hit.transform.gameObject.GetComponent<Health>();
                    helth.health -= damage;
                    gameObject.GetComponent<Health>().health -= 100;
                }
            }
            else if (hit.transform.tag == "Finish")
            {
                UIInfo ui = GameObject.Find("Canvas").GetComponent<UIInfo>();
                ui.lost = true;
            }
            canMove = false;
        }
        else if (!canMove)
        {
            canMove = true;
        }
    }
    public void EnemyMove()
    {
        if (slowCd <= 0)
        {
            speed = initSpeedValue;
            slowCd = cooldown;
        }
        if (canMove)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
   
}
