using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject enemySpellToCast;
    public GameObject player;
    public Transform throwLocation;
    public float spellSpeed;
    public float Health;
    public float attackCooldown;
    public Animator enemyAnimator;
    public bool detectingPlayer = false;
    public float detectDistance = 10f;
    private float distanceToPlayer;
    private bool isDead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Health);
        if (Health <= 0)
            Destroy(gameObject);
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer <= detectDistance && isDead == false)
            StartCoroutine("attackPlayer");
        else if (distanceToPlayer > detectDistance || isDead == true)
            StopCoroutine("attackPlayer");
    }

    IEnumerator attackPlayer()
    {
        Vector3 lookVector = player.transform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        yield return new WaitForSeconds(attackCooldown);
        enemyAnimator.SetTrigger("Attack");
    }

    void spawnProjectile()
    {
        GameObject fireball = Instantiate(enemySpellToCast, throwLocation.transform.position, transform.rotation, null) as GameObject;
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * spellSpeed;
    }

    IEnumerator OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "playerProjectile")
        {
            enemyAnimator.SetTrigger("Killed");
            isDead = true;
            yield return new WaitForSeconds(4);
            Destroy(gameObject);
        }
    }

}
