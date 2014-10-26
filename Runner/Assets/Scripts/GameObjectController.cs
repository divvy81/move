using UnityEngine;
using System.Collections;

public class GameObjectController : MonoBehaviour {
	
	// for coins and obstacles
	public GameObject[] items;
	public int minSpread = 15;
	public int maxSpread = 45;
	private float next_x; // how much ahead is the next instance created
	private float next_y;
	private float next_z;
	public float last_object_z_position=24.0f;
	public static float no_of_objects=1;

	bool create_new_track=false;
	int track_counter = 1;
	float track_length=128.0f;// 
	public static int no_of_tracks=2;
	public GameObject[] tracks;
	float next_track_at;
	int max_no_of_tracks=2;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		UpdateItems ();
		UpdateTracks ();

	}
	void UpdateItems()
	{
		// next_z is not correct
		next_x = getNew_x ();
		next_y = 0.45f; //default height for game objects
		next_z = getNew_z ();
		if (Random.Range (0, 1000) % 100 == 0) {
			if (no_of_objects < 5)
			{
				Instantiate (items [Random.Range (0, items.Length)], new Vector3 (next_x, 0.0f, next_z), Quaternion.identity);
				last_object_z_position = next_z;
				no_of_objects++;
			}
		}

	}
	void UpdateTracks()
	{
		if (track_counter * track_length < GameObject.FindGameObjectWithTag ("Player").transform.position.z) {
						create_new_track = true;
				}
		if (create_new_track) {
				if (no_of_tracks <= max_no_of_tracks) {
				next_track_at = GameObject.FindGameObjectWithTag ("Player").transform.position.z + track_length;
						Instantiate (tracks [Random.Range (0, tracks.Length)], new Vector3 (0.0f, 0.0f, next_track_at), Quaternion.identity);
						no_of_tracks++;
						track_counter++;
				create_new_track = false;
				}
		}
	}
	float getNew_x()
	{
		float return_value=0.0f;
		int n = Random.Range (0, 100);
		if (n % 2 == 0) {
			return_value = 3.0f; // left side of road
		}
		else {
			return_value= 5.0f; // right side of road
		}
		return return_value;
	}
	
	float getNew_z()
	{
		float return_value;
		int n = Random.Range (minSpread, maxSpread);
		return_value = (float)n;
		return_value += GameObject.FindGameObjectWithTag ("Player").transform.position.z + last_object_z_position; 
		return return_value;
	}
	
}