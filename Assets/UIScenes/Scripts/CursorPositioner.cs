using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Accessing Unity's UI Namespace to use UI functionality

public class CursorPositioner : MonoBehaviour
{
    private float defaultPosZ;

    void Start()
    {
        //We are storing the ReticleCursor's Rect Transform Z Position
        //(where we placed the Canvas in Z-axis)
        defaultPosZ = transform.localPosition.z;
    }

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            //If the default distance of the canvas from the camera in Z is less
            // than the hit position's Z (if the object is farther away)
            if (hit.distance <= defaultPosZ)
            {

                //Update the reticle's position Z as hit position's Z
                //Move the reticle farther
                transform.localPosition = new Vector3(0, 0, hit.distance - 0.05f);

                transform.GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 0f, 0f, 0.5f);
            }

            //If the hitpoint distance is nearer to the user's FOV than the
            //default set position z, then do nothing
            else
            {
                transform.localPosition = new Vector3(0, 0, defaultPosZ);
                transform.GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 0f, 0f, 1.0f);
            }
        }
    }

    void OnDisable()
    {
        //We revert the reticle cursor's color's alpha to full when this script is deactivated
        transform.GetChild(0).GetComponent<RawImage>().color = new Color(1.0f, 0f, 0f, 1.0f);
    }
}
