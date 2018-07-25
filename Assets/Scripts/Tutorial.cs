using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    
    public GameObject TutorialText;
    public GameObject BackgoundImage;
    public GameObject Button;
    public GameObject ClickOnText;
    public GameObject TutorialBox;

    public bool delayTutorial;
    public float tutorialDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (delayTutorial)
        {
            StartCoroutine("StartTutorial");
        }
        else
        {
            GameObject.Find("TutorialHolder").GetComponent<TutorialHolder>().AddTutorial(this.gameObject.name);
            TutorialText.SetActive(true);
            BackgoundImage.SetActive(true);
            Button.SetActive(true);
            ClickOnText.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeFromTutorial()
    {
        Destroy(TutorialText);
        Destroy(BackgoundImage);
        Destroy(Button);
        Destroy(ClickOnText);
        Destroy(TutorialBox);
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }

    private IEnumerator StartTutorial()
    {
        GameObject.Find("TutorialHolder").GetComponent<TutorialHolder>().AddTutorial(this.gameObject.name);
        yield return new WaitForSeconds(tutorialDelay);
        TutorialText.SetActive(true);
        BackgoundImage.SetActive(true);
        Button.SetActive(true);
        ClickOnText.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DestroyTutorial()
    {
        Destroy(TutorialText);
        Destroy(BackgoundImage);
        Destroy(Button);
        Destroy(ClickOnText);
        Destroy(TutorialBox);
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }
}
