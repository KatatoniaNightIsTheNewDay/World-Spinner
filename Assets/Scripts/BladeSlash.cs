using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeSlash : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Player") && player.invulnerable == false)
        {
            Debug.Log("Did you see this?");
            player.health--;
            player.healthText.text = "Health: " + player.health;
            player.invulnerable = true;
            player.damaged();
        }

    }
    */
}
