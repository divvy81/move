using UnityEngine;
using System.Collections;

public class PickUpCollect : MonoBehaviour {
	public float speed;

	//public GUIText winText;
	public AudioClip coin_collect_audio;
	public bool goingUp = true;
	public float moveSpeed =1.0f;
	public float maxHeight =2.0f;
	public float landHeight = 0.5f;


	//public GameObject g1;
	

	
	void Start()
	{

		//winText.text = "";
	}
	void Update () {
		transform.Rotate (new Vector3 (0, 0, 60) * Time.deltaTime);
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
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			PickUpScript.IncreaseCount();
			//other.gameObject.SetActive (false);
			//collider.attachedRigidbody.SetActice(false);
			AudioSource.PlayClipAtPoint(coin_collect_audio, transform.position);
			Destroy(this.gameObject);
			//gameObject.SetActive(false);
			//Instantiate(g1,new Vector3(transform.position.x,transform.position.y,transform.position.z+4.0f),transform.rotation);

			//gameObject.SetActive (false);
			//Destroy (gameObject);
		}
				
		//Destroy (other.gameObject);
	}

}
