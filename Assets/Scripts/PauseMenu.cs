/**
 * https://www.youtube.com/watch?v=JivuXdrIHK0 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public PublicVariableHolderNeverUnload publicVariableHolderNeverUnload;

    public static bool gameIsPaused = false;
    private GameObject pauseMenuUI;
    private GameObject Player;
    private GameObject MainCamera;
    [SerializeField] private int LastCheckpoint;
    private ScreenFader ScreenFader;
    private TutorialHolder TutorialHolder;

    private void Start()
    {
        ScreenFader = publicVariableHolderNeverUnload.ScreenFader;
        pauseMenuUI = publicVariableHolderNeverUnload.PauseMenuUI;
        Player = publicVariableHolderNeverUnload.Player;
        MainCamera = publicVariableHolderNeverUnload.MainCamera;
    }

    // Update is called once per frame
    void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

	}
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ResetGame()
    {
        StartCoroutine("Reset");
    }


    public void HardReset()
    {
        AnyManager.anyManager.ResetGameHard();
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }

    public void SetLastCheckpoint(int checkpoint)
    {
        LastCheckpoint = checkpoint;
    }

    private IEnumerator Reset()
    {
        this.Resume();
        ScreenFader.gameObject.GetComponent<Animator>().Play("Fade InForVictory");
        SceneManager.UnloadSceneAsync("Level - 1st level");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level - 1st level", LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.5f);
        GameObject spawn = GameObject.Find("Spawn" + LastCheckpoint.ToString());
        TutorialHolder = publicVariableHolderNeverUnload.TutorialHolder;
        foreach(string tuto in TutorialHolder.Tutorials.ToArray())
        {
            Debug.Log("here");
            GameObject.Find(tuto).GetComponent<Tutorial>().DestroyTutorial();
        }

        spawn.SetActive(true);
        Player.transform.position = spawn.transform.position;
        Player.GetComponent<UIControler>().TokenCount = 0;
        Player.transform.position = spawn.transform.position;
        MainCamera.transform.position = spawn.transform.position;
        yield return new WaitForSeconds(2f);
        Debug.Log("here");
        ScreenFader.GetComponent<ScreenFader>().StartCoroutine("FadeOut");
        yield return new WaitForSeconds(1f);

    }
}
