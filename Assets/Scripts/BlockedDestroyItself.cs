using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedDestroyItself : MonoBehaviour {

	// Use this for initialization
	void Start () {

        DestroyItself();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DestroyItself()
    {
        Destroy(this.gameObject, 1);
    }
}
