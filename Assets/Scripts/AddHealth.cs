using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour {

    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

    private Canvas cav;

    private void Start()
    {
        cav = publicVariableHolder1StLevel.PlayerCanvas;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        cav.enabled = true;
    }
}
