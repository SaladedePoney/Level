using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBattle : MonoBehaviour {

    Canvas m_cav;
    private float invincibility;

    public int damage;

    private void Start()
    {
        m_cav = GetComponentInChildren<Canvas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && m_cav.enabled == false)
        {
            m_cav.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && invincibility >= 1f)
        {
            DamageData dmgData = new DamageData();
            dmgData.damage = damage;

            MessageHandler msgHandler = collision.gameObject.GetComponent<MessageHandler>();

            if (msgHandler)
            {
                msgHandler.GiveMessage(MessageTypes.DAMAGED, collision.gameObject, dmgData);
            }
            invincibility = 0;
        }
    }

    private void Update()
    {
        invincibility += Time.deltaTime;
    }
}
