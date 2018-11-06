using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject fireballProjectile;
    public Camera playerCamera;
    public float fbSpeed = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject fireball = Instantiate(fireballProjectile,transform.position,playerCamera.transform.rotation,null) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * fbSpeed;
        }
	}
}
