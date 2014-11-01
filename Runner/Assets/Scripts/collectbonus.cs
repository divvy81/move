using UnityEngine;
using System.Collections;

public class collectbonus : MonoBehaviour {
	
	//public static string scoreText="Score :0";
	//public  int score =0;
	//public GameObject[] obj;
	public GameObject g1;
	//public GameObject[] go;
	public AudioClip audo;
	public static bool bonus = false;



	void OnTriggerEnter(Collider coll)
	{
		
		if (coll.gameObject.tag == "Player")
		{
			audio.PlayOneShot(audo);
			Instantiate(g1,new Vector3(transform.position.x,transform.position.y,transform.position.z+0.5f),transform.rotation);
			bonus =true;

			if(DelegateMenu.lev == 1){
			playermovement.count += 1;
			playermovement.life = " X " + playermovement.count;
			//Destroy(gameObject);
			}

			else if(DelegateMenu.lev == 2){
				playermovement1.count += 1;
//				playermovement1.life = " X " + playermovement1.count;
				//Destroy(gameObject);
			}

			else if(DelegateMenu.lev == 3){
				playermovement2.count += 1;
				playermovement2.life = " X " + playermovement2.count;
				//Destroy(gameObject);
			}

			else if(DelegateMenu.lev == 4){
				playermovement3.count += 1;
				playermovement3.life = " X " + playermovement3.count;
				//Destroy(gameObject);
			}
		}


		//GUI.Label(new Rect(10,25,90,90),"You have loose one extra life",guiSkin.label);

	}
	
	/*void OnGUI()
	{
				GUI.Box (new Rect (10, 10, 100, 20), scoreText);
	}
	*/
}
