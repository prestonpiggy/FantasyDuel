using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhandler : MonoBehaviour {
    GameObject enemy;
	// Use this for initialization
	void Start () {
        
        enemy = Instantiate(MenuScript.currentenemy.Idle, new Vector3(0, 0, 0), Quaternion.identity);
        enemy.transform.parent = gameObject.transform;
        enemy.transform.position = gameObject.transform.position;
        enemy.GetComponent<Transform>().localScale =Vector3.one;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
