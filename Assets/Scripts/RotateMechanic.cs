using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMechanic : MonoBehaviour
{
    public GameObject cameraP;
    private float rotateSpeed = 15f;
    private bool rotate = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("f"))
        {
            StartCoroutine(rotateClockwise(90));
            Debug.Log("Work?");
        }
        if (Input.GetKeyDown("g"))
        {
            StartCoroutine(rotateCounterClock(90));
            Debug.Log("Work2?");
        }


    }

    public IEnumerator rotateClockwise(float rotateAngle)
    {
        //Sets swing to true, so it's locked
        rotate = true;
        //Does a loop over each frame(?). swingAngle is an integer that you declare in the GetKey function to dictate how far you want the swing to go.
        for (int frameNumber = 1; frameNumber < rotateSpeed + 1; frameNumber++)
        {
            transform.Rotate(Vector3.forward, rotateAngle / rotateSpeed, Space.Self);
            cameraP.transform.Rotate(Vector3.forward, -1 * rotateAngle / rotateSpeed, Space.Self);
            yield return null;
        }
        //Allows you to rotate again, once the swing animation finishes.
        rotate = false;
    }
    public IEnumerator rotateCounterClock(float rotateAngle)
    {
        //Sets swing to true, so it's locked
        rotate = true;
        //Does a loop over each frame(?). swingAngle is an integer that you declare in the GetKey function to dictate how far you want the swing to go.
        for (int frameNumber = 1; frameNumber < rotateSpeed + 1; frameNumber++)
        {
            transform.Rotate(Vector3.forward, -1 * rotateAngle / rotateSpeed, Space.Self);
            cameraP.transform.Rotate(Vector3.forward, rotateAngle / rotateSpeed, Space.Self);
            yield return null;
        }
        //Allows you to rotate again, once the swing animation finishes.
        rotate = false;
    }


    /*
     *  for (int frameNumber = 1; frameNumber < rotateSpeed + 1; frameNumber++)
        {
            cameraP.transform.Rotate(Vector3.forward, swingAngle / rotateSpeed, Space.Self);
            yield return null;
        }








            private bool basePosition = true;
            private bool leftPosition = false;
            private bool rightPosition = false;
            private bool upsidedownPosition = false;








            if (gameObject.transform.rotation.z > 88 && gameObject.transform.rotation.z < 90)
        {
            basePosition = false;
            leftPosition = true;
            rightPosition = false;
            upsidedownPosition = false;
        }
        if (gameObject.transform.rotation.z < -88 && gameObject.transform.rotation.z > -90)
        {
            basePosition = false;
            leftPosition = false;
            rightPosition = true;
            upsidedownPosition = false;
        }
        if (gameObject.transform.rotation.z < -178 && gameObject.transform.rotation.z > -180)
        {
            basePosition = false;
            leftPosition = false;
            rightPosition = false;
            upsidedownPosition = true;
            Debug.Log("up");
        }
        if (gameObject.transform.rotation.z > 178 && gameObject.transform.rotation.z < 180)
        {
            basePosition = false;
            leftPosition = false;
            rightPosition = false;
            upsidedownPosition = true;
            Debug.Log("up");
        }
        if (gameObject.transform.rotation.z > 0 && gameObject.transform.rotation.z < 2)
        {
            basePosition = false;
            leftPosition = true;
            rightPosition = false;
            upsidedownPosition = false;
            Debug.Log("base");
        }
        if (gameObject.transform.rotation.z < 0 && gameObject.transform.rotation.z > -2)
        {
            basePosition = false;
            leftPosition = true;
            rightPosition = false;
            upsidedownPosition = false;
            Debug.Log("base");
        }
















     */




}
