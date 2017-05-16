using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]//
[RequireComponent(typeof(Collider))]
public class Controller : MonoBehaviour
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
            if (Input.GetKey(KeyCode.W) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
                animator.SetInteger("Mode", 1);
                //Debug.Log(this.gameObject.name);
            }
            if (Input.GetKey(KeyCode.A) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.left;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKey(KeyCode.S) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKey(KeyCode.D) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.right;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKeyDown(KeyCode.Z) && Collide.isGameover == false)
            {
                if (transform.localPosition.y <= 3) rb.AddForce(jump_speed * Vector3.up);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (bullet1 != null)
                {
                    GameObject new_bullet = Instantiate(bullet1);
                    new_bullet.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    new_bullet.GetComponent<Transform>().localScale = 2 * Vector3.one;
                    new_bullet.transform.localPosition = transform.position + 2 * Vector3.right;
                    new_bullet.GetComponent<Rigidbody>().velocity = shooting_speed * Vector3.right;

                    Destroy(new_bullet, 4);
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (bullet2 != null)
                {
                    for(int i = -2; i <= 2; i++)
                    {
                        GameObject new_bullet = Instantiate(bullet2);

                        new_bullet.transform.localPosition = transform.position + 4 * Vector3.right + i * Vector3.right;
                        new_bullet.GetComponent<Rigidbody>().velocity = shooting_speed * 1 * Vector3.right + shooting_speed * i * Vector3.forward;
                        //new_bullet.GetComponent<Rigidbody>().velocity = ;
                        //Debug.Log(new_bullet.GetComponent<Rigidbody>().velocity);
                        Destroy(new_bullet, 4);
                    }
                    

                }
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (body != null)
                {
                    for (int i = -2; i <= 2; i++)
                    {
                        GameObject new_body = Instantiate(body);

                        new_body.transform.localPosition = transform.position + 4 * i * Vector3.forward;
                        //Debug.Log(new_body.GetComponent<Rigidbody>().velocity);
                        Destroy(new_body, 6);
                    }


                }
            }
        }

        if (this.gameObject.name == "Taiki")
        {
            if (Input.GetKey(KeyCode.UpArrow) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
                //Debug.Log(this.gameObject.name);
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.left;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKey(KeyCode.DownArrow) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKey(KeyCode.RightArrow) && Collide.isGameover == false)
            {
                transform.localPosition += moving_speed * Time.deltaTime * Vector3.right;
                animator.SetInteger("Mode", 1);
            }
            if (Input.GetKeyDown(KeyCode.I) && Collide.isGameover == false)
            {
                if (transform.localPosition.y <= 3) rb.AddForce(jump_speed * Vector3.up);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (bullet1 != null)
                {
                    GameObject new_bullet = Instantiate(bullet1);
                    new_bullet.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    new_bullet.GetComponent<Transform>().localScale = 2 * Vector3.one;
                    new_bullet.transform.localPosition = transform.position + 2 * Vector3.left;
                    new_bullet.GetComponent<Rigidbody>().velocity = shooting_speed * Vector3.left;

                    Destroy(new_bullet, 4);
                }
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (bullet2 != null)
                {
                    for (int i = -2; i <= 2; i++)
                    {
                        GameObject new_bullet = Instantiate(bullet2);

                        new_bullet.transform.localPosition = transform.position + 4 * Vector3.left + i * Vector3.left;
                        new_bullet.GetComponent<Rigidbody>().velocity = shooting_speed * 1 * Vector3.left + shooting_speed * i * Vector3.forward;
                        //Debug.Log(new_bullet.GetComponent<Rigidbody>().velocity);
                        Destroy(new_bullet, 4);
                    }


                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (body != null)
                {
                    for (int i = -2; i <= 2; i++)
                    {
                        GameObject new_body = Instantiate(body);

                        new_body.transform.localPosition = transform.position + 4 * i * Vector3.forward;
                        //Debug.Log(new_body.GetComponent<Rigidbody>().velocity);
                        Destroy(new_body, 6);
                    }


                }
            }
        }
    }



    public float moving_speed, jump_speed, shooting_speed;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject body;
    Rigidbody rb;
    Animator animator;
}












//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]//
//public class Controller : MonoBehaviour {

//	void Awake()    //execute once at first no matter script is enable or not
//    {               // Use this for initialization, execute before Start()
//        //Debug.Log("Awake");
//    }
    
//	void Start ()   //execute once at first and script is enable
//    {               // Use this for initialization, execute after Awake()
//        //Debug.Log("Start");

//        Transform t = GetComponent<Transform>();    //<>: templete
//        //MeshRenderer mr = GetComponent<MeshRenderer>();
//        //gameObject.AddComponent<Rigidbody>();
//        rb = GetComponent<Rigidbody>();

//        //t.localScale = 5 * Vector3.one;
//        //mr.material.color = Color.red;
//        animator = GetComponent<Animator>();
//    }
	
	
//	void Update ()  //Update is called once per frame (default 60 frames per second)
//    {
//        animator.SetInteger("Mode", 0);//default idel
//        //Debug.Log("Update");
//        if (Input.GetKey(KeyCode.W))
//        {
//            transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
//            //Time.deltaTime: move smoothly
//            //Vector3.forward: direct
//            //rb.velocity = moving_speed * Time.deltaTime * Vector3.forward;
//            animator.SetInteger("Mode", 1);

//        }
//        if (Input.GetKey(KeyCode.A))
//        {
//            transform.localPosition += moving_speed * Time.deltaTime * Vector3.left;
//            animator.SetInteger("Mode", 1);
//        }
//        if (Input.GetKey(KeyCode.S))
//        {
//            transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
//            animator.SetInteger("Mode", 1);
//        }
//        if (Input.GetKey(KeyCode.D))
//        {
//            transform.localPosition += moving_speed * Time.deltaTime * Vector3.right;
//            animator.SetInteger("Mode", 1);
//        }
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            rb.AddForce(jump_speed * Vector3.up);
//        }
//        //if (Input.GetMouseButtonDown(0))
//        if (Input.GetKey(KeyCode.J))
//        {
//            if(bullet != null)
//            {
//                GameObject new_bullet = Instantiate(bullet);

//                new_bullet.transform.localPosition = transform.position + 2 * Vector3.right;
//                new_bullet.GetComponent<Rigidbody>().velocity = shooting_speed * Vector3.right;

//                Destroy(new_bullet, 2);
//            }
//        }
//    }

//    public float moving_speed, jump_speed, shooting_speed;
//    Rigidbody rb;
    
//    public GameObject bullet;
//}
