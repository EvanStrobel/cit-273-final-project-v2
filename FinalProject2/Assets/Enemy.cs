using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject enemyFireballProjectile;
    public float fbSpeed;
    public float Health;
    public float attackCooldown;
    public Animator enemyAnimator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Health);
        if (Health <= 0)
            Destroy(gameObject);
	}

    IEnumerator OnTriggerStay(Collider Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            Vector3 lookVector = Col.transform.position - transform.position;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
            yield return new WaitForSeconds(attackCooldown);
            enemyAnimator.SetTrigger("Attack");
        }
    }

    void spawnProjectile()
    {
        GameObject fireball = Instantiate(enemyFireballProjectile, transform.position, transform.rotation, null) as GameObject;
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * fbSpeed;
    }

}
