using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Player player;
    public GameObject go_player;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;

    // Use this for initialization
    void Start () {
        player = go_player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.playerHealth == 2)
            health3.SetActive(false);
        if (player.playerHealth == 1)
            health2.SetActive(false);
        if (player.playerHealth == 0)
            health1.SetActive(false);
	}
}
