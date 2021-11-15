using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTaken : MonoBehaviour
{
    public bool hasTower;
    public GameObject tower;
    public bool hasZombie;

    List<Collider> CollidingEnemys;
    private void Start()
    {
        CollidingEnemys = new List<Collider>();
    }
    private void Update()
    {
        if (tower == null && hasTower)
        {
            hasTower = false;
        }

       //CheckLists();
    }
    void CheckLists()
    {
        if (CollidingEnemys == null)
        {
            hasZombie = false;
        }
        if (CollidingEnemys != null)
        {
            if (CollidingEnemys.Count == 0)
            {
                hasZombie = false;
            }
            if (CollidingEnemys.Count != 0 )
            {
                hasZombie = true;
            }
        }
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            CollidingEnemys.Add(col);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (CollidingEnemys.Count != 0 )
        {
            CollidingEnemys.Remove(col);
        }
    }
}
