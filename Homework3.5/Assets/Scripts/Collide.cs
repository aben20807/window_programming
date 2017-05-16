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
        mr.material.color = Color.red;
        Score = 0;
        scoremesh = GameObject.Find("Score").GetComponent<TextMesh>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Score >= 10)
        {
            scoremesh.text = "Congratulations!!";
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Bullet(Clone)")
        {
            Score++;
            Destroy(collider.gameObject);
            //Debug.Log(Score.ToString());
           
        }
        
    }

    int score;
    int Score
    {
        set {
            score = value;
            scoremesh.text = score.ToString();
        }
        get { return score; }
    }
    public TextMesh scoremesh;
}
