using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameManager Manager;

	// Use this for initialization
	void Awake () {
        if (GameManager.instance == null)
            Instantiate (Manager);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
