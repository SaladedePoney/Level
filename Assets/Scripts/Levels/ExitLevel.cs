﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {

    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

    bool isCoroutineStarted;
    [SerializeField] bool isTrigged;
    ParticleSystem m_exit;

    private GameObject _Player;

    public string _LevelName;
    public GameObject _Spawn;
    private Text LevelNameText;
    public GameObject _FallCheck;

    private void Start()
    {
        _Player = publicVariableHolder1StLevel.Player;
        LevelNameText = publicVariableHolder1StLevel.LevelName;
        m_exit = GetComponentInChildren<ParticleSystem>();
        m_exit.Play();

    }

    private void Update()
    {
        if (isTrigged && !isCoroutineStarted)
        {
            StartCoroutine("PlayerEvent");
        }
		
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigged = true;
        }

        else return;

    }

    private void OnTriggerExit(Collider other)
    {
        isTrigged = false; 
    }

    private IEnumerator PlayerEvent()
    {

        isCoroutineStarted = true;
        _FallCheck.SetActive(false);

        GameObject.FindWithTag("Fader").GetComponent<ScreenFader>().StartCoroutine("FadeIn");

        yield return new WaitForSeconds(2);

        LevelNameText.text = _LevelName;
        LevelNameText.GetComponent<Animator>().Play("Fade In (Text Level)");

		yield return new WaitForSeconds(2);

        _Player.transform.position = _Spawn.transform.position + new Vector3(0, 2, 0);

        LevelNameText.GetComponent<Animator>().Play("Fade Out (Text Level)");

		yield return new WaitForSeconds(2);

		GameObject.FindWithTag("Fader").GetComponent<ScreenFader>().StartCoroutine("FadeOut");

        _Player.GetComponent<UIControler>().ResetToken();

        isTrigged = false;
        isCoroutineStarted = false;

    }
}
