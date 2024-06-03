using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;

    // Start is called before the first frame update
    void Start()
    {
        
        rb= gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        //Space‚ð‰Ÿ‚µ‚½‚çƒWƒƒƒ“ƒv
        //if(Input.GetKeyDown(KeyCode.Space)) { 
        //    rb.velocity=new Vector3(0,10,0);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            clickPosition=Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 dist=clickPosition-Input.mousePosition;
            if (dist.sqrMagnitude == 0) { return; }
            rb.velocity = dist.normalized * jumpPower;
        }

    }
}
