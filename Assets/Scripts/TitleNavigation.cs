using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleNavigation : MonoBehaviour {

    public void Beginning()
    {
        SceneManager.LoadSceneAsync("NeverUnload");
        SceneManager.LoadScene("Level - 1st level", LoadSceneMode.Additive);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Controls()
    {
        
    }
}
