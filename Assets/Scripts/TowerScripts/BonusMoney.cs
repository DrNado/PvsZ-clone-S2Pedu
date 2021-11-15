using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMoney : MonoBehaviour
{
    public float cooldown;
    public float bonusMoneyOT; //OT = Over Time

    float cdr;
    Money Mony;
    // Start is called before the first frame update
    void Start()
    {
        Mony = GameObject.Find("GameManeger").GetComponent<Money>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cdr > 0)
        {
            cdr -= Time.deltaTime;
        }
        else
        {
            cdr = cooldown;
            Mony.money += bonusMoneyOT;
        }
    }
}
