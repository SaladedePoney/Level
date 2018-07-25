using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArena : MonoBehaviour {

    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

    public Vector3 _TargetArea;
    public Vector3 _TargetCam;
    public float _Smoothness = 1.0f;
    public float newFieldofView;

    private GameObject _Camera;
    private Camera m_cam;

    public bool _Collision = false;

    private void Start()
    {
        _Camera = publicVariableHolder1StLevel.MainCamera;
        m_cam = _Camera.GetComponent<Camera>();
    }

    private void Update()
    {
        if(_Collision)
        {
			transform.localPosition = Vector3.Lerp(transform.localPosition, _TargetArea, _Smoothness);
            this.GetComponentInChildren<Animator>().Play("MoveArenaWalls");
            m_cam.fieldOfView = Mathf.Lerp(m_cam.fieldOfView, newFieldofView, _Smoothness);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _Collision = true;
            _Camera.GetComponent<MoveCam>()._ChangeMovVector = _TargetCam;
            _Camera.GetComponent<MoveCam>()._ChangeMov = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _Camera.GetComponent<MoveCam>()._ChangeMov = false;
    }
}
