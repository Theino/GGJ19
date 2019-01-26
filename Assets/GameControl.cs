using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public GameObject Player;

    public float horizontalSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
	}

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 playerPosition = Player.transform.position;
        playerPosition.x += horizontalSpeed * horizontalInput;
        Player.transform.position = playerPosition;
        Debug.Log(horizontalInput);
    }
}
