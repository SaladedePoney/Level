using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour {

    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

    public int SpawnPointNumber;
    private GameObject AttackSlider;

    private void Start()
    {
        AttackSlider = publicVariableHolder1StLevel.AttackSlider;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject.Find("PauseMenu").GetComponent<PauseMenu>().SetLastCheckpoint(SpawnPointNumber);
            if (AttackSlider.activeSelf == false)
            {
                AttackSlider.SetActive(true);
            }
        }
    }
}
