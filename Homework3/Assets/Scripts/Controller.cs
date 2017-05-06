using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]//
[RequireComponent(typeof(Collider))]
public class Controller : MonoBehaviour {

	void Awake()    //execute once at first no matter script is enable or not
    {               // Use this for initialization, execute before Start()
        //Debug.Log("Awake");
    }
    
	void Start ()   //execute once at first and script is enable
    {               // Use this for initialization, execute after Awake()
        //Debug.Log("Start");

        //Transform t = GetComponent<Transform>();    //<>: templete
        MeshRenderer mr = GetComponent<MeshRenderer>();
        //gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();

        //t.localScale = 5 * Vector3.one;
        mr.material.color = Color.red;
        
    }


    void Update ()  //Update is called once per frame (default 60 frames per second)
    {
        //Debug.Log("Update");
        
        if(this.gameObject.name == "CubeA")
        {
            if (Input.GetKey(KeyCode.W) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
                //Debug.Log(this.gameObject.name);
            }
            if (Input.GetKey(KeyCode.A) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.left;
            }
            if (Input.GetKey(KeyCode.S) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
            }
            if (Input.GetKey(KeyCode.D) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.right;
            }
            if (Input.GetKeyDown(KeyCode.Z) && Collide.isGameover == false)
            {
                if (transform.localPosition.y <= 3) rb.AddForce(jump_speed * Vector3.up);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (bullet != null)
                {
                    GameObject new_bullet = Instantiate(bullet);

                    new_bullet.transform.localPosition = transform.position + 2 * Vector3.right;
                    new_bullet.GetComponent<Rigidbody>().velocity = shooting_speed * Vector3.right;

                    Destroy(new_bullet, 4);
                }
            }
            if (Input.GetKey(KeyCode.C))
            {
                if (bullet != null)
                {
                    GameObject new_bullet = Instantiate(bullet);

                    new_bullet.transform.localPosition = transform.position + 2 * Vector3.right;
                    new_bullet.GetComponent<Rigidbody>().velocity = shooting_speed * Vector3.right;

                    Destroy(new_bullet, 4);
                }
            }
        }

        if (this.gameObject.name == "CubeB")
        {
            if (Input.GetKey(KeyCode.UpArrow) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
                //Debug.Log(this.gameObject.name);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.left;
            }
            if (Input.GetKey(KeyCode.DownArrow) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
            }
            if (Input.GetKey(KeyCode.RightArrow) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.right;
            }
            if (Input.GetKeyDown(KeyCode.I) && Collide.isGameover == false)
            {
                if(transform.localPosition.y <= 3) rb.AddForce(jump_speed * Vector3.up);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (bullet != null)
                {
                    GameObject new_bullet = Instantiate(bullet);

                    new_bullet.transform.localPosition = transform.position + 2 * Vector3.left;
                    new_bullet.GetComponent<Rigidbody>().velocity = shooting_speed * Vector3.left;

                    Destroy(new_bullet, 4);
                }
            }
            if (Input.GetKey(KeyCode.P))
            {
                if (bullet != null)
                {
                    GameObject new_bullet = Instantiate(bullet);

                    new_bullet.transform.localPosition = transform.position + 2 * Vector3.left;
                    new_bullet.GetComponent<Rigidbody>().velocity = shooting_speed * Vector3.left;

                    Destroy(new_bullet, 4);
                }
            }
        }
    }

    

    public float moving_speed, jump_speed, shooting_speed;
    public GameObject bullet;

    Rigidbody rb;
}
