using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PullingJump : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;
    private bool isCanJump;

    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        //SpaceÇâüÇµÇΩÇÁÉWÉÉÉìÉv
        //if(Input.GetKeyDown(KeyCode.Space)) { 
        //    rb.velocity=new Vector3(0,10,0);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;
            if (dist.sqrMagnitude == 0) { return; }
            rb.velocity = dist.normalized * jumpPower;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("è’ìÀÇµÇΩ");
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("ê⁄êGíÜ");
       // isCanJump = true;

        ContactPoint[] contacts = collision.contacts;
        Vector3 otherNormal = contacts[0].normal;
        Vector3 upVector = new Vector3(0, 1, 0);
        float dotUN=Vector3.Dot(upVector, otherNormal);
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        if (dotDeg <= 45)
        {
            isCanJump = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("ó£íEÇµÇΩ");
        isCanJump = false;
    }


}
