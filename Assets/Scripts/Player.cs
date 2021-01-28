using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int speed;
    private CharacterController playerController;
    public static float jumpVelocity = 18f;
    private Rigidbody playerRigidbody;
    private BoxCollider playerBoxCollider;
    public bool grounded;
    private float gravity = 8f;
    public int health = 3;
    public bool invulnerable;
    public Text winText;
    public Text healthText;
    Scene thisScene;
    public Camera PlayerCam, BoxCam;
    public bool cameraSwitch = false;

    //New Raycast variables to check for ground so that you can jump on the corner of blocks.
    public GameObject corner1;
    public GameObject corner2;
    [SerializeField] private LayerMask layerMaskGrounded;

    Vector3 playerSize;
    Vector3 boxSize;
    


    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        healthText.text = "Health: " + health; 
        GetComponent<MeshRenderer>();
        thisScene = SceneManager.GetActiveScene();
    }

    private void Awake()
    {
        playerRigidbody = transform.GetComponent<Rigidbody>();
        playerBoxCollider = transform.GetComponent<BoxCollider>();
        playerSize = GetComponent<BoxCollider>().size;
        boxSize = new Vector3(playerSize.x, 0.05f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(IsGrounded());

        if (Input.GetKeyDown("t"))
        {
            if (cameraSwitch == false)
            {
                PlayerCam.gameObject.SetActive(false);
                BoxCam.gameObject.SetActive(true);
                cameraSwitch = true;
                Debug.Log("switch!");
            }
            else
            {
                PlayerCam.gameObject.SetActive(true);
                BoxCam.gameObject.SetActive(false);
                cameraSwitch = false;
                Debug.Log("switch!");
            }
        }


        if (Input.GetKey("a"))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }

        if (Input.GetKeyDown("space"))
        {
            if (IsGrounded())
            {
                playerRigidbody.velocity = Vector3.up * jumpVelocity;
                Debug.Log("Jump");
                grounded = false;

            }
        }

       /* if (Input.GetKeyDown("u"))
        {
            RestartScene();
        }*/


        GetComponent<Rigidbody>().AddForce(Physics.gravity * 2f, ForceMode.Acceleration);


        if (health <= 0)
        {
            RestartScene();
        }

    }

    private bool IsGrounded()
    {
       return Physics.Raycast(transform.position, Vector3.down, 1f);
       // return Physics.BoxCast(transform.position, new Vector3(0.5f, 0.5f, 0.5f), Vector3.down);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike") && invulnerable == false)
        {
            health--;
            healthText.text = "Health: " + health;
            invulnerable = true;
            damaged();

        }
        
        if (collision.gameObject.CompareTag("Goal"))
        {
            if (SceneManager.GetActiveScene().name == "Intro_Tutorial")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (SceneManager.GetActiveScene().name == "Level 2")
            {
                winText.enabled = true;
            }

        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Blade") && invulnerable == false)
        {
            Debug.Log("Did you see this?");
            health--;
            healthText.text = "Health: " + health;
            invulnerable = true;
            damaged();
        }
        if (collision.gameObject.CompareTag("Bullet") && invulnerable == false)
        {
            Debug.Log("Did you see this?");
            health--;
            healthText.text = "Health: " + health;
            invulnerable = true;
            damaged();
            Destroy(collision.gameObject);
        }


    }

    public IEnumerator Blink()
    {
        int index;
        for (index = 0; index < 50; index++)
        {
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
        //Failsafe if the capsule doesn't turn on render
        GetComponent<MeshRenderer>().enabled = true;
        invulnerable = false;
    }


    public void damaged()
    {
        invulnerable = true;
        StartCoroutine(Blink());
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(thisScene.name);
    }









    // In progress Code
    //return Physics.Raycast(transform.position, Vector3.down, 1f);
    //return Physics.OverlapArea(corner1.transform.position, corner2.transform.position, LayerMask.NameToLayer("Ground"));
    //return Physics.OverlapBox(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, Vector3.down, transform.rotation, 0.1f, layerMaskGrounded.value);

    //Vector3 boxCenter = transform.position + Vector3.down * (playerSize.y + boxSize.y) * 0.5f;
    //return Physics.OverlapBox(boxCenter, boxSize, Quaternion.identity, layerMaskGrounded.value) != null;

    //RaycastHit raycastHit = Physics.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0f, Vector3.down, 1f);
    //  grounded = true;
    // Debug.Log(raycastHit.collider);
    //return raycastHit.collider != null;
}
