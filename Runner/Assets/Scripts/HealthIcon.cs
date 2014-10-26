using UnityEngine;
using System.Collections;

public class HealthIcon : MonoBehaviour {
	public bool goingUp = true;
	public float moveSpeed =1.0f;
	public float maxHeight =3.0f;
	public float landHeight = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.renderer.material.color = Color.green;
		transform.Rotate (new Vector3 (0, 60, 0) * Time.deltaTime);
		if(goingUp)
		{
			if(transform.position.y < maxHeight-1) // haven't reached apex yet
				transform.Translate(Vector3.up * Time.deltaTime * moveSpeed,Space.World); // so move upward
			else
				goingUp = false;// reached top of flip
		}
		
		if(!goingUp) // go back down
		{
			if(transform.position.y > landHeight) // haven't reached ground yet
				transform.Translate(-Vector3.up * Time.deltaTime * moveSpeed,Space.World); // so move down
			else
				goingUp = true;  // finish flip
			// so we can differentiate from before the flip started
		}
	
	}
}
