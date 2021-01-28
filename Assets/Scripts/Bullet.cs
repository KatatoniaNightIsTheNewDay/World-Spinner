using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float distance;
    private Transform target;
    private float speed = 4f;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //Vector3 playerPos = new Vector3(target.position.x, target.position.y, target.position.z);

        // Aim bullet in player's direction.
        transform.LookAt(target);

        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the projectile forward towards the player's last known direction;
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    

}
