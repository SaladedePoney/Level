using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshvsCam : MonoBehaviour {

    MeshRenderer m_mesh;

    private void Start()
    {
        m_mesh = GetComponent<MeshRenderer>();
    }


    void OnTriggerEnter(Collider other)
    {
            m_mesh.enabled = false;  
    }

    private void OnTriggerExit(Collider other)
    {
            m_mesh.enabled = true;
    }
}
