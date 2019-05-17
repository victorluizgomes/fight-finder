using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBubble : MonoBehaviour
{
    public GameObject ground;

    public Transform infoBubble; //We'll drag & drop the WalkTarget > InfoBubble game object

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitObject;

        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        if (Physics.Raycast(ray, out hit))
        {
            hitObject = hit.collider.gameObject;

            if (hitObject == ground)
            {
                //We set the string value of infoText.text so that the
                //coordinates are shown on the bubble canvas
                infoBubble.GetComponentInChildren<Text>().text = "X:" + hit.point.x.ToString("F2")
                                                                 + ", Z: " + hit.point.z.ToString("F2");

                //We transform the infoBubble canvas by passing it the camera position,
                //so that it always faces the user (Transform.LookAt rotates the transform
                //such that the forward vector points at the input)
                infoBubble.LookAt(camera.position);

                //The result of the LookAt() has the canvas facing away from the user.
                //So, we rotate it around the y - axis by 180 degrees
                infoBubble.Rotate(0.0f, 180.0f, 0.0f);
                transform.position = hit.point;
            }
        }
    }
}

