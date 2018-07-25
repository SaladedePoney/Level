using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public float JumpForceUp = 20f;
	public float StraffeForce = 1.0f;
    public bool _Jump;

    Rigidbody m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _Jump == false)
              DoJump();
    }

    private void DoJump()
    {
        _Jump = true;
        m_rb.velocity = new Vector3(m_rb.velocity.x, 0f, m_rb.velocity.z);
        m_rb.AddForce(new Vector3(m_rb.velocity.x * StraffeForce, JumpForceUp, m_rb.velocity.z * StraffeForce), ForceMode.Impulse);
    }
}
