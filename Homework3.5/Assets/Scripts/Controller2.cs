using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]//
[RequireComponent(typeof(Collider))]
public class Controller2 : MonoBehaviour
{

    void Awake()    //execute once at first no matter script is enable or not
    {               // Use this for initialization, execute before Start()
        //Debug.Log("Awake");
    }

    void Start()   //execute once at first and script is enable
    {               // Use this for initialization, execute after Awake()
        //Debug.Log("Start");

        //Transform t = GetComponent<Transform>();    //<>: templete
        //MeshRenderer mr = GetComponent<MeshRenderer>();
        //gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();

        //t.localScale = 5 * Vector3.one;
        //mr.material.color = Color.red;
        animator = GetComponent<Animator>();
    }


    void Update()  //Update is called once per frame (default 60 frames per second)
    {
        //Debug.Log("Update");
        animator.SetInteger("Mode", 0);//default idel
        if (this.gameObject.name == "Mimi")
        {
            if (Input.GetKey(KeyCode.W) && Collide2.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
                animator.SetInteger("Mode", 1);
                //Debug.Log(this.gameObject.name);
            }
            if (Input.GetKey(KeyCode.A) && Collide2.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.left;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKey(KeyCode.S) && Collide2.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKey(KeyCode.D) && Collide2.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.right;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKeyDown(KeyCode.Z) && Collide2.isGameover == false)
            {
                if (transform.localPosition.y <= 3) rb.AddForce(jump_speed * Vector3.up);
            }
            
        }

        if (this.gameObject.name == "Taiki")
        {
            if (Input.GetKey(KeyCode.UpArrow) && Collide2.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
                //Debug.Log(this.gameObject.name);
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Collide2.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.left;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKey(KeyCode.DownArrow) && Collide2.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKey(KeyCode.RightArrow) && Collide2.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.right;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKeyDown(KeyCode.I) && Collide2.isGameover == false)
            {
                if (transform.localPosition.y <= 3) rb.AddForce(jump_speed * Vector3.up);
            }
            
        }
    }


    public float moving_speed, jump_speed, shooting_speed;
    Rigidbody rb;
    Animator animator;
}
