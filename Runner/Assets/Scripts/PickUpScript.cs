using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

	// Use this for initialization

	private static GUIText countText;
	public static int count=0;

	void Start()
	{
		countText = this.guiText;
		PickUpScript.SetCountText ();

	}
	public static void IncreaseCount()
	{
		count++;
		PickUpScript.SetCountText ();
		}

	// Update is called once per frame
			
	public static void SetCountText()
	{
		PickUpScript.countText.text = "Count: " + count.ToString();

	}

}
