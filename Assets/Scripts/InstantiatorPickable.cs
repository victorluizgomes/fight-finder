using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InstantiatorPickable : MonoBehaviour {

    public GameObject[] items = new GameObject[10];
    public GameObject[] items2;
    public GameObject coffin;

    // Use this for initialization
    void Start () {
		for(int i = 0; i < items.Length; i++)
        {
            float randZ = Random.Range(-22.2f, 22.2f);
            float randX = Random.Range(-22.2f, 22.2f);
            Instantiate(items[i], new Vector3(randX, 0.5f, randZ), Quaternion.identity);
        }

        items2 = GameObject.FindGameObjectsWithTag("Grabbable");
        for (int i = 0; i < items2.Length / 2; i++)
        {
            int index = (int)Random.Range(0, items2.Length - 1);
            items2[index].tag = "Untagged";
        }

        float[] coffinXpos = { 21.48f, -21.74f, -10.43f, 17.17f, -20.68f};
        float[] coffinZpos = { -1.13f, -1.01f, 20.7f, -20.74f, -21.11f };

        int coffin1 = (int)Random.Range(0, 5);
        int coffin2 = (int)Random.Range(0, 5);
        while(coffin2 == coffin1)
        {
            coffin2 = (int)Random.Range(0, 5);
        }

        Instantiate(coffin, new Vector3(coffinXpos[coffin1], 0.02f, coffinZpos[coffin1]), Quaternion.identity);
        Instantiate(coffin, new Vector3(coffinXpos[coffin2], 0.02f, coffinZpos[coffin2]), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
