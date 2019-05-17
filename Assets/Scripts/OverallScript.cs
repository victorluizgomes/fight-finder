using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverallScript : MonoBehaviour {

    public int score = 0;
    public GameObject fireParticle;
    public GameObject winScreen;
    public float time = -1;


    public AudioSource winAudio;

    public bool startOnce;

    // Use this for initialization
    void Start () {
        
        startOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
        

        if (score >= 5) // needs 5 items to win the game
        {

            if (startOnce)
            {
                winAudio.Play();
                Instantiate(fireParticle, gameObject.transform.position, Quaternion.identity);

                Instantiate(winScreen,
                    new Vector3(GameObject.Find("SamplePlayerController").gameObject.transform.position.x,
                    GameObject.Find("SamplePlayerController").gameObject.transform.position.y + 2.5f,
                    GameObject.Find("SamplePlayerController").gameObject.transform.position.z + 4),
                    Quaternion.identity);
                GameObject.FindGameObjectWithTag("Monster").GetComponent<FollowPlayer>().stopTimer = true;
                startOnce = false;
            }

            gameObject.transform.position = new Vector3(-100, -100, -100);

            time += Time.deltaTime;
            GameObject.Find("SamplePlayerController").gameObject.GetComponent<SamplePlayerController2>().Acceleration = 0;
            if(time >= 5 && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {

                SceneManager.LoadScene(0);
            }
        }
    }
}
