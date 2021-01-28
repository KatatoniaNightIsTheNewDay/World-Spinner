using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
    float distance;
    private Transform target;
    public GameObject bulletPrefab;
    private bool firedBullet = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(target.position, transform.position);
       // print("Distance to other: " + distance);
        if (distance < 8f && firedBullet == false)
        {
            shootOnSight();
            print("FIRE");
        }


        
    }

    public void shootOnSight()
    {
        firedBullet = true;
        Instantiate(bulletPrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation, this.transform);
        StartCoroutine(cooldown());
    }

   public IEnumerator cooldown()
    {

        int index;
        for (index = 0; index < 10; index++)
        {
            yield return new WaitForSeconds(0.12f);
        }
        firedBullet = false;
    }



}
