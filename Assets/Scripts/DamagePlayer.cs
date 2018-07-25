using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour{

	GameObject m_target;
    float m_timer = 0.0f;

	public int _Damage = 100;
    public float _Invincibility = 0.5f;

    private void Update()
    {
		m_timer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (m_timer >= _Invincibility)
        {

            if (collision.gameObject.CompareTag("Player"))
            {
                DamageData dmgData = new DamageData();
                dmgData.damage = _Damage;

                MessageHandler msgHandler = collision.gameObject.GetComponent<MessageHandler>();

                if (msgHandler)
                {
                    msgHandler.GiveMessage(MessageTypes.DAMAGED, m_target, dmgData);
                }
                m_timer = 0.0f;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        m_timer += Time.deltaTime;

        if (m_timer >= _Invincibility)
        {

            if (collision.gameObject.CompareTag("Player"))
            {
                DamageData dmgData = new DamageData();
                dmgData.damage = _Damage;

                MessageHandler msgHandler = collision.gameObject.GetComponent<MessageHandler>();

                if (msgHandler)
                {
                    msgHandler.GiveMessage(MessageTypes.DAMAGED, m_target, dmgData);
                }
            }
            m_timer = 0.0f;
        }
    }
}
