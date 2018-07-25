using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateExitLevel : MonoBehaviour {

    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

	public GameObject _LevelActive;
	private GameObject _Player;

    private void Start()
    {
        _Player = publicVariableHolder1StLevel.Player;
    }

    private void Update()
    {
        if (_Player.GetComponent<UIControler>().TokenCount == _LevelActive.GetComponent<Level>().TokenNumbers)
        {
            this.GetComponent<ExitLevel>().enabled = true;
        }
    }
}
