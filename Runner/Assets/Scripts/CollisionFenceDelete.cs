using UnityEngine;
using System.Collections;

public class CollisionFenceDelete : MonoBehaviour {
	private float max_z_spread;// how much player should run after this object starts to get deleted
	Animator anim;
//	int runHash = Animator.StringToHash("Run");
	// Use this for initialization
	
	void Start () {
		max_z_spread = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position.z+ "Player");
		Debug.Log(transform.position.z+ "fence");
		if (GameObject.FindGameObjectWithTag("Player").transform.position.z > transform.position.z + max_z_spread) {
			//Debug.Log("here");
			PlayerHealth.collided = false;
			Destroy (gameObject);

			
		}
	}
}
