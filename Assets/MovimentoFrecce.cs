using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoFrecce : MonoBehaviour {

    // Use this for initialization
    public float speed = 2;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
	}
}
