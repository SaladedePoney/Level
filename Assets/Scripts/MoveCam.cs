using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour {

    public GameObject _Sphere;
    public float _Smooth = 1.0f;
    public bool _ChangeMov;
    public Vector3 _ChangeMovVector;
    public Vector3 _ChangeRotationVector;

    Camera m_cam;
    Vector3 m_newCamPos;
    Quaternion m_newCamRotation;
    Quaternion m_initialRotation;

    void Start () 
    {
        m_cam = GetComponent<Camera>();
        m_initialRotation = gameObject.transform.rotation;
	}
	
	void FixedUpdate() 
    {
		//    ChangeCamMov();
		m_newCamPos = new Vector3(_Sphere.transform.position.x - 6.0f,
							 _Sphere.transform.position.y + 6.5f, _Sphere.transform.localPosition.z - 0.685f);
        m_cam.transform.localPosition = Vector3.Lerp(m_cam.transform.localPosition, m_newCamPos, _Smooth * Time.fixedDeltaTime);
//        m_cam.transform.localRotation.eulerAngles = Vector3.Lerp(m_cam.transform.localRotation.eulerAngles, m_newCamRotation.eulerAngles, _Smooth * Time.fixedDeltaTime);
	}

  /*  void ChangeCamMov ()
    {
        if (!_ChangeMov)
        {
            m_newCamPos = new Vector3(_Sphere.transform.position.x - 6.0f,
                              _Sphere.transform.position.y + 6.5f, _Sphere.transform.localPosition.z - 0.685f);
        }
        if(_ChangeMov)
        {
            GetChangeMovVector(_ChangeMovVector);
            GetChangeMovRotation(_ChangeRotationVector);
        }
	}

    void GetChangeMovVector(Vector3 vectorIn)
    {

		m_newCamPos = new Vector3(_Sphere.transform.position.x - vectorIn.x,
								  _Sphere.transform.position.y + -vectorIn.y, _Sphere.transform.localPosition.z - vectorIn.z);
    }

    void GetChangeMovRotation (Vector3 vectorIn)
    {
		m_newCamRotation.eulerAngles = new Vector3();
    }
*/
}
