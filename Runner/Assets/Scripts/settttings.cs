using UnityEngine;
using System.Collections;

public class settttings : MonoBehaviour {


	public Texture2D back;
	public Font font;
	public GUISkin mystyle1;
	private string textFieldString = "11";
	public static int refe=0;
	public GUIStyle mystyle;
	public static float time11=30.0f ;


	
	void OnGUI(){
		GUI.skin = mystyle1;
		if (GUI.Button (new Rect (1200, 20, 100, 50), "Back")) {
			Application.LoadLevel("start");
		}
		GUI.Label(new Rect (400,20,400,150),"Options",mystyle);
		GUILayout.BeginArea(new Rect (Screen.width / 2 - 325, Screen.height / 2 - 180, 700, 350));
		
		GUI.Box(new Rect(0, 20, 650, 350),"", GUI.skin.FindStyle("Box"));
		

		GUILayout.BeginArea(new Rect(5, 100, 600,350));

		GUILayout.BeginVertical();

		GUILayout.BeginHorizontal();

		
		GUILayout.Label("Sounds",GUILayout.MinWidth (100));
		if(GUILayout.Button("OFF",GUILayout.MinWidth(100)))
			AudioListener.volume = 0.0f;
		if(GUILayout.Button("ON",GUILayout.MinWidth(100)))
			AudioListener.volume = 1.0f;
		//GUILayout.Button("Distance",GUILayout.MinWidth(100));
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal();
		//GUILayout.BeginVertical();
		
		GUILayout.Label("Levels",GUILayout.MinWidth (100));
		if (GUILayout.Button ("Level01", GUILayout.MinWidth (100)))
						refe = 0;
		if (GUILayout.Button ("Level02", GUILayout.MinWidth (100)))
						refe = 1;
		//GUILayout.Button("Distance",GUILayout.MinWidth(100));
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal();
		//GUILayout.BeginVertical();
		
		GUILayout.Label("Control leg",GUILayout.MinWidth (100));
		GUILayout.Button("Right",GUILayout.MinWidth(100));
		GUILayout.Button("Left",GUILayout.MinWidth(100));
		//GUILayout.Button("Distance",GUILayout.MinWidth(100));
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal();
		//GUILayout.BeginVertical();
		
		GUILayout.Label("Time",GUILayout.MinWidth (100));
		//GUILayout.Button("Right",GUILayout.MinWidth(100));
		//GUILayout.Button("Left",GUILayout.MinWidth(100));
		//GUILayout.Button("Distance",GUILayout.MinWidth(100));
		textFieldString = GUILayout.TextField ( textFieldString,20,GUILayout.MinWidth(180), GUILayout.MaxWidth(250));
		if (textFieldString != "") {
			time11=float.Parse(textFieldString);
						//playermovement.seconds1 = float.Parse (textFieldString);
						//playermovement.seconds2 = float.Parse (textFieldString);
			Debug.Log(time11);
				}
		GUILayout.EndHorizontal ();



		GUILayout.EndVertical();
		GUILayout.EndArea();
		GUILayout.EndArea();
		/*	GUI.skin = mystyle1;
				GUI.skin.box.normal.background = back;
				GUI.skin.font = font;
			//	GUI.Box (new Rect (0, 0, 1400, 700), "");
		//GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 250));	
		GUI.Box(new Rect(0, 20, 650, 300),"");
		GUI.Label (new Rect (300, 90,200 , 80), "Sounds ");
		//GUI.Label(new Rect (350, 50, 500, 80), "Score:");
		if (GUI.Button (new Rect (500, 90, 100, 50), "Off")) {
			AudioListener.volume = 0.0f;
				}
		if (GUI.Button (new Rect (650, 90, 100, 50), "On")) {
			AudioListener.volume = 1.0f;
				}
		GUI.Label(new Rect (300, 190, 100, 80), "Levels");
		if (GUI.Button (new Rect (500, 190, 100, 50), "Level01")) {
			refe=0;
				}
		if (GUI.Button (new Rect (650, 190, 100, 50), "Level02")) {
			refe=1;
		}
	//	if (GUI.Button (new Rect (750, 190, 100, 50), "Level02")) {
			
	//	}
		if (GUI.Button (new Rect (1100, 20, 100, 50), "Back")) {
			Application.LoadLevel("start");
		}
		GUI.Label (new Rect (300, 290, 100, 80), "Time");
		textFieldString = GUI.TextField (new Rect (500, 290, 100, 50), textFieldString);

       */
		}
	  
}
