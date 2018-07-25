using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBottomFixed : MonoBehaviour {

    public GameObject Sphere;

    Rigidbody m_rb;
    Vector3 m_newPos;
    Vector3 m_col;
    Vector3 m_currentVel;
    Vector3 finalpos;
    //[SerializeField] bool m_boolcol = false;


    ContactPoint m_contact;


    private void Start()
    {
        m_rb = GetComponent<Rigidbody> ();
    }

    private void FixedUpdate()
    {
        {
            m_newPos.x = Sphere.transform.localPosition.x;
            m_newPos.z = Sphere.transform.localPosition.y;
            m_newPos.y = m_col.y;

            finalpos = new Vector3(m_newPos.x, m_newPos.y, m_newPos.z);

            Sphere.transform.position = Vector3.Lerp(Sphere.transform.localPosition, finalpos, 0.0000001f);

            m_currentVel = m_rb.velocity;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") && Sphere.GetComponent<Jump>()._Jump == true)
        {
            Sphere.GetComponent<Jump>()._Jump = false;
        }

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("BeamTarget") && Sphere.GetComponent<Jump>()._Jump == false)
        {
                m_contact = collision.contacts[0];
           

                if (System.Math.Abs(m_contact.normal.z) > System.Math.Abs(m_contact.normal.x))
                {
                    m_newPos = new Vector3(m_currentVel.x, m_currentVel.y, -m_currentVel.z);
                    m_rb.velocity = m_newPos;

                }

                else if (System.Math.Abs(m_contact.normal.x) > System.Math.Abs(m_contact.normal.z))
                {
                    m_newPos = new Vector3(-m_currentVel.x, m_currentVel.y, m_currentVel.z);
                    m_rb.velocity = m_newPos;

                }
                else if (System.Math.Abs(m_contact.normal.y) > Mathf.Epsilon) return;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            collision.transform.GetComponent<MovePlane>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Floor")){
            m_col = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
		if (collision.gameObject.CompareTag("Floor"))
		{
            collision.transform.GetComponent<MovePlane>().enabled = false;
        }
    }
}
