using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject _Spawn;
    public float _Time = 1.0f;
    public int SpawnNumber;

    GameObject m_player;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_player = collision.gameObject;
        }
    }

    private void FixedUpdate()
    {
        if (m_player != null)
        {
            StartCoroutine("SetActive");
        }
	}

    private IEnumerator SetActive()
    {
        m_player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        m_player.transform.position = _Spawn.transform.position;
        GameObject.FindWithTag("MainCamera").transform.position = _Spawn.transform.position;
        GameObject.Find("PauseMenu").GetComponent<PauseMenu>().SetLastCheckpoint(SpawnNumber);
        yield return new WaitForSeconds(_Time);
        _Spawn.SetActive(false);
    }
}
