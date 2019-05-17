using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMove : MonoBehaviour
{
    private bool isGrabbing = false;
    private Transform grabbedTransform;
    public float zSpeed = 4.0f;
    private Transform hitTransform;

    void Update()
    {
        OVRInput.Controller activeController = OVRInput.GetActiveController();
        transform.localPosition = OVRInput.GetLocalControllerPosition(activeController);
        transform.localRotation = OVRInput.GetLocalControllerRotation(activeController);

        RaycastHit hitInfo2;
        if (Physics.Raycast(new Ray(transform.position, transform.forward), out hitInfo2))
        {
            if (hitInfo2.transform.tag == "Grabbable" && !isGrabbing)
            {
                if (hitTransform != null)
                    SetHighlight(hitTransform, false);

                hitTransform = hitInfo2.transform;
                SetHighlight(hitTransform, true);
            }
            else
            {
                if (hitTransform != null && !isGrabbing)
                    SetHighlight(hitTransform, false);
            }
        }
        else
        {
            if (hitTransform != null && !isGrabbing)
            {
                SetHighlight(hitTransform, false);
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(new Ray(transform.position, transform.forward), out hitInfo))
            {
                if (hitInfo.transform.tag == "Grabbable")
                {
                    isGrabbing = true;
                    grabbedTransform = hitInfo.transform;
                    grabbedTransform.GetComponent<Rigidbody>().isKinematic = true;
                    grabbedTransform.GetComponent<Rigidbody>().useGravity = false;
                    grabbedTransform.parent = transform;
                }
            }
        }

        if (isGrabbing && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (grabbedTransform != null)
            {
                grabbedTransform.GetComponent<Rigidbody>().isKinematic = false;
                grabbedTransform.GetComponent<Rigidbody>().useGravity = true;
                grabbedTransform.parent = null;
            }
            isGrabbing = false;
        }

        /*if (isGrabbing && !OVRInput.Get(OVRInput.Button.One))
        {
            float distance = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).y;

            grabbedTransform.position += distance * zSpeed * Time.deltaTime * transform.forward;
            grabbedTransform.localPosition = new Vector3(grabbedTransform.localPosition.x, grabbedTransform.localPosition.y, Mathf.Clamp(grabbedTransform.localPosition.z, 1.0f, 7.0f));
        }*/

    }
    void SetHighlight(Transform t, bool highlight)
    {
        if (highlight)
        {
            //hitTransform.GetComponent<Renderer>().material.color = Color.cyan;
            hitTransform.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
            transform.GetComponent<LineRenderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        else
        {
            t.GetComponent<Renderer>().material.color = t.GetComponent<IsHit_S>().originalColorVar;
            t.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
            transform.GetComponent<LineRenderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.6f);
        }
    }
}
