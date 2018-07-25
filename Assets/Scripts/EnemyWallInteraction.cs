using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallInteraction : MonoBehaviour {

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
		m_rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
			m_currentVel = m_rb.velocity;
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Wall"))
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
}
