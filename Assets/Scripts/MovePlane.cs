using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlane : MonoBehaviour {

    public GameObject Plane;
    public float Smooth = 0.1f;

    float m_rotationx;
    float m_rotationy;
    Quaternion m_rotation = Quaternion.identity;

    Quaternion m_originalRotation;

	// Use this for initialization
	void Start () {
        
        m_originalRotation = Plane.transform.localRotation;
    }
	
	// Update is called once per frame
	void Update () {

        float x = -Input.GetAxis("Horizontal");
        float y = -Input.GetAxis("Vertical");

        m_rotationx = x * 45 * Smooth;
        m_rotationy = y * 45 * Smooth;

        m_rotation.eulerAngles = new Vector3(m_rotationx, 0, m_rotationy);

        Plane.transform.localRotation = Quaternion.Slerp(Plane.transform.localRotation, m_rotation * m_originalRotation, 1.5f);

    }

    private void OnTriggerExit(Collider other)
    {
        Plane.transform.localRotation = Quaternion.Slerp(Plane.transform.localRotation, Quaternion.identity, 1.0f);
    }
}
