using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;


public class highscore : MonoBehaviour {

	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;
	public Texture2D back;
	public Font font;
	public GUIStyle mystyle;
	public GUISkin mystyle1;
	string highscore_url= "http://127.0.0.1/highscore.php";
	int[] previous_score = new int[ 40 ];
	string label ="";
	string[] Line = new string[40];



	void Start()
	{
		getHighScore ();
	}
	void getHighScore()
	{
		string highscore_url = this.highscore_url + "?username=" + hscontroller.username;
		HttpWebRequest connection =
			(HttpWebRequest)HttpWebRequest.Create(highscore_url);
		
		connection.Method = "GET";
		HttpWebResponse response =
			(HttpWebResponse)connection.GetResponse();
		//for(i=0;i<5;i++)
		
		StreamReader sr =new StreamReader(response.GetResponseStream(),Encoding.UTF8);
		{
			for(int i=0;i<34;i++)
			{
				Line[i]=sr.ReadLine();
				//Debug.Log ("the value is "+Line[i]);
			}
		}

	}


	void OnGUI(){
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		GUI.skin.box.normal.background = back;
		GUI.skin.font = font;
		//GUI.Box (new Rect(0,0,1400,700),"");
		GUI.Label(new Rect (380,0,200,150),"High Score",mystyle);
		GUI.Label(new Rect (10,120,200,80),"S.NO.");
		GUI.Label(new Rect (150,120,250,80),"Playername");
		GUI.Label(new Rect (390,120,200,80),"Score");
		GUI.Label(new Rect (540,120,200,80),"Average");
		GUI.Label(new Rect (740, 120, 200, 80), "LeftTurn");
		GUI.Label(new Rect (980, 120, 200, 80), "RightTurn");
		GUI.Label(new Rect (1210, 120, 200, 80), "TimePlay");
		GUI.Label(new Rect (1450, 120, 200, 80), "Date");
		if(GUI.Button(new Rect (1100,20,200,60),"BACK"))
		{
			Application.LoadLevel("start");
		}
		GUI.Label(new Rect (30,190,120,60),"1.");
		GUI.Label(new Rect (160,190,250,60),Line[0]);
		//Debug.Log(Line[0]);
		GUI.Label(new Rect (410,190,200,60),Line[1]);
		GUI.Label(new Rect (570,190,200,60),Line[2]);
		GUI.Label(new Rect (760,190, 200,60), Line [3]);
		GUI.Label(new Rect(990, 190, 200,60),Line[4]);
		GUI.Label(new Rect(1240, 190, 200,60),Line[5]);
		GUI.Label(new Rect(1450, 190, 450,60),Line[6]);
		GUI.Label(new Rect (30,260,120,60),"2.");
		GUI.Label(new Rect (160,260,250,60),Line[7]);
		GUI.Label(new Rect (410,260,200,60),Line[8]);
		GUI.Label(new Rect (570,260,200,60),Line[9]);
		GUI.Label(new Rect (760, 260, 200, 60), Line [10]);
		GUI.Label (new Rect (990, 260, 200, 60), Line [11]);
		GUI.Label(new Rect(1240, 260, 200,60),Line[12]);
		GUI.Label(new Rect(1450, 260, 400,60),Line[13]);
		GUI.Label(new Rect (30,330,120,60),"3.");
		GUI.Label(new Rect (160,330,250,60),Line[14]);
		GUI.Label(new Rect (410,330,200,60),Line[15]);
		GUI.Label(new Rect (570,330,200,60),Line[16]);
		GUI.Label (new Rect(760, 330, 200,60),Line[17]);
		GUI.Label(new Rect( 990,330,200,60),Line[18]);
		GUI.Label(new Rect(1240, 330, 200,60),Line[19]);
		GUI.Label(new Rect(1450, 330, 400,60),Line[20]);
		GUI.Label(new Rect (30,400,120,60),"4.");
		GUI.Label(new Rect (160,400,250,60),Line[21]);
		GUI.Label(new Rect (410,400,200,60),Line[22]);
		GUI.Label(new Rect (570,400,200,60),Line[23]);
		GUI.Label (new Rect (760, 400, 200,60),Line [24]);
		GUI.Label (new Rect (990, 400, 200, 60), Line [25]);
		GUI.Label(new Rect(1240, 400, 200,60),Line[26]);
		GUI.Label(new Rect(1450, 400, 400,60),Line[27]);
		GUI.Label(new Rect (30,470,120,60),"5.");
		GUI.Label(new Rect (160,470,250,60),Line[28]);
		GUI.Label(new Rect (410,470,200,60),Line[29]);
		GUI.Label(new Rect (570,470,200,60),Line[30]);
		GUI.Label (new Rect (760, 470, 200, 60), Line [31]);
		GUI.Label (new Rect (990, 470, 200, 60), Line [32]);
		GUI.Label(new Rect(1240, 470, 200,60),Line[33]);
		GUI.Label (new Rect (1450, 470, 400, 60), Line [34]);
    
	}
}
