using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

    public int TokenNumbers = 5;
    private Text TokenLevelText;
    public bool isTrigged;

    private void Start()
    {
        TokenLevelText = publicVariableHolder1StLevel.TokenLevelText;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TokenLevelText.text = "Collect : " + TokenNumbers + " tokens ";
            isTrigged = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTrigged = false;
    }
}
