using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;

public class hscontroller : MonoBehaviour {
	
	
	
	string login_url = "http://localhost/login.php";
	string register_url= "http://localhost/register.php";
	string setscore=	"http://localhost/datascore.php";
public static	string userName = "";
	string passWord = "";
	string problem  = "";
	string score1;
	string[] line= new string[1];
	//string Score="";
	public GUISkin theSkin;


	void OnGUI ()
	{
		GUI.skin = theSkin;
		GUI.Window ( 0 ,new Rect( Screen.width / 4 , Screen.height / 4, Screen.width / 3 , Screen.height / 2 - 70),LoginWindow, "login");
	}
	
	
	void LoginWindow(int windowId)
	{
		GUI.Label (new Rect(140 , 40,130,100),"Username");
		userName = GUI.TextField (new Rect(25,60,375,30),userName);
		GUI.Label (new Rect(140,92,130,100),"Password");
		passWord = GUI.TextField (new Rect (25,115,375,30),passWord);
		
		//	GUI.Label (new Rect(140,120,130,100),"~~~~password~~~~");
		//	score= GUI.TextField (new Rect (25,115,375,30),score);
		
		if(GUI.Button (new Rect(25,160,175,50),"Login")){
			HandleLogin(userName,passWord);

		}
	/*	if(Application.Quit())
		{
			score1=playermovement.score;
			StartCoroutine(storescore (userName,score1));
		}
		*/
		if(GUI.Button (new Rect(225,160,175,50),"Register"))
			StartCoroutine(HandleRegister (userName,passWord));

		
		
		GUI.Label (new Rect(70,250,400,200),problem);
		
	}



	void HandleLogin(string userNamez, string passWordz)
	{
		problem = "Checking .";
		/*string login_URL = login_url + "?username=" + userNamez + "&password=" + passWordz;
		HttpWebRequest connection =	





			(HttpWebRequest)HttpWebRequest.Create(login_URL);




		connection.Method = "GET";
		HttpWebResponse response =
			(HttpWebResponse)connection.GetResponse();
		
		StreamReader sr =new StreamReader(response.GetResponseStream(),Encoding.UTF8);
		{
			line[0]=sr.ReadLine();
		}
	if(line[0]=="1")
		{
			Debug.Log(line[0]);
        Application.LoadLevel("start");
		}
		else
			problem= "invalid user/pass";
		//Debug.Log ("hi");

*/
		Application.LoadLevel("start");
			
		}

	
	IEnumerator HandleRegister(string userNamez, string passWordz)
	{
		string register_URL = register_url + "?username=" + userNamez + "&password=" + passWordz;

		WWW registerReader = new WWW(register_URL);
		yield return registerReader;
		
		HttpWebRequest connection =
			(HttpWebRequest)HttpWebRequest.Create(register_URL);
		
		connection.Method = "GET";
		HttpWebResponse response =
			(HttpWebResponse)connection.GetResponse();
		
		StreamReader sr =new StreamReader(response.GetResponseStream(),Encoding.UTF8);
		
		problem = "user registered";
		
		
		
		
		if(registerReader.error != null)
		{
			Debug.Log (registerReader);
		}else {
			if(registerReader.text == "registered")
			{
				problem ="Registered";
			}else 
			{
				problem = "didnotRegister";
			}
			
		}
		
		
	}
	
	IEnumerator storescore(string userNamez, string score)
	{
		string setScore = setscore + "?username=" + userNamez + "&score=" + score;
		/*	WebClient wp= new WebClient();
		wp.Proxy = new WebProxy("http://proxy.iiit.ac.in:8080");
		WebProxy wp1 = new WebProxy();
		wp1.Address = new System.Uri(register_URL);
		//string register_URL = register_url + "?username=" + userNamez + "&password=" + passWordz;
		Debug.Log (register_URL);
		*/
		Debug.Log (score);
		Debug.Log(userNamez);
		WWW registerReader = new WWW(setscore);
		yield return registerReader;
		
		HttpWebRequest connection =
			(HttpWebRequest)HttpWebRequest.Create(setScore);
		
		connection.Method = "GET";
		HttpWebResponse response =
			(HttpWebResponse)connection.GetResponse();
		
		StreamReader sr =new StreamReader(response.GetResponseStream(),Encoding.UTF8);
		
		
		

		
		
		if(registerReader.error != null)
		{
			Debug.Log (registerReader);
		}else {
			if(registerReader.text == "registered")
			{
				problem ="Registered";
			}else 
			{
				problem = "didnotRegister";
			}
			
		}
		
		
	}
	

	
}