using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : BaseProjectiles {

    Vector3 m_direction;
    bool m_fired;

    GameObject m_launcher;
    GameObject m_target;
    int m_damage;

    private void Update()
    {

        if (m_fired)
        {
            transform.position += m_direction * (speed * Time.deltaTime);
        }
    }

    public override void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed)
    {
        if(launcher && target)
        {
            m_direction = (target.transform.position - launcher.transform.position).normalized;
            m_fired = true;
            m_launcher = launcher;
            m_target = target;
            m_damage = damage;

            Destroy(gameObject, 10.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject == m_target)
        {
            DamageData dmgData = new DamageData();
            dmgData.damage = m_damage;

            MessageHandler msgHandler = m_target.GetComponent<MessageHandler>();

            if (msgHandler)
            {
                msgHandler.GiveMessage(MessageTypes.DAMAGED, m_launcher, dmgData);
            }

            Destroy(gameObject);
        }
    }
}
