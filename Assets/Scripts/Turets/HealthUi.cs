using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour {

    public Slider slider;
    public Canvas cav;

	void Start () {
        
        MessageHandler msgHandler = GetComponent<MessageHandler>();

        if (msgHandler)
        {
            msgHandler.RegisterDelegate(RecieveMessage);
        }
    }

    private void Update()
    {
        cav.transform.LookAt(Camera.main.transform);
    }

    void RecieveMessage(MessageTypes msgType, GameObject go, MessageData msgData)
    {
        switch (msgType)
        {
            case MessageTypes.HEALTHCHANGED:
                HealthData hpData = msgData as HealthData;

                if (hpData != null)
                {
                    UpdateUi(hpData.maxHealth, hpData.curHealth);
                }
                break;
        }

    }

	void UpdateUi(int maxHealth, int curHealth)
    {
        slider.value = 1.0f - ((1.0f / maxHealth) * curHealth);
    }
}
