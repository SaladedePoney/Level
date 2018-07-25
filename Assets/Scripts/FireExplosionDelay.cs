using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosionDelay : MonoBehaviour {

    public float _Speed;
    public float _Radius = 110;
    public float _Delay;
    public int damage;
    public int pushIntensity;
    SphereCollider _Collider;
    float timer = 0;
    public float invincibility;
    bool iscollider;

	// Use this for initialization
	void Start () {
        _Collider = GetComponent<SphereCollider>();
        invincibility = 3f;
	}
	
	void Update () {
        if (timer >= _Delay)
        {
            if (!_Collider.enabled && !iscollider)
            {
                _Collider.enabled = true;
                iscollider = true;
            }

            _Collider.radius = Mathf.Lerp(_Collider.radius, _Radius, _Speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        invincibility += Time.deltaTime;
        if (_Collider.radius >= _Radius - 1)
        {
           _Collider.enabled = false;
           Destroy(gameObject, 1.5f);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Enemy") && invincibility >= 2f)
        {
                    DamageData dmgData = new DamageData();
                    dmgData.damage = damage;

                    MessageHandler msgHandler = other.gameObject.GetComponent<MessageHandler>();

                    if (msgHandler)
                    {
                      msgHandler.GiveMessage(MessageTypes.DAMAGED, other.gameObject, dmgData);
                    }
            Vector3 normale = other.gameObject.transform.position - GameObject.FindWithTag("Player").transform.position;
            Debug.Log(normale.normalized);
            Vector3 force = new Vector3(normale.normalized.x * pushIntensity, 0 , normale.normalized.z * pushIntensity);
            other.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            invincibility = 0;

        }
    }
}
