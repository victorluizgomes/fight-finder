using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonExecute : MonoBehaviour
{
    public GameObject playButton;
    public GameObject stopButton;
    private GameObject currentButton;   //A variable that holds the currently highlighted button
    public ParticleSystem fireParticle; //A variable that holds the fire mobile particle system
    public static bool eventTrigger;    //A variable that controls the Play/Stop of the fire particle system

    void Start()
    {
        eventTrigger = false;
    }

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitButton = null;

        if (Physics.Raycast(ray, out hit))
        {
            //Raycast looks for a hit with the tag "Button" through the sphere collider we placed
            if (hit.transform.gameObject.tag == "Button")
            {
                //If there's a hit, we store the collider's parent (Play/Stop Image) as the hitButton
                hitButton = hit.transform.parent.gameObject;
            }
        }

        //We take care of the highlighting when the user is looking at the Play/Stop Images
        if (currentButton != hitButton)
        {
            if (currentButton != null)
            { //Don't highlight the button, not looking at it
                if (currentButton == playButton)
                    transform.GetChild(0).GetComponent<Image>().color = Color.white;
                if (currentButton == stopButton)
                    transform.GetChild(1).GetComponent<Image>().color = Color.white;
            }

            currentButton = hitButton; //We want to remember the currentButton that's highlighted
                                       //between the Update() calls. We will be able to detect whether
                                       //the new hit is with the same or a different button (or null).

            if (currentButton != null)
            { //Highlight the button, looking at it
                if (currentButton == playButton)
                    transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                if (currentButton == stopButton)
                    transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
            }
        }

        //If there is one highlighted button and any key is pressed, we'll take that as a select
        //and call the play or stop operations on the particle system and the audio source
        if (currentButton != null)
        {
            if (Input.anyKeyDown)
            {
                if (currentButton == playButton)
                {
                    fireParticle.Play();
                    fireParticle.GetComponent<AudioSource>().Play();
                }
                else if (currentButton == stopButton)
                {
                    fireParticle.Stop();
                    fireParticle.GetComponent<AudioSource>().Stop();
                }
            }
        }
    }
}
