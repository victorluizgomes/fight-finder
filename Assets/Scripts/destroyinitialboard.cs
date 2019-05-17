using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyinitialboard : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey)
        {
            Destroy(gameObject, 1f);
            GameObject.FindGameObjectWithTag("Monster").gameObject.GetComponent<FollowPlayer>().started = true;
            GameObject.FindGameObjectWithTag("Monster").gameObject.GetComponent<OverallScript>().time = 0;
        }
	}
}
