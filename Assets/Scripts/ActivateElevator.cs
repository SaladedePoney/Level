using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateElevator : MonoBehaviour {
    
    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

	public GameObject _LevelActive;
	private GameObject _Player;
    public AnimationClip _Clip;

    Animator m_anim;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        _Player = publicVariableHolder1StLevel.Player;
    }

    void Update () {
        
		if (_Player.GetComponent<UIControler>().TokenCount == _LevelActive.GetComponent<Level>().TokenNumbers)
		{
            m_anim.Play(_Clip.name);
		}
	}
}
