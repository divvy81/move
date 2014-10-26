using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour {
	
	public void Start(){

	}

	public IEnumerator OnCollisionEnter(Collision C){
		Debug.Log("its in!");
		if (C.collider.tag == "Fence") {

			yield return new WaitForSeconds(1.2f);
			rigidbody.transform.Translate(-1.0f,0,0);
			rigidbody.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));

		}

	}
}
