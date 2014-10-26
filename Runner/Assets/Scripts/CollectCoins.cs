using UnityEngine;
using System.Collections;

public class CollectCoins : MonoBehaviour {

	//public static string scoreText="Score :0";
	//public  int score =0;
	//public GameObject[] obj;
	public AudioClip audo;
	public GameObject g1;

	void OnTriggerEnter(Collider coll)
	{

				if (coll.gameObject.tag == "Player")
				{
						audio.PlayOneShot(audo);
			Instantiate(g1,new Vector3(transform.position.x,transform.position.y,transform.position.z+4.0f),transform.rotation);
			if(DelegateMenu.lev == 1){
			playermovement.score += 2;
					/*	if(playermovement.score == 0)
						{
						Debug.Log ("the value is reset ");
						playermovement.scoreText = "Score :" + 0;
						}
						
						else
					*/
						Debug.Log(playermovement.score);
						playermovement.scoreText = " X " + playermovement.score;
						//Destroy(gameObject);
			}	

			else if(DelegateMenu.lev == 2){
				playermovement1.score += 2;
				/*	if(playermovement.score == 0)
						{
						Debug.Log ("the value is reset ");
						playermovement.scoreText = "Score :" + 0;
						}
						
						else
					*/
				Debug.Log(playermovement1.score);
				playermovement1.scoreText = " X " + playermovement1.score;
				//Destroy(gameObject);
			}

			else if(DelegateMenu.lev == 3){
				playermovement2.score += 2;
				/*	if(playermovement.score == 0)
						{
						Debug.Log ("the value is reset ");
						playermovement.scoreText = "Score :" + 0;
						}
						
						else
					*/
				Debug.Log(playermovement.score);
				playermovement2.scoreText = " X " + playermovement2.score;
				//Destroy(gameObject);
			}

			else if(DelegateMenu.lev == 4){
				playermovement3.score += 2;
				/*	if(playermovement.score == 0)
						{
						Debug.Log ("the value is reset ");
						playermovement.scoreText = "Score :" + 0;
						}
						
						else
					*/
				Debug.Log(playermovement3.score);
				playermovement3.scoreText = " X " + playermovement3.score;
				//Destroy(gameObject);
			}
				}
	}

	/*void OnGUI()
	{
				GUI.Box (new Rect (10, 10, 100, 20), scoreText);
	}
	*/
}
