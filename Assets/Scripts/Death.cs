using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    [Header("Unity Setup")]
    public ParticleSystem DeathEffectParticles;
    public bool isTower = false;

    Vector3 particleSpawnPos;
    Health hlth;
    Money Mony;
    Enemy Enmy;

    void Start()
    {
        
        hlth = gameObject.GetComponent<Health>();
        Mony = GameObject.Find("GameManeger").GetComponent<Money>();
        if (!isTower)
        {
            Enmy = gameObject.GetComponent<Enemy>();
        }
    }
    // Update is called once per frame
     void Update()
    {
        if (hlth.health <= 0)
        {
            if (isTower)
            {
                Destroy(gameObject);
            }
            else
            {
                Mony.money += Enmy.value;
                particleSpawnPos = new Vector3(transform.position.x, -1.5f, transform.position.z - 2);
                Instantiate(DeathEffectParticles, particleSpawnPos, Quaternion.identity);
                Destroy(gameObject);
                if (DeathEffectParticles.gameObject.activeInHierarchy)
                {
                    Destroy(DeathEffectParticles.gameObject,2);
                }
            }
        }
    }

}
