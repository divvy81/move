using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;

public class coindelete :MonoBehaviour {
	string setscore=	"http://localhost/datascore.php";
	string highscoreUrl="http://localhost/display1.php";
	string score1 ;
	string lefturn1;
	string rightturn1;
	string distance1;
	string time1;
	string timeplayed;

	public bool collided =false;
	
	public static string[] Line=new string[35];
	int i;
	//private int reset1=0;
	string problem  = "";


				


	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		System.DateTime myTime = System.DateTime.Now;
		time1 = myTime.ToString();
//		Debug.Log (time1);


		if (DelegateMenu.lev == 1) {
			 lefturn1 = playermovement.leftturn.ToString ();
			 rightturn1 = playermovement.rightturn.ToString ();
			 distance1 = playermovement.caldis.ToString ();
			timeplayed = playermovement.t;
		} else if (DelegateMenu.lev == 2) {
			 lefturn1 = playermovement1.leftturn.ToString ();
			 rightturn1 = playermovement1.rightturn.ToString ();
			 distance1 = playermovement1.caldis.ToString ();
		} else if (DelegateMenu.lev == 3) {
			 lefturn1 = playermovement2.leftturn.ToString ();
			 rightturn1 = playermovement2.rightturn.ToString ();
			 distance1 = playermovement2.caldis.ToString ();
		} else if (DelegateMenu.lev == 4) {
			 lefturn1 = playermovement3.leftturn.ToString ();
			 rightturn1 = playermovement3.rightturn.ToString ();
			 distance1 = playermovement3.caldis.ToString ();
			timeplayed = playermovement3.t;
		}

		if (GameObject.FindGameObjectWithTag("Player").transform.position.z > transform.position.z) {
			GameObjectController.no_of_objects-=1;
			Destroy (gameObject);
		}
		if( DelegateMenu.lev == 1){
		score1 = playermovement.score.ToString();
		}

		else if( DelegateMenu.lev == 2){
			score1 = playermovement1.score.ToString();
		}

		else if( DelegateMenu.lev == 3){
			score1 = playermovement2.score.ToString();
		}

		else if( DelegateMenu.lev == 4){
			score1 = playermovement3.score.ToString();
		}
		//count1 = playermovement.count.ToString ();
	
	}
	void storescore(string userNamez, string score,string leftturn,string rightturn,string distance1,string time1,string timeplayed)
	{
		Debug.Log(leftturn);
		Debug.Log(rightturn);
		Debug.Log ("distance covered " + distance1);
		string setScore = setscore + "?username=" + userNamez + "&score=" + score +"&leftturn=" + leftturn +"&rightturn=" + rightturn +"&distance=" + distance1 +"&date=" + time1+ "&timeplayed=" + timeplayed;

				HttpWebRequest connection =
			(HttpWebRequest)HttpWebRequest.Create(setScore);
		
		connection.Method = "GET";
		HttpWebResponse response =
			(HttpWebResponse)connection.GetResponse();
		
		StreamReader sr =new StreamReader(response.GetResponseStream(),Encoding.UTF8);
	}
	void OnCollisionEnter(Collision coll)
	{

				if (coll.collider.tag == "Player") {

						if (DelegateMenu.lev == 1){
						playermovement.count--;
						playermovement.life = " X " + playermovement.count;
						//PlayerHealth.currentHealth -=10;
						//playermovement.life = "Lives :" + playermovement.count;
						if (playermovement.count == 0) {
								Debug.Log (score1);

								storescore (hscontroller.userName, score1, lefturn1, rightturn1,distance1,time1,timeplayed);
								getScores ();
							//	reset1=reset1 +1 ;
							//	Debug.Log ("Value of reset is :" + reset1);
								
								Application.LoadLevel ("gameover");

						}
					}

			else if (DelegateMenu.lev == 2){
				playermovement1.count--;
				playermovement1.life = " X " + playermovement1.count;
				//PlayerHealth.currentHealth-=10;
				//PlayerHealth.currentHealth -=10;
				//playermovement.life = "Lives :" + playermovement.count;
				if (playermovement1.count == 0) {
					Debug.Log (score1);
					
					storescore (hscontroller.userName, score1, lefturn1, rightturn1,distance1,time1,timeplayed);
					getScores ();
					//	reset1=reset1 +1 ;
					//	Debug.Log ("Value of reset is :" + reset1);
					
					Application.LoadLevel ("gameover");
					
				}
			}

			else if (DelegateMenu.lev == 3){
				playermovement2.count--;
				playermovement2.life = " X " + playermovement2.count;
				//playermovement.life = "Lives :" + playermovement.count;
				if (playermovement2.count == 0) {
					Debug.Log (score1);
					
					storescore (hscontroller.userName, score1, lefturn1, rightturn1,distance1,time1,timeplayed);
					getScores ();
					//	reset1=reset1 +1 ;
					//	Debug.Log ("Value of reset is :" + reset1);
					
					Application.LoadLevel ("gameover");
					
				}
			}

			else if (DelegateMenu.lev == 4){
				playermovement3.count--;
				playermovement3.life = " X " + playermovement3.count;
				//playermovement.life = "Lives :" + playermovement.count;
				if (playermovement3.count == 0) {
					Debug.Log (score1);
					
					storescore (hscontroller.userName, score1, lefturn1, rightturn1,distance1,time1,timeplayed);
					getScores ();
					//	reset1=reset1 +1 ;
					//	Debug.Log ("Value of reset is :" + reset1);
					
					Application.LoadLevel ("gameover");
					
				}
			}
				}
		}
	 	
	    void getScores() 
	{
		//gameObject.guiText.text = "Loading Scores";
			
			HttpWebRequest connection =
				(HttpWebRequest)HttpWebRequest.Create(highscoreUrl);
			
			connection.Method = "GET";
			HttpWebResponse response =
				(HttpWebResponse)connection.GetResponse();
			//for(i=0;i<5;i++)
			
			StreamReader sr =new StreamReader(response.GetResponseStream(),Encoding.UTF8);
			{
				for(i=0;i<34;i++)
			    {
					Line[i]=sr.ReadLine();
				Debug.Log ("the value is "+Line[6]);
				}
			}
			

		
		
	}
}
