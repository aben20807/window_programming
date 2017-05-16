using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]//
public class Controller : MonoBehaviour {

	void Awake()    //execute once at first no matter script is enable or not
    {               // Use this for initialization, execute before Start()
        //Debug.Log("Awake");
    }
    
	void Start ()   //execute once at first and script is enable
    {               // Use this for initialization, execute after Awake()
        //Debug.Log("Start");

        Transform t = GetComponent<Transform>();    //<>: templete
        //MeshRenderer mr = GetComponent<MeshRenderer>();
        //gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();

        //t.localScale = 5 * Vector3.one;
        //mr.material.color = Color.red;
        animator = GetComponent<Animator>();
    }
	
	
	void Update ()  //Update is called once per frame (default 60 frames per second)
    {
        animator.SetInteger("Mode", 0);//default idel
        //Debug.Log("Update");
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
            //Time.deltaTime: move smoothly
            //Vector3.forward: direct
            //rb.velocity = moving_speed * Time.deltaTime * Vector3.forward;
            animator.SetInteger("Mode", 1);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.left;
            animator.SetInteger("Mode", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
            animator.SetInteger("Mode", 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.right;
            animator.SetInteger("Mode", 1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jump_speed * Vector3.up);
        }
        //if (Input.GetMouseButtonDown(0))
        if (Input.GetKey(KeyCode.J))
        {
            if(bullet != null)
            {
                GameObject new_bullet = Instantiate(bullet);

                new_bullet.transform.localPosition = transform.position + 2 * Vector3.right;
                new_bullet.GetComponent<Rigidbody>().velocity = shooting_speed * Vector3.right;

                Destroy(new_bullet, 2);
            }
        }
    }

    public float moving_speed, jump_speed, shooting_speed;
    Rigidbody rb;
    Animator animator;
    public GameObject bullet;
}
