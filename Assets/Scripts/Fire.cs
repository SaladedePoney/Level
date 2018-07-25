using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour {

    public GameObject _Explosion;
    public float _AttackCD = 1.0f;

    public ParticleSystem ParticleSystem;
    public GameObject Attack;

    public Slider SpellSlider;
    private bool ParticleSystemStart;
    GameObject m_explosion;
    float m_timer = 0.0f;

    private void Update()
    {
        if (Attack.activeSelf == true)
        {
            m_timer += Time.deltaTime;
            SpellSlider.value = (m_timer / _AttackCD);

            if (m_timer >= _AttackCD)
            {
                if (!ParticleSystemStart)
                {
                    ParticleSystemStart = true;
                    ParticleSystem.Play();
                }

                if (Input.GetButton("Fire1"))
                {
                    m_explosion = Instantiate(_Explosion, this.transform.position, Quaternion.identity) as GameObject;
                    Destroy(m_explosion, 6f);
                    m_timer = 0.0f;
                    ParticleSystemStart = false;
                }

            }
            else
            {
                ParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }

    }


}
