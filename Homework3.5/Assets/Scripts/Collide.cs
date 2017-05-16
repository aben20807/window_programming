using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collide : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Transform t = GetComponent<Transform>();    //<>: templete
        //MeshRenderer mr = GetComponent<MeshRenderer>();
        //gameObject.AddComponent<Rigidbody>();

        //t.localScale = 5 * Vector3.one;
        //if (this.gameObject.name == "TriggerA")
        //    mr.material.color = Color.red;
        //else
        //    mr.material.color = Color.blue;
        LifePoint = 2000;
        //Debug.Log(this.gameObject.name + " " +LifePoint);
        isGameover = false;
        once = false;
        //lifePointmesh = GameObject.Find("LifePointA").GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isGameover == false && this.GetComponent<Transform>().position.y < -2)
        {
            LifePoint = 0;
        }

        if (LifePoint == 0 && isGameover == false)
        {
            isGameover = true;
        }

        if (isGameover == true && once == false)
        {
            once = true;
            if (LifePoint > 0)
                lifePointmesh.text += "\nCongratulations!!";
            if (LifePoint == 0)
            {
                lifePointmesh.text += "\nYou Lose!!";
            }
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.name == "Bullet1(Clone)" && isGameover == false && (this.gameObject.name == "Mimi" || this.gameObject.name == "Taiki"))
        {
            LifePoint -= 200;
            Destroy(collider.gameObject);
            //Debug.Log(Score.ToString());
        }
        if (collider.gameObject.name == "Bullet2(Clone)" && isGameover == false && (this.gameObject.name == "Mimi" || this.gameObject.name == "Taiki"))
        {
            LifePoint -= 50;
            Destroy(collider.gameObject);
            //Debug.Log(Score.ToString());
        }

    }
    int lifePoint;
    public static bool isGameover;
    bool once;
    int LifePoint
    {
        set
        {
            if (value >= 0)
            {
                lifePoint = value;
                lifePointmesh.text = lifePoint.ToString();
            }
        }
        get { return lifePoint; }
    }
    public TextMesh lifePointmesh;
}
