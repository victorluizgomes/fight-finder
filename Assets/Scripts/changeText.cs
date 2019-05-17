using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeText : MonoBehaviour {

    public string scoreText;

	// Use this for initialization
	void Start () {
        scoreText = "score: " + GameObject.FindGameObjectWithTag("Monster").GetComponent<OverallScript>().score.ToString();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Monster") != null)
        {
            scoreText = "score: " + GameObject.FindGameObjectWithTag("Monster").gameObject.GetComponent<OverallScript>().score.ToString();
        }
        gameObject.GetComponent<Text>().text = scoreText;
    }
}
