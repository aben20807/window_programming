using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject new_bullet = Instantiate(snow);
        System.Random crandom = new System.Random();
        int num1 = crandom.Next(-100, 100);
        int num2 = crandom.Next(-100, 100);
        new_bullet.GetComponent<MeshRenderer>().material.color = Color.yellow;
        new_bullet.GetComponent<Transform>().localScale = 2 * Vector3.one;
        new_bullet.transform.localPosition = 100 * Vector3.up+num1 * Vector3.right + num2 * Vector3.forward;
        new_bullet.GetComponent<Rigidbody>().velocity = 20 * Vector3.down;
        //Debug.Log(new_bullet.GetComponent<Rigidbody>().velocity);
        Destroy(new_bullet, 10);
    }


    public GameObject snow;
}
