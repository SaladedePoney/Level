using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour{

	GameObject m_target;
    float m_timer = 0.0f;

	public int _Damage = 100;
    public float _Invincibility = 5.0f;

    private void Update()
    {
		m_timer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (m_timer >= _Invincibility)
        {
            if (collision.gameObject.CompareTag("Enemy"))
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
