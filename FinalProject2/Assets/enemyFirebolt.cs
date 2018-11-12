using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFirebolt : MonoBehaviour
{
    public GameObject explosionVFX;
    public Player player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Detector")
        {
            Debug.Log(other);
            player = other.GetComponent<Player>();
            player.playerHealth -= 1;
            Destroy(gameObject);
            Instantiate(explosionVFX, transform.position, transform.rotation);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
