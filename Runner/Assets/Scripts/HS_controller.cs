using UnityEngine;
using System.Collections;
using System.Net;

public class HS_controller : MonoBehaviour {

/*

	string login_url = "http://127.0.0.1/addscore.php";
	string register_url= "http://127.0.0.1:3306/register.php";
	string userName = "";
	string passWord = "";
	string problem  = "";

	void OnGUI ()
	{
		 GUI.Window ( 0 ,new Rect( Screen.width / 4 , Screen.height / 4, Screen.width / 2 , Screen.height / 2 - 70),LoginWindow, "login");
	}


	void LoginWindow(int windowId)
	{
		GUI.Label (new Rect(140 , 40,130,100),"~~~~username~~~~");
		userName = GUI.TextField (new Rect(25,60,375,30),userName);
		GUI.Label (new Rect(140,92,130,100),"~~~~password~~~~");
		passWord = GUI.TextField (new Rect (25,115,375,30),passWord);

		if(GUI.Button (new Rect(25,160,175,50),"Login"))
			StartCoroutine(HandleLogin (userName,passWord));
		if(GUI.Button (new Rect(225,160,175,50),"Register"))
			StartCoroutine(HandleRegister (userName,passWord));



		GUI.Label (new Rect(55,222,250,100),problem);

	}

	IEnumerator HandleLogin(string userNamez, string passWordz)
	{
		//problem = "Checking username and password....";
		string login_URL = login_url + "?username=" + userNamez + "&password=" + passWordz;
		WWW loginReader = new WWW(login_URL);
		yield return loginReader;


		if(loginReader.error != null)
		{
			problem = "could not locate page";
		}else {
			if(loginReader.text == "right")
			{
				problem ="logged in";
			}else 
			{
				problem = "invalid user/pass";
			}
			
			}
	}

	IEnumerator HandleRegister(string userNamez, string passWordz)
	{
		string register_URL = register_url + "?username=" + userNamez + "&password=" + passWordz;

				//string register_URL = register_url + "?username=" + userNamez + "&password=" + passWordz;
		Debug.Log (register_URL);
		WWW registerReader = new WWW(register_URL);
		yield return registerReader;
		
		
		if(registerReader.error != null)
		{
			Debug.Log (registerReader.error);
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
*/
}