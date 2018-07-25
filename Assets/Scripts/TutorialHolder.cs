using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHolder : MonoBehaviour {

    public List<string> Tutorials;
	
    public void AddTutorial(string tutorial)
    {
        if(!Tutorials.Contains(tutorial))
        {
            Tutorials.Add(tutorial);
        }
    }

    public void ResetTutorialList()
    {
        Tutorials.Clear();
    }

    void OnDisable()
    {
        Tutorials.Clear();
    }
}
