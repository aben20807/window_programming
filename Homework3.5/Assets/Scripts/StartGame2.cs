using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGame2 : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData e)
    {
        //Debug.Log("click");
        SceneManager.LoadScene(2);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
