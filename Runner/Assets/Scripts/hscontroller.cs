using UnityEngine;
using System.Collections;

public class hscontroller : MonoBehaviour {
	
	string loginURL = "http://127.0.0.1/login.php";
	string register_url= "http://127.0.0.1/register.php";
	
	public static string username = "";
	string password = "";
	string label = "";
	// currently database name= "Runner"
	//table = 
	// 1> users: Username,Password
	// 2> score: Username, TimeStamp,leftmove,rightmove,up,down,Average,timeplayed,coinscollected
	
	// Remove lan wire/internet and remove proxy from env variable and Lan Settings
	void OnGUI() {
		GUI.Window (0, new Rect (Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2 - 70), LoginWindow, "Login");
	}
	
	void LoginWindow(int windowID) {
		GUI.Label (new Rect (140, 40, 130, 100), "~~~~Username~~~~");
		username = GUI.TextField(new Rect(25, 60, 375, 30), username);
		GUI.Label (new Rect (140, 92, 130, 100), "~~~~~Password~~~~");
		password = GUI.PasswordField (new Rect (25, 115, 375, 30), password, '*');
		
		if (GUI.Button (new Rect (25, 160, 375, 50), "Login")) {
			StartCoroutine(HandleLogin());		
		}
		if(GUI.Button (new Rect(425,160,175,50),"Register"))
			StartCoroutine(HandleRegister (username,password));
		
		GUI.Label (new Rect (440, 90, 130, 100), label);
	}
	IEnumerator HandleLogin()
	{
		label = "Checking username and password";
		string login_URL = this.loginURL + "?username=" + username + "&password=" + password;
		
		WWW loginReader = new WWW (login_URL);
		yield return loginReader;
		Debug.Log ( login_URL+ " loginReader="+loginReader + " error= " + loginReader.error);
		
		if(loginReader.error != null)
		{
			label = "could not locate page";
			Debug.Log (loginReader.error);
		}else {
			if(loginReader.text == "success")
			{
				Application.LoadLevel("start");
				label ="logged in";
			}else 
			{
				label = "invalid user/pass";
			}
			
		}
	}
	IEnumerator HandleRegister(string userNamez, string passWordz)
	{
		string register_URL = register_url + "?username=" + userNamez + "&password=" + passWordz;
		
		//string register_URL = register_url + "?username=" + userNamez + "&password=" + passWordz;
		//Debug.Log (register_URL);
		WWW registerReader = new WWW(register_URL);
		yield return registerReader;
		
		
		if(registerReader.error != null)
		{
			label = "could not locate page";
			
		}else {
			if(registerReader.text == "registered")
			{
				label ="Registered";

			}else 
			{
				label = "didnotRegister";
			}
			
		}
	}
	
}