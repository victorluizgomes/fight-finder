using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{

    public string timeText;

    // Use this for initialization
    void Start()
    {
        timeText = GameObject.FindGameObjectWithTag("Monster").GetComponent<FollowPlayer>().timer.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Monster") != null)
        {
            timeText = "Final Time: " + GameObject.FindGameObjectWithTag("Monster").GetComponent<FollowPlayer>().timer.ToString();
            
        }
        gameObject.GetComponent<Text>().text = timeText;

    }
}