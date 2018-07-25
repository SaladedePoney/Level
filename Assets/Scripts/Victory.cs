using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Victory : MonoBehaviour {

    public PublicVariableHolder1stLevel publicVariableHolder1StLevel;

    private Animator victoryText;
    private UnityAction victory;
    private ScreenFader ScreenFader;
    private PauseMenu PauseMenu;


    private void Awake()
    {
        victory = new UnityAction(VictoryEvent);
    }

    private void Start()
    {
        ScreenFader = publicVariableHolder1StLevel.ScreenFader;
        victoryText = GetComponentInChildren<Animator>();
        PauseMenu = publicVariableHolder1StLevel.PauseMenu;
    }

    private void OnEnable()
    {
        EventManager.StartListening("victory", VictoryEvent);
    }

    private void OnDisable()
    {
        EventManager.StopListening("victory", VictoryEvent);
    }

    private void VictoryEvent()
    {
        EventManager.StopListening("victory", VictoryEvent);
        StartCoroutine("DoVictory");
    }

    private IEnumerator DoVictory()
    {
        Debug.Log("here");
        ScreenFader.StartCoroutine("FadeIn");
        yield return new WaitForSeconds(1);
        victoryText.Play("Victory");
        yield return new WaitForSeconds(5);
        victoryText.Play("EmptyText");
        PauseMenu.Pause();
    }
}
