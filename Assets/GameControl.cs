using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public GameObject Player;
    public GameObject BodyPartPool;
    public GameObject BodyPartPoolActive;
    public GameObject StitchAnimation;

    public float horizontalSpeed = 0.05f;
    public float rotationalSpeed = 1f;
    public float timeBetweenFalls = 3;

    public int numBodyPartsToDrop = 20;

    private float lastFallTime = 0;
    private int totalNumBodyParts;
    private int numBodyPartsToExclude;
    
	// Use this for initialization
	void Start () {
        lastFallTime = Time.time;
        totalNumBodyParts = BodyPartPool.transform.childCount;
        numBodyPartsToExclude = totalNumBodyParts - numBodyPartsToDrop;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastFallTime + timeBetweenFalls)
        {
            if (BodyPartPool.transform.childCount > 0)
            {
                Transform nextBodyPart = BodyPartPool.transform.GetChild(0);
                Vector3 bodyPartPosition = new Vector3(Random.Range(-5, 5), 5);
                nextBodyPart.position = bodyPartPosition;
                nextBodyPart.GetComponent<Rigidbody2D>().simulated = true;
                nextBodyPart.parent = BodyPartPoolActive.transform;
                lastFallTime = Time.time;
            }
        }

        if (Input.GetAxis("Attach") > 0)
        {
            foreach (Transform activeBodyPart in BodyPartPoolActive.transform)
            {
                CollisionHandler collisionHandler = activeBodyPart.GetComponent<CollisionHandler>();
                if (collisionHandler.colliding)
                {
                    activeBodyPart.parent = Player.transform;
                    Vector2 contactPoint = collisionHandler.collision.contacts[0].point;

                    Instantiate(StitchAnimation, new Vector3(contactPoint.x, contactPoint.y), Quaternion.identity, Player.transform);
                    Destroy(activeBodyPart.GetComponent<Rigidbody2D>());
                }
            }
        }
            
	}

    void FixedUpdate()
    {
        Vector3 playerPosition = Player.transform.position;
        playerPosition.x += horizontalSpeed * Input.GetAxis("Horizontal");
        Player.transform.position = playerPosition;

        Player.transform.Rotate(0, 0, -rotationalSpeed * Input.GetAxis("Rotate"));

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
