using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour {

    Animator anim;
    bool isFading = false;

	void Start () 
    {
        anim = GetComponent<Animator>();
	}

    public IEnumerator FadeOut () //Goes Clear
    {

        isFading = true;
        anim.SetTrigger("Fade Out");
        while (isFading)
            yield return null;
    }

    public IEnumerator FadeIn() //Goes Black
    {
        isFading = true;
        anim.SetTrigger("Fade In");
        while (isFading)
            yield return null;
    }

    void AnimationComplete()
    {
        isFading = false;
    }
}
