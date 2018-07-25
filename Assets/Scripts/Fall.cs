using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {

    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

    public GameObject _Spawn;

    Collider col;
    private PauseMenu PauseMenu;

    private void Start()
    {
        PauseMenu = publicVariableHolder1StLevel.PauseMenu;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("here");
            col = collision;
            PauseMenu.ResetGame();
        }
    }
}
