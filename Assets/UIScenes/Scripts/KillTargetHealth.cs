using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillTargetHealth : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public GameObject spawnEffect;
    private float timeToSelect = 3.0f;
    private float countDown;
    private int score;
    public Text scoreText;
    public Image healthBar; //An Image variable (we'll drag and drop the
                            //Image under the HealthBar game object)

    void Start()
    {
        score = 0;
        countDown = timeToSelect;
        hitEffect.enableEmission = false;
        scoreText.text = "Score: 0";
        SetRandomPosition();
    }

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            if (countDown > 0.0f)
            {
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                hitEffect.enableEmission = true;
                healthBar.fillAmount = countDown / timeToSelect; //We are altering the fillAmount of the healthBar image based on the time it has passed looking at Ethan
            }
            else
            {
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                scoreText.text = "Score: " + score;
                countDown = timeToSelect;
                SetRandomPosition();
            }
        }

        else
        {
            countDown = timeToSelect;
            hitEffect.enableEmission = false;
            healthBar.fillAmount = 1.0f; //We are setting the fillAmount as full
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
        Instantiate(spawnEffect, new Vector3(target.transform.position.x, 3.0f,
                                             target.transform.position.z), Quaternion.identity);

        //We want the healthBar to face towards the user at all times.
        //We are calculating the vector from the main camera to the target position
        Vector3 lookVector = target.transform.position - Camera.main.transform.position;

        //We are setting y as 0, since the camera is at a height whereas the target is on the ground
        //We are compensating for the two points' height difference by setting y as 0.0f
        lookVector.y = 0.0f;

        //We are rotating the parent of the healthBar Image (the Canvas) by the vector we've calculated
        healthBar.rectTransform.parent.rotation = Quaternion.LookRotation(lookVector, Vector3.up);
    }
}

