using UnityEngine;
using System.Collections;

public class TrackDestroyer : MonoBehaviour {

	private float max_z_spread;// how much track runs
	// Use this for initialization
	void Start () {
		max_z_spread = 128.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GameObject.FindGameObjectWithTag("Player").transform.position.z > transform.position.z + max_z_spread) {
			GameObjectController.no_of_tracks-=1;
			Destroy (gameObject);
			
		}
	}
}