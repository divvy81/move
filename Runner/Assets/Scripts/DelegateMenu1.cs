using UnityEngine;
using System.Collections;







public class DelegateMenu1 : MonoBehaviour {

	private delegate void MenuDelegate();


	private MenuDelegate menuFunction;

	public GUISkin skin1;
	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;
	public Texture2D back;
		public Font font;

	void Start(){
		screenHeight = Screen.height;
		screenWidth = Screen.width;

		buttonHeight = screenHeight * 0.3f;
		buttonWidth = screenWidth * 0.4f;

	}

	 void OnGUI(){
				GUI.skin = skin1;
				GUI.skin.box.normal.background = back;
				GUI.skin.font = font;
		GUI.Label (new Rect(Screen.width/2 - 130,60,260,50),"Kanyakumari to Kashmir");
		//Debug.Log ("hell");
				GUI.Box (new Rect (0, 0, 1400, 700), "");
		if(GUI.Button (new Rect (Screen.width / 2 - 100, (Screen.height / 2)+200 - 100, 250, 75),"EXIT")){
			Application.Quit();
		}
		if(GUI.Button (new Rect (Screen.width / 2 - 100, (Screen.height / 2)+200 - 150, 250, 75),"PLAY")){
			Application.LoadLevel("login");
		}
			//	menuFunction ();

	
	}
	


 

		

		
		

		

		
	
	
}
