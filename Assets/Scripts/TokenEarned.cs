using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenEarned : MonoBehaviour {

    public GameObject Token;
    public AudioClip TokenSound;
    public ParticleSystem _Flare;

    Animator m_anim;
    AudioSource m_audio;

    Collider player;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        m_audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            player = other;
            _Flare.Play(); 
			m_anim.Play("Token - Earned");

		}
    }

    void AnimationComplete()
    {
        Destroy(Token);  
    }

    void GUIUpdate()
    {
        player.transform.GetComponent<UIControler>().UpdateToken();
    }

    void PlaySound()
    {
        m_audio.PlayOneShot(TokenSound);
    }
}
