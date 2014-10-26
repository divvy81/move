using UnityEngine;
using System.Collections;
using System;
using System.IO.Ports;

public class playermovement3 : MonoBehaviour 
{
	//private Rect windowRect = new Rect (Screen.width/2, 40, 120, 50);
	public float speed = 0.0f;
	public static string scoreText="Score : 0";
	public string speedText="Speed :10 km/h";
	public string Distance="Distance : 0 km";

	public static int score=0;
	public static int count=5;
	public static string life="X 5";
	public static float caldis=0.0f;
	private bool left = true;
	private bool right = false;
	public GUISkin theskin;
	public GUISkin myskin ;
	public float maxspeed = 30.0f;
	public static bool paused = false;
	public static int leftturn=0;
	private bool check = false;
	private float checkDistance = 200;
	public static int rightturn=0;
	SerialPort sp = new SerialPort("COM5", 9600);
	int ch;
	public Texture[] image;
	public static float vari =10;
	//public float seconds=30.0f;
	public GUIStyle style;
	private GameObject girl;
	public static float seconds1=settttings.time11;
	public static float seconds2= settttings.time11;
	public float timer = 0.0f;
	public int min = 0;
	public int hrs=0;
	public static string t;


	void Start()
	{
		sp.Open();
		sp.ReadTimeout = 1;
		//sp.Write ("9");
		//Debug.Log ("heai");
		//image = (Texture)Resources.Load("pokeball");
	}


	void FixedUpdate () {

		vari -= Time.deltaTime; 
		if (sp.IsOpen) {
						try {
								ch = sp.ReadByte ();
						} catch (System.Exception) {
						}
				}

			if (gameObject.transform.position.x > 4) {
				seconds1 -= Time.deltaTime;
				seconds2=settttings.time11;
				if (Mathf.Round (seconds1) == 0) {
					Time.timeScale = 0;
					paused = true;
				}
			} else if (gameObject.transform.position.x < 4) {
				seconds2 -= Time.deltaTime;
				seconds1 = settttings.time11;
				if (Mathf.Round (seconds2) == 0) {
					Time.timeScale = 0;
					paused = true;
				}
			}



	//	sp.Write("9");
		/*
		if(speed <= 0){
			girl.animation.Stop("Run");
		}
		else {
			girl.animation.Play("Run");
		}
		*/




			rigidbody.freezeRotation = true;
		//if(Input.GetAxis("Vertical") > 0.0f){

		   if (ch == 4 && speed < maxspeed) {
				speed=speed+2;
			ch=5;
				if(speed > maxspeed)
					speed=maxspeed;
			}
				rigidbody.AddRelativeForce (0, 0, speed);
		
			if(ch == 3) {
				speed=speed-2;
			ch = 5;	
			if(speed<=0)
					speed=0;
			}
		//rigidbody.AddRelativeForce (0, 0, speed);
		//	}
	//	if(Mathf.Round(vari)<-1)
		//rigidbody.AddRelativeForce (0, 0, speed);
		timer += Time.deltaTime;
		float currentSpeed = Mathf.Abs (transform.InverseTransformDirection (rigidbody.velocity).z);
		
		//float maxAngularDrag 			=200.0f;
		//float currentAngularDrag 		= 100.0f;
		//float aDragLerpTime			    =	currentSpeed*0.1f;
		
		float maxDrag 			= 1.0f;
		float currentDrag 		= 2.0f;
		float dragLerpTime			    =	currentSpeed*0.1f;
		
		//float myAngularDrag=Mathf.Lerp (currentAngularDrag,maxAngularDrag,aDragLerpTime);
		float myDrag = Mathf.Lerp (currentDrag, maxDrag, dragLerpTime);

		

		if (ch == 1 && (left == false)) {
			;

			rigidbody.transform.Translate(new Vector3(-10.0f, 0, 0) * 10 * Time.deltaTime);
			leftturn++;
			left = true;
			right = false;


		} 
		else if (ch == 2 && (right == false)) {


			rigidbody.transform.Translate(new Vector3(10.0f, 0, 0) * 10 * Time.deltaTime);
			rightturn++;
			left = false;
			right = true;

		}
		speedText = "Speed :" +speed +"km/h";
		caldis = GameObject.FindGameObjectWithTag ("Player").transform.position.z;

		Distance =  "Distance : " + Mathf.Round(caldis) + "m";
		//rigidbody.angularDrag = myAngularDrag;
		rigidbody.drag = myDrag;
	    if (Input.GetKey (KeyCode.Space)) {
						if (!paused) {
								Time.timeScale = 0;
								paused = true;
						} else {
								Time.timeScale = 1;
								paused = false;
						}
				}

	}

	 void OnGUI()
	{


		GUI.Label (new Rect(10,85,70,70),image[0]);
		GUI.Label (new Rect (10, 10, 70, 70), image [1]);

		GUI.skin=theskin;
		var style1 = theskin.customStyles[0];

		if (Mathf.Round (vari) >= 0) {
						GUI.Label (new Rect (Screen.width / 2, Screen.height / 2 - 100, 200, 200), vari.ToString ("f0"),style);
						
				}
				if(Mathf.Round(vari) == -1 )
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2 - 100, 200, 200), "GO!",style);
		//var speed = rigidbody.velocity.magnitude * 3.6f;
		GUI.Box(new Rect(0, Screen.height - 120,140,55), "", GUI.skin.FindStyle("Box"));

		GUI.Label (new Rect(100, Screen.height - 50,100,400), "" + Mathf.Round(speed) , style1);
		Debug.Log ("value of speed is " + speed);
		GUI.Label (new Rect(40, Screen.height - 50,100,400),"KM/H : ");
		GUI.Box(new Rect(Screen.width - 250, Screen.height - 120,250,55), "", GUI.skin.FindStyle("Box"));
		GUI.Label (new Rect(Screen.width -150, Screen.height - 50,100,400), "" + Mathf.Round(caldis), style1);
		GUI.Label (new Rect(Screen.width-200, Screen.height - 50,100,400),"M : ");
		GUI.skin = myskin;
		if (playermovement3.score == 0) 
				{
						scoreText = " X " + playermovement3.score;
						life = "X "+ playermovement3.count;
				}
		GUI.Label(new Rect(0,25,80,80),scoreText);
		//GUI.Label(new Rect(Screen.width-320,10,500,200),speedText);
		//GUI.Label(new Rect(Screen.width/2-210,10,500,200),Distance);
		GUI.Label (new Rect (5, 100, 80, 80), life);


		if (caldis > checkDistance && caldis < (checkDistance + 150.0f)) {
			GUI.skin = theskin;
						GUI.color = Color.white;
			GUI.contentColor = Color.black;
						//windowRect = GUI.Window (0, windowRect, doWindow,"Checkpoint!");
			GUI.Box(new Rect(Screen.width/2 - 60, 40, 120, 40),"Checkpoint!!");

						check = true;
			GUI.skin = myskin;
				} else if (check) {
						checkDistance = checkDistance + 500;
						check = false;
				}

		if (paused) {
						if (GUI.Button (new Rect (Screen.width-150, 30, 100, 30), "Resume")) {
				seconds1=settttings.time11;
				seconds2=settttings.time11;
								Time.timeScale = 1.0f;
								paused = false;
						}

			if (GUI.Button (new Rect (Screen.width-150, 60, 100, 30), "MainMenu")) {
				Application.LoadLevel("start");
				//sp.Write("9");
						}
			if (GUI.Button (new Rect (Screen.width-150, 90, 100, 30), "Quit")) {
				Application.Quit();

						}
				}
		if (timer > 59.0f) {
			min = min + 1;
			timer = 0.0f;
		}
		if (min > 59) {
			hrs = hrs + 1;
			min = 0;
		}
		t = hrs + ":" + min + ":" + timer.ToString ("f0");
		GUI.Label (new Rect (Screen.width - 200, 10, 100, 40), t);
		/*if (AudioListener.volume != 0 && GUI.Button (new Rect (10, 150, 100, 30), "Off")) {
						AudioListener.volume = 0;
				}
		if (AudioListener.volume == 0 && GUI.Button (new Rect (10, 150, 100, 30), "On")) {
			AudioListener.volume = 100;
		}*/
		//	GUI.Box (new Rect (10, 10, 100, 50), scoreText );
	//	GUI.Box(new Rect(110,10,100,50),speedText);


}
	void doWindow(int windowID)
	{
			//	print ("got a click in window with color " + GUI.color);
		}
	 

}