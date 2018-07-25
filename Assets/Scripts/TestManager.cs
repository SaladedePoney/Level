using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour {

    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

    public bool TestLevel;
    public int TestNumber;


    private GameObject player;
    private GameObject Spawnpoint;


	// Use this for initialization
	void Start () 
    {
        player = publicVariableHolder1StLevel.Player;

        Spawnpoint = GameObject.Find("Spawn" + TestNumber.ToString());

        if(TestLevel)
        {
            player.transform.position = Spawnpoint.transform.position;
        }
	}
}
