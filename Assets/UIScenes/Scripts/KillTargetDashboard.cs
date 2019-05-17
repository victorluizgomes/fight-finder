using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTargetDashboard : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public GameObject spawnEffect;
    private float timeToSelect = 3.0f;
    private float countDown;
    private int score;

    void Start()
    {
        score = 0;
        countDown = timeToSelect;
        hitEffect.enableEmission = false;
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
            }

            else
            {
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                countDown = timeToSelect;
                SetRandomPosition();
            }
        }

        else
        {
            countDown = timeToSelect;
            hitEffect.enableEmission = false;
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
        Instantiate(spawnEffect, new Vector3(target.transform.position.x, 3.0f, target.transform.position.z), Quaternion.identity);
    }

}