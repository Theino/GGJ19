using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneController : MonoBehaviour {

    public GameObject BoundingBox;

    private GameObject Player;

    Bounds GetMaxBounds(GameObject g)
    {
        var b = new Bounds(g.transform.position, Vector3.zero);
        foreach (Renderer r in g.GetComponentsInChildren<Renderer>())
        {
            b.Encapsulate(r.bounds);
        }
        return b;
    }

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        Player.transform.position = new Vector3(0, -1, 0);
        Player.transform.rotation = Quaternion.identity;
        Bounds playerBounds = GetMaxBounds(Player);
        Bounds boundingBox = GetMaxBounds(BoundingBox);
        Vector3 offsetPlayer = boundingBox.center - playerBounds.center;
        Player.transform.position += offsetPlayer;
        float xScale = boundingBox.extents.x / playerBounds.extents.x;
        float yScale = boundingBox.extents.y / playerBounds.extents.y;
        float scale = xScale < yScale ? xScale : yScale;
        Player.transform.localScale *= scale;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
