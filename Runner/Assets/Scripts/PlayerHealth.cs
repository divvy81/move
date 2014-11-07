using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	private GUIStyle currentStyle = null;	
	public float maxHealth =100.0f;
	public float currentHealth = 10.0f;
	public static bool collided=false;
	public GameObject[] items; // for the fence around player.
	public static bool ShowCollisionFence;
	//Animator anim;
	//int runHash = Animator.StringToHash("Run");
	//int idleStateHash = Animator.StringToHash("Base Layer.Idle");
	// Use this for initialization
	void Start () {
		collided = false;
		//anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other)
	{

		Debug.Log (other);
		if (other.gameObject.tag == "Obstacle") {
			if(collided ==false)
			{
				collided = true;
				currentHealth -= 10.0f;
				//anim.StopPlayback("Run");
				//anim.Play("Idle");
				//anim.speed = 0.0f;
				if(ShowCollisionFence)
				{
					Instantiate (items [Random.Range (0, items.Length)],
				             new Vector3 (this.transform.position.x, 0.45f,this.transform.position.z ),
				             Quaternion.identity);
				}
			}
			//Debug.Log("Collision");
			if (currentHealth == 0) {

				collided = false;
				Application.LoadLevel ("gameover");
			}
			playermovement1.collision_count++;
			playermovement1.Collision_point = this.transform.position;
			
			collided =true;
			playermovement1.anim.SetBool (playermovement1.runHash,false);
			playermovement1.anim.speed=0.0f;


			//rigidbody.transform.Translate(new Vector3(0.0f, 0.0f,-1.0f) * 10 * Time.deltaTime);
			//Debug.Log(this.transform.position.z);


			//anim.speed = -1.0f;


			}
		if (other.gameObject.tag == "HealthIcon") {
						currentHealth += 10.0f;
						Destroy (other.gameObject);
						if (currentHealth > 100) {
								currentHealth = 100;
						}
				}
		}

	void OnGUI()
	{
		//GUI.color = Color.yellow;
		InitStyles();
		GUI.backgroundColor = Color.green;
		//GUILayout.Box( "I'm red" );
		GUI.Box (new Rect (Screen.width*30/100, 10, Screen.width / 2/(maxHealth/100) , 20),"");
		GUI.Box (new Rect (Screen.width*30/100, 10, Screen.width / 2/(maxHealth/currentHealth) , 20), currentHealth + "/" + maxHealth, currentStyle);
	}
	private void InitStyles()
	{
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 0.5f ) );
		}
	}
	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
}
