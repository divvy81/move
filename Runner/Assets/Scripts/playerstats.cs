using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;


public class playerstats : MonoBehaviour {

	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;
	public Texture2D back;
	public Font font;
	public GUIStyle mystyle;
	public GUISkin mystyle1;
	public static string statsurl="http://localhost/stats.php";
	public static string[] Line1 = new string[35];
	public static int i;
	//GUIText stats;

	void Start()
	{
		//stats.text = "Loading...";		
		StartCoroutine(getScores (DelegateMenu.playerName));
		guiText.tabSize = 40;
		guiText.alignment = TextAlignment.Left;
		guiText.fontSize = 16;
		guiText.richText = true;
				
	}



	void OnGUI(){

		screenHeight = Screen.height;
		screenWidth = Screen.width;
		GUI.skin.box.normal.background = back;
		GUI.skin.font = font;
		//GUI.Box (new Rect(0,0,1400,700),"");
		/*
		GUI.Label(new Rect (450,0,400,150),"Player Stats",mystyle);
		GUI.Label(new Rect (120,120,200,80),"S.NO.");
		GUI.Label(new Rect (250,120,300,80),"Playername");
		GUI.Label(new Rect (510,120,250,80),"Score");
		GUI.Label(new Rect (720,120,250,80),"Distance");
		GUI.Label(new Rect (930, 120, 250, 80), "LeftTurn");
		GUI.Label(new Rect (1140, 120, 250, 80), "RightTurn");
		if(GUI.Button(new Rect (1100,20,200,60),"BACK"))
		{
			Application.LoadLevel("start");
		}
		GUI.Label(new Rect (130,190,120,60),"1.");
		GUI.Label(new Rect (260,190,250,60),Line1[0]);
		//Debug.Log(coindelete.Line[0]);
		GUI.Label(new Rect (520,190,200,60),Line1[1]);
		GUI.Label(new Rect (730,190,200,60),Line1[2]);
		GUI.Label(new Rect (935,190, 200,60), Line1 [3]);
		GUI.Label(new Rect(1145, 190, 200,60),Line1[4]);
		GUI.Label(new Rect (130,260,120,60),"2.");
		GUI.Label(new Rect (260,260,250,60),Line1[5]);
		GUI.Label(new Rect (520,260,200,60),Line1[6]);
		GUI.Label(new Rect (730,260,200,60),Line1[7]);
		GUI.Label(new Rect (935, 260, 200, 60), Line1 [8]);
		GUI.Label (new Rect (1140, 260, 200, 60),Line1[9]);
		GUI.Label(new Rect (130,330,120,60),"3.");
		GUI.Label(new Rect (260,330,250,60),Line1[10]);
		GUI.Label(new Rect (520,330,200,60),Line1[11]);
		GUI.Label(new Rect (730,330,200,60),Line1[12]);
		GUI.Label (new Rect(945, 330, 200,60),Line1[13]);
		GUI.Label(new Rect( 1140,330,200,60),Line1[14]);
		GUI.Label(new Rect (130,400,120,60),"4.");
		GUI.Label(new Rect (260,400,250,60),Line1[15]);
		GUI.Label(new Rect (520,400,200,60),Line1[16]);
		GUI.Label(new Rect (730,400,200,60),Line1[17]);
		GUI.Label (new Rect (945, 400, 200,60),Line1 [18]);
		GUI.Label (new Rect (1140, 400, 200, 60), Line1 [19]);
		GUI.Label(new Rect (130,470,120,60),"5.");
		GUI.Label(new Rect (260,470,250,60),Line1[20]);
		GUI.Label(new Rect (520,470,200,60),Line1[21]);
		GUI.Label(new Rect (730,470,200,60),Line1[22]);
		GUI.Label (new Rect (945, 470, 200, 60), Line1 [23]);
		GUI.Label (new Rect (1140, 470, 200, 60), Line1 [24]);
		*/
       
		if(GUI.Button(new Rect (1100,20,200,60),"BACK"))
		{
			Application.LoadLevel("start");
		}
		//GUI.Label(new Rect (380,0,200,150),"Loading",mystyle);

/*

		GUI.Label(new Rect (380,0,200,150),"Player Stats",mystyle);
		GUI.Label(new Rect (10,120,200,80),"S.NO.");
		GUI.Label(new Rect (150,120,250,80),"Playername");
		GUI.Label(new Rect (390,120,200,80),"Score");
		GUI.Label(new Rect (540,120,200,80),"Distance");
		GUI.Label(new Rect (740, 120, 200, 80), "LeftTurn");
		GUI.Label(new Rect (980, 120, 200, 80), "RightTurn");
		GUI.Label(new Rect (1210, 120, 200, 80), "TimePlay");
		GUI.Label(new Rect (1450, 120, 200, 80), "Date");

		GUI.Label(new Rect (30,190,120,60),"1.");
		GUI.Label(new Rect (160,190,250,60),Line1[0]);
		//Debug.Log(Line1[0]);
		GUI.Label(new Rect (410,190,200,60),Line1[1]);
		GUI.Label(new Rect (570,190,200,60),Line1[2]);
		GUI.Label(new Rect (760,190, 200,60), Line1 [3]);
		GUI.Label(new Rect(990, 190, 200,60),Line1[4]);
		GUI.Label(new Rect(1240, 190, 200,60),Line1[5]);
		GUI.Label(new Rect(1450, 190, 450,60),Line1[6]);
		GUI.Label(new Rect (30,260,120,60),"2.");
		GUI.Label(new Rect (160,260,250,60),Line1[7]);
		GUI.Label(new Rect (410,260,200,60),Line1[8]);
		GUI.Label(new Rect (570,260,200,60),Line1[9]);
		GUI.Label(new Rect (570,260,200,60),Line1[9]);
		GUI.Label(new Rect (760, 260, 200, 60), Line1 [10]);
		GUI.Label (new Rect (990, 260, 200, 60), Line1 [11]);
		GUI.Label(new Rect(1240, 260, 200,60),Line1[12]);
		GUI.Label(new Rect(1450, 260, 400,60),Line1[13]);
		GUI.Label(new Rect (30,330,120,60),"3.");
		GUI.Label(new Rect (160,330,250,60),Line1[14]);
		GUI.Label(new Rect (410,330,200,60),Line1[15]);
		GUI.Label(new Rect (570,330,200,60),Line1[16]);
		GUI.Label (new Rect(760, 330, 200,60),Line1[17]);
		GUI.Label(new Rect( 990,330,200,60),Line1[18]);
		GUI.Label(new Rect(1240, 330, 200,60),Line1[19]);
		GUI.Label(new Rect(1450, 330, 400,60),Line1[20]);
		GUI.Label(new Rect (30,400,120,60),"4.");
		GUI.Label(new Rect (160,400,250,60),Line1[21]);
		GUI.Label(new Rect (410,400,200,60),Line1[22]);
		GUI.Label(new Rect (570,400,200,60),Line1[23]);
		GUI.Label (new Rect (760, 400, 200,60),Line1 [24]);
		GUI.Label (new Rect (990, 400, 200, 60), Line1 [25]);
		GUI.Label(new Rect(1240, 400, 200,60),Line1[26]);
		GUI.Label(new Rect(1450, 400, 400,60),Line1[27]);
		GUI.Label(new Rect (30,470,120,60),"5.");
		GUI.Label(new Rect (160,470,250,60),Line1[28]);
		GUI.Label(new Rect (410,470,200,60),Line1[29]);
		GUI.Label(new Rect (570,470,200,60),Line1[30]);
		GUI.Label (new Rect (760, 470, 200, 60), Line1 [31]);
		GUI.Label (new Rect (990, 470, 200, 60), Line1 [32]);
		GUI.Label(new Rect(1240, 470, 200,60),Line1[33]);
		GUI.Label (new Rect (1450, 470, 400, 60), Line1 [34]);

*/
		}

	IEnumerator getScores(string username) 
	{
		//stats.text = "Loading Scores...";
		//string username = hscontroller.username;
		Debug.Log ("username=" + username);
		string stats_URL = statsurl + "?username=" + username;

		WWW statsReader = new WWW(stats_URL);
		yield return statsReader;

		if (statsReader.error != null)
		{
			Debug.Log(statsReader.error);
		}
		else
		{
			Debug.Log (statsReader.text);
			this.guiText.text = statsReader.text; // this is a GUIText that will display the scores in game.
		}
		/*

		HttpWebRequest connection =
			(HttpWebRequest)HttpWebRequest.Create(highscore_Url);
		
		connection.Method = "GET";
		HttpWebResponse response =
			(HttpWebResponse)connection.GetResponse();
				
		StreamReader sr =new StreamReader(response.GetResponseStream(),Encoding.UTF8);
		{
			for(i=0;i<35;i++)
			{
				Line1[i]=sr.ReadLine();
				Debug.Log (Line1[i]);
			}
		}
		*/
		
		
		
	}
}
