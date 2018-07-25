using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCanvasMove : MonoBehaviour {

    public GameObject _Player;

    Vector3 m_initialPosition = new Vector3(0.0f, 0.9f,0.0f);
    Canvas cav;

    private void Start()
    {
        cav = GetComponent<Canvas>();
    }


    private void Update () 
    {
        this.transform.position = _Player.transform.position + m_initialPosition;
        //cav.transform.rotation = Quaternion.Euler(-43f, -90f, 0.0f);
    }
}
