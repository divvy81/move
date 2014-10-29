using UnityEngine;
using System.Collections;

public class PickUpCollectionDestroyer : MonoBehaviour {
	private float max_z_spread;// how much player should run after this object starts to get deleted
	// Use this for initialization
	void Start () {
		max_z_spread = 24.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (GameObject.FindGameObjectWithTag ("Player").transform.position.z);
		if (GameObject.FindGameObjectWithTag("Player").transform.position.z > transform.position.z + max_z_spread) {
			GameObjectController.no_of_objects-=1;
			Destroy (gameObject);
			
		}
	}
}
