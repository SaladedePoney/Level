using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour {

    public GameObject _Launcher;
    public float _BeamLength = 10.0f;

	void Start () {
		
	}
	

	void Update () {

		GetComponent<LineRenderer>().SetPosition(0, _Launcher.transform.position);
		GetComponent<LineRenderer>().SetPosition(1, _Launcher.transform.position + (_Launcher.transform.forward * _BeamLength));
	}
}
