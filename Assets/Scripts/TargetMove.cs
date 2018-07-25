using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour {

    public Vector3 _InitPos;
    public Vector3 _FinalPos;
    public GameObject _Target;
    public float _AttackCd = 4.0f;
    public float _StartAttack = 2.0f;
    public float _MoveSpeed;
    public ParticleSystem _Wildfire;
    public GameObject _Plane;
    public int damage = 100;
    private Collider m_collider;

    [SerializeField]float m_timer = 0.0f;

    private void Start()
    {
        m_collider = GetComponent<Collider>();
    }

    void Update () 
    {
        float step= Time.deltaTime * _MoveSpeed;

        if (m_timer > _AttackCd) 
        {
            ResetPos();
            m_timer = 0.0f;
        }

        if (m_timer >= (_StartAttack - 1.5f) && m_timer < _StartAttack && _Plane.GetComponent<PlaneBlink>().isCoroutineStarted == false)
        {
            _Plane.GetComponent<PlaneBlink>().StartCoroutine("Blink");
        }

        if (m_timer > _StartAttack)
        {
            this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, _FinalPos, step);
            gameObject.GetComponentInParent<BeamTrigger>().DestroyFire();
        }

        if(m_timer >= 3.3f)
        {
            m_collider.enabled = false;   
        }

        m_timer += Time.deltaTime;
	}

    private void ResetPos()
    {
        this.gameObject.SetActive(false);
        this.transform.localPosition = _InitPos;
		this.gameObject.SetActive(true);
        m_collider.enabled = true;
    }

    public void SetFire()
    {
		Instantiate(_Wildfire, this.transform.position, this.transform.rotation);
    }
}
