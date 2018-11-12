using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int playerHealth = 3;
    public GameObject playerCamera;

    // UI elements
    public Text promptText;

    // Controls selected spell
    public List<GameObject> spellList = new List<GameObject>();
    private int selectedSpell = 0;

    // Spell gameobjects
    public GameObject FireBolt;
    public GameObject IceLance;
    public GameObject Fireball;
    public GameObject Fireworks;

    // Spell parameters
    public float fireboltSpeed = 20f;
    private Quaternion fireboltRotation;
    private float fireboltNextFire = 0.0f;
    public float fireboltFireRate = 1;

	// Use this for initialization
	void Start () {
        // Adds the four player spells to the spell list
        spellList.Add(FireBolt);
        spellList.Add(Fireball);
        spellList.Add(IceLance);
        spellList.Add(Fireworks);
    }
	
	// Update is called once per frame
	void Update () {

        // Changes the selected spell based on mouse wheel input
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && selectedSpell < spellList.Count - 1) // forward
        {
            selectedSpell++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && selectedSpell > 0) // backwards
        {
            selectedSpell--;
        }
        promptText.text = spellList[selectedSpell].name;


        // If statement for Firebolt spell.
        if (Input.GetMouseButtonDown(0) && Time.time > fireboltNextFire)
        {
            fireboltNextFire = Time.time + fireboltFireRate;
            GameObject projectile = Instantiate(spellList[selectedSpell]) as GameObject;
            projectile.transform.forward = Camera.main.transform.forward;
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 40;
        }

        // Kills the player if they run out of health.
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
}