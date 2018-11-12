using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icelance : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Detector")
        {
            Debug.Log(other);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
