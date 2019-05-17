using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour {

    public GameObject Player;
    public GameObject defeatScreen;
    public float time = -1;
    private bool lost = false;

    public bool started = false;
    public AudioSource defeatSound;

    public float timer = 0f;
    public bool stopTimer;

    public bool defeatOnce;

    // Use this for initialization
    void Start () {
        defeatOnce = true;
        stopTimer = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!started)
        {
            transform.position = new Vector3(8, 1.19f, 22);
            return;
        }


        if (lost)
        {
            
            time += Time.deltaTime;
            if (time >= 5 && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {

                SceneManager.LoadScene(0);
            }
            stopTimer = true;
        }
        if (!stopTimer)
        {
            timer += Time.deltaTime;
        }
        /*if (transform.position != Player.transform.position)
        {
            float pX = Player.transform.position.x;
            float pZ = Player.transform.position.z;


            float mX = transform.position.x;
            float mZ = transform.position.z;


            if (pX < mX)
            {
                transform.position = new Vector3(transform.position.x - 0.01f, 
                    transform.position.y, 
                    transform.position.z);

            
            } else if (pX > mX)
            {
                transform.position = new Vector3(transform.position.x + 0.01f,
                    transform.position.y,
                    transform.position.z);
                
            }

            if (pZ < mZ)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y,
                    transform.position.z - 0.01f);

            }
            else if (pZ > mZ)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y,
                    transform.position.z + 0.01f);

            }
        }*/
        


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            defeatSound.Play();
            if (defeatOnce)
            {
                Instantiate(defeatScreen,
                    new Vector3(GameObject.Find("SamplePlayerController").gameObject.transform.position.x,
                    GameObject.Find("SamplePlayerController").gameObject.transform.position.y + 2.5f,
                    GameObject.Find("SamplePlayerController").gameObject.transform.position.z + 4),
                    Quaternion.identity);
                defeatOnce = false;
            }
            lost = true;
           

            GameObject.Find("SamplePlayerController").gameObject.GetComponent<SamplePlayerController2>().Acceleration = 0;
            
        }
    }
}
