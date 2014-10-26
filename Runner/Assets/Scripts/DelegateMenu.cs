using UnityEngine;
using System.Collections;

[System.Serializable]
public class LoadLevelInformation{
	public string mapName;
	public string sceneName;
	public Texture mapPreview;
}

[System.Serializable]
public class LoadAvatarInformation{
	public Transform AvatarPreview;
	public string TagName;
}

public class DelegateMenu : MonoBehaviour {

	private delegate void MenuDelegate();

	public static int lev = 0;
	public LoadAvatarInformation[] loadAvatarInfo;
	private MenuDelegate menuFunction;
	private GameObject Destr1;
	private GameObject Destr2;
	int check = 0;
	int AvatarIndex = 0;
	public GUISkin skin1;
	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;
	public Texture2D back;
	public Texture2D imag;
	private string menuState;
	public static string playerName="Player";
	public Font font;

	void Start(){
	

		screenHeight = Screen.height;
		screenWidth = Screen.width;

		buttonHeight = screenHeight * 0.3f;
		buttonWidth = screenWidth * 0.4f;

		//menuFunction = anyKey;
		menuState = "1";
		//imag = Resources.Load ("th.jpeg")as Texture2D;
		Debug.Log ("in start");
	}

	 void OnGUI(){
				GUI.skin = skin1;

				GUI.skin.box.normal.background = back;
				GUI.skin.font = font;
//		Debug.Log ("hell");
				GUI.Box (new Rect (0, 0, 1400, 700), "");
			//	menuFunction ();

//		Debug.Log (menuState);
				switch (menuState) {
				case "setavatarstyle":
						SetAvatarStyle ();
						break;
				case "anykey":
						mainMenu ();
						break;
				case "playerstats":
						SetPlayerName();
						break;
				case "1":
				mainMenu ();
				break;
		}
	}

	void SetPlayerName(){
		GUI.skin = skin1;
		GUILayout.BeginArea(new Rect(Screen.width / 2 - 85, Screen.height / 2 - 50, 200, 200));
		GUI.Box(new Rect(0,40,200,80), "", GUI.skin.FindStyle("Box"));
		GUILayout.Label("Player Name", GUI.skin.FindStyle("Lable"));
		GUILayout.BeginHorizontal();
		GUILayout.Space(10);
		playerName = GUILayout.TextField(playerName,20,GUILayout.MinWidth(180), GUILayout.MaxWidth(250));
		Debug.Log (playerName);
		
		GUILayout.Space(15);
		GUILayout.EndHorizontal();

		//if (UtilsC.IsStringCorrect (playerName)) {
		if (playerName != "") {
			GUILayout.BeginHorizontal ();
			GUILayout.Space (50);
			if (GUILayout.Button ("Exit", GUI.skin.FindStyle ("Button"), GUILayout.MaxWidth (100)))
				Application.Quit ();
			if (GUILayout.Button ("OK", GUI.skin.FindStyle ("Button"), GUILayout.MaxWidth (100))) {
				PlayerPrefs.SetString ("playerName", playerName);
				playerstats.getScores(playerName);
				Application.LoadLevel("stats");
			}
			GUILayout.Space(50);
			GUILayout.EndHorizontal();
		}	
			
		else
			GUILayout.Label("Enter your player name!",GUI.skin.FindStyle("Lable")); 
		
		GUILayout.EndArea();
	}
	
	void anyKey(){
		if(Input.anyKey){
			menuFunction = mainMenu;
		}
		GUI.skin = skin1;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label (new Rect(screenWidth * 0.25f, screenHeight * 0.45f, screenWidth * 0.5f, screenHeight * 0.5f),"Press any key to continue...");
		menuState = "anykey";
		Debug.Log ("in anykey");
	}

 public	void mainMenu(){
		/*
		Debug.Log ("in mainmenu");
		GUI.skin = CustomSkin;
		if(GUI.Button(new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.1f, buttonWidth, buttonHeight),"Start")){
			Application.LoadLevel("level01");
		}

		if(GUI.Button(new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.5f, buttonWidth, buttonHeight),"Quit")){
			Application.Quit();
	*/
		GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 250));
		GUILayout.Label("MAIN MENU", GUILayout.MaxWidth(300));
		
		if (GUILayout.Button ("NewGame", GUILayout.MaxWidth (200)))
			menuState ="setavatarstyle";
				
		if (GUILayout.Button ("Settings", GUILayout.MaxWidth (200)))
						Application.LoadLevel ("settings");
		if (GUILayout.Button ("High Score", GUILayout.MaxWidth (200)))
			Application.LoadLevel ("HS");
		if (GUILayout.Button ("PlayerStats", GUILayout.MaxWidth (200)))
						menuState = "playerstats";
		
		//			if(GUILayout.Button ("Play Offline",GUILayout.MaxWidth(200)))
		//				menuState = "offlinegame";
		
		if(GUILayout.Button ("Exit",GUILayout.MaxWidth(200)))
			Application.Quit();
		GUI.EndGroup ();
	}

	 public void SetAvatarStyle(){
		if (check == 0){
			Debug.Log("hello");
			Instantiate(loadAvatarInfo[AvatarIndex].AvatarPreview);
			check = 1;
		}
		//Menu color selection
		

		
		

		
		GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height - 100, 200, 53));
		GUILayout.Label("SELECT CAR");
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Prev",GUILayout.MinWidth(70))){
			
			Destr1= GameObject.FindWithTag("Player");
			Destroy (Destr1);
			
			
			if(AvatarIndex == 0)
				
				AvatarIndex = loadAvatarInfo.Length-1;
			
			else
				AvatarIndex--;
			Instantiate(loadAvatarInfo[AvatarIndex].AvatarPreview);
		}
		
		if (GUILayout.Button("Next",GUILayout.MinWidth(70))){
			
			Destr2= GameObject.FindWithTag("Player");
			Destroy (Destr2);
			
			if(AvatarIndex == loadAvatarInfo.Length-1)
				AvatarIndex = 0;
			else
				AvatarIndex++;
			Instantiate(loadAvatarInfo[AvatarIndex].AvatarPreview);
		}
		
		if (GUILayout.Button("OK", GUILayout.MaxWidth(55))){
			playermovement.score = 0 ;
			playermovement.count = 5;
			playermovement.leftturn=0;
			playermovement.rightturn=0;
			playermovement1.score = 0 ;
			playermovement1.count = 5;
			playermovement1.leftturn=0;
			playermovement1.rightturn=0;
			playermovement2.score = 0 ;
			playermovement2.count = 5;
			playermovement2.leftturn=0;
			playermovement2.rightturn=0;
			playermovement3.score = 0 ;
			playermovement3.count = 5;
			playermovement3.leftturn=0;
			playermovement3.rightturn=0;
			playermovement.vari=10;
			playermovement1.vari=10;
			playermovement2.vari=10;
			playermovement3.vari=10;
			if(playermovement.paused == true)
			{
				Time.timeScale = 1.0f;
				playermovement.seconds1=settttings.time11;
				playermovement.seconds2=settttings.time11;
				playermovement.paused=false;
			}
				else if(playermovement1.paused == true)
			{
				Time.timeScale = 1.0f;
				playermovement1.seconds1=settttings.time11;
				playermovement1.seconds2=settttings.time11;
				playermovement1.paused=false;
			}
			else if(playermovement2.paused == true)
			{
				Time.timeScale = 1.0f;
				playermovement2.seconds1=settttings.time11;
				playermovement2.seconds2=settttings.time11;
				playermovement2.paused=false;
			}
			else if(playermovement3.paused == true)
			{
				Time.timeScale = 1.0f;
				playermovement3.seconds1=settttings.time11;
				playermovement3.seconds2=settttings.time11;
				playermovement3.paused=false;
			}
			playermovement.seconds1=settttings.time11;
			playermovement.seconds2=settttings.time11;
			playermovement1.seconds1=settttings.time11;
			playermovement1.seconds2=settttings.time11;
			playermovement2.seconds1=settttings.time11;
			playermovement2.seconds2=settttings.time11;
			playermovement3.seconds1=settttings.time11;
			playermovement3.seconds2=settttings.time11;
			
			//Debug.Log("last vlaue" + playermovement.count) ;
			if(AvatarIndex == 0&& settttings.refe==0){
				lev=1;
				Application.LoadLevel("level01");}
			else if(AvatarIndex == 0&& settttings.refe==1){
				lev=3;
			
				Application.LoadLevel("level03");
			}
			else if(AvatarIndex == 1&& settttings.refe==0){
				lev=2;
				Application.LoadLevel("level02");
			}
			else if(AvatarIndex == 1&& settttings.refe==1){
					lev=4;
				Application.LoadLevel("level04");
			}
			//playermovement.score = 0 ;
	//		PlayerPrefs.SetString("playerName", networkConnection.playerName);
			
			Destr2= GameObject.FindWithTag("Player");
			Destroy (Destr2);
			
			//Netw = GameObject.Find("Network");
			//Netw.gameObject.tag = (loadAvatarInfo[AvatarIndex].TagName);
			
			//menuState = "menublock";
		}
		GUILayout.EndHorizontal();
		//if(loadLevelInfo[levelIndex].mapPreview)
	//		GUILayout.Box(loadLevelInfo[levelIndex].mapPreview, GUI.skin.FindStyle("Box"));
	//	else
	//		GUILayout.Box("No Image");
		GUILayout.EndVertical();
		GUILayout.EndArea();
		
	}
	
	
}
