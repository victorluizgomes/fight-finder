using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoffinTrigger : MonoBehaviour {

    public GameObject fireParticle;
    public AudioSource sound;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grabbable")
        {
            // Have a sound and increase a score variable or decrease score variable 
            // based if the item is good or bad
            sound.Play();
            Instantiate(fireParticle, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject, 0.1f);
            GameObject.FindGameObjectWithTag("Monster").gameObject.GetComponent<OverallScript>().score += 1;
            GameObject.FindGameObjectWithTag("Monster").gameObject.GetComponent<NavMeshAgent>().speed += 0.75f;
        }
    }
}
