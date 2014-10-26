using UnityEngine;
using System.Collections;

public class CollisionFenceDelete : MonoBehaviour {
	private float max_z_spread;// how much player should run after this object starts to get deleted
	Animator anim;
	int idleHash = Animator.StringToHash("Idle");
	int runHash = Animator.StringToHash("Run");
	int movingBackHash = Animator.StringToHash("Moving_back");
	int movingFrontHash = Animator.StringToHash("Moving_front");
	// Use this for initialization
	
	void Start () {
		max_z_spread = 1.0f;
		anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position.z+ "Player");
		Debug.Log(transform.position.z+ "fence");
		if (GameObject.FindGameObjectWithTag("Player").transform.position.z > transform.position.z + max_z_spread) {
			Debug.Log("here");
			anim.SetBool (runHash,true);
			anim.SetBool (idleHash,false);
			anim.SetBool (movingFrontHash,false);
			//anim.SetBool (idleHash,false);
			//playermovement1.speed = 10.0f;
			Destroy (gameObject);
			
		}
	}
}
