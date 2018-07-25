using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbStairs : MonoBehaviour {

    Rigidbody m_rb;
    float StraffeForce = 0.1f;
    float JumpForceUp = 5.0f;


    private void OnCollisionEnter (Collision collision)
    {
        m_rb = collision.transform.GetComponent<Rigidbody>();
        m_rb.AddForce(new Vector3(m_rb.velocity.x * StraffeForce, JumpForceUp, m_rb.velocity.z * StraffeForce), ForceMode.Impulse);
    }
}
