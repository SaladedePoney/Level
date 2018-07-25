using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingProjectile : BaseProjectiles {

    GameObject m_target;
    GameObject m_launcher;
    int m_damage;

    Vector3 m_lastKnownPosition;

    void Update()
    {
        if (m_target)
        {
            m_lastKnownPosition = m_target.transform.position;
        }
        else
        {
            if(transform.position == m_lastKnownPosition)
            {
                Destroy(gameObject);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, m_lastKnownPosition, speed * Time.deltaTime);

    }

    public override void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed)
    {
        if (target)
        {
            m_target = target;
            m_lastKnownPosition = target.transform.position;
            m_launcher = launcher;
            m_damage = damage;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == m_target)
        {
            DamageData dmgData = new DamageData();
            dmgData.damage = m_damage;

            MessageHandler msgHandler = m_target.GetComponent<MessageHandler>();

            if (msgHandler)
            {
                msgHandler.GiveMessage(MessageTypes.DAMAGED, m_launcher, dmgData);
            }
        }
    }
}
