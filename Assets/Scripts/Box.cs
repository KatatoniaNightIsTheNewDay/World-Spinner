using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody boxBody;
    private bool buttonActivate = false;
    public GameObject gate;
    // Start is called before the first frame update
    void Start()
    {
        boxBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("button") && buttonActivate == false)
        {
            boxBody.constraints = RigidbodyConstraints.FreezeAll;
            
            Destroy(gate);
            buttonActivate = true;

        }
    }

}
