using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collide : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Transform t = GetComponent<Transform>();    //<>: templete
        MeshRenderer mr = GetComponent<MeshRenderer>();
        //gameObject.AddComponent<Rigidbody>();

        //t.localScale = 5 * Vector3.one;
        if (this.gameObject.name == "TriggerA")
            mr.material.color = Color.red;
        else
            mr.material.color = Color.blue;
        LifePoint = 2000;
        isGameover = false;
        once = false;
        //lifePointmesh = GameObject.Find("LifePointA").GetComponent<TextMesh>();

    }
	
	// Update is called once per frame
	void Update () {
        if (LifePoint == 0)
        {
            isGameover = true;
        }
        
        if(isGameover == true && once == false)
        {
            once = true;
            if(LifePoint > 0)
                lifePointmesh.text += "\nCongratulations!!";
            else
                lifePointmesh.text += "\nYou Lose!!";
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Bullet(Clone)" && isGameover == false)
        {
            LifePoint -= 100;
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
            if(value >= 0)
            {
                lifePoint = value;
                lifePointmesh.text = lifePoint.ToString();
            }
        }
        get { return lifePoint; }
    }
    public TextMesh lifePointmesh;
}
