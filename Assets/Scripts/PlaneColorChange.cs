using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColorChange : MonoBehaviour {

    public Material Default;
    public Material Ball;

    Renderer m_rend;
    public bool isTrigged;

    private void Start()
    {
        m_rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider m_collider)
    {
        if (m_collider.gameObject.CompareTag("Player") && m_collider.GetComponent<isTrigged>().IsTrigged == false)
        {
            m_rend.material = new Material(Ball);
            m_collider.GetComponent<isTrigged>().IsTrigged = true;
        }
    }

    private void OnTriggerStay(Collider m_collider)
    {
        if (m_collider.CompareTag("Player"))
        {     
                m_rend.material = new Material(Ball);
        }
    }

    private void OnTriggerExit(Collider m_collider)
    {
        if (m_collider.CompareTag("Player"))
        {
            m_rend.material = new Material(Default);
            m_collider.GetComponent<isTrigged>().IsTrigged = false;
        }
    }
}
