using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthControler : MonoBehaviour {

    public int totalHealth = 100;
    [SerializeField] int currentHealth;

    public bool isBoss;
    public bool isTargeted;

    MessageHandler m_messageHandler;

    private void Start()
    {
        currentHealth = totalHealth;
        m_messageHandler = GetComponent<MessageHandler>();

        if (m_messageHandler)
        {
            m_messageHandler.RegisterDelegate(RecieveMessage);
        }

    }

    void RecieveMessage(MessageTypes msgType, GameObject go, MessageData msgData)
    {
        switch (msgType)
        {
            case MessageTypes.DAMAGED:
                DamageData dmgData = msgData as DamageData;

                if(dmgData != null)
                {
                    ApplyDamage(dmgData.damage, go);
                }
                break;
        }
    }

    public void ApplyDamage(int damage, GameObject go)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f )
        {
            currentHealth = 0;

            if (m_messageHandler)
            {
                DeathData deathData = new DeathData();
                deathData.attacker = go;
                deathData.attacked = gameObject;

                m_messageHandler.GiveMessage(MessageTypes.DIED, gameObject, deathData);
            }

            if (gameObject.CompareTag("Player"))
            {
                GameObject.Find("PauseMenu").GetComponent<PauseMenu>().ResetGame();
                currentHealth = totalHealth;
            }
            if(isBoss)
            {
                Destroy(this.gameObject, 1f);
                EventManager.TriggerEvent("victory");
            }
        }

        if (m_messageHandler)
        {
            HealthData hpData = new HealthData();

            hpData.maxHealth = totalHealth;
            hpData.curHealth = currentHealth;

            m_messageHandler.GiveMessage(MessageTypes.HEALTHCHANGED, gameObject, hpData);
        }
    }
}
