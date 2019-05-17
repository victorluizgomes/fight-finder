using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    void Update()
    {
        if (ButtonExecute.eventTrigger == true)
            GetComponent<ParticleSystem>().Play();
        else
            GetComponent<ParticleSystem>().Stop();
    }
}
