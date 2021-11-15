using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float movementSpeed;
    public float damage;
    public float slowAmount;
    Vector3 initPos;
    public enum Types { Special , Normal };
    public Types Type;

    AudioManager audioHit;


    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*movementSpeed*Time.deltaTime);
        if (Vector3.Distance(transform.position,initPos) > 20)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            audioHit = GameObject.Find("GameManeger").GetComponent<AudioManager>();
            audioHit.sound.Play();
            if (Type == Types.Normal)
            {
                col.GetComponent<Health>().health -= damage;
            }
            if (Type == Types.Special)
            {
                col.GetComponent<Health>().health -= damage;
                col.GetComponent<Enemy>().speed -= slowAmount;
            }
            Destroy(gameObject);
        }
       
    }
}
