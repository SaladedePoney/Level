using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

    public GameObject _Door;
    public Level _Level;
    private GameObject _Player;

    Animator m_anim;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        _Player = publicVariableHolder1StLevel.Player;
    }

    private void Update()
    {
        if(_Level.TokenNumbers == _Player.GetComponent<UIControler>().TokenCount && _Level.isTrigged == true)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        m_anim.Play("OpenDoor");
    }

    private void DestroyDoor()
    {
        Destroy(_Door);
    }
}
