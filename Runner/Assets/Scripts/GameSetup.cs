using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

	public GameObject[] plate;
	private bool Value1 = true;
	//private bool Value2 = false;
	//private bool Value3 = false;

	
	// Update is called once per frame
	public void Track () {
				plate = GameObject.FindGameObjectsWithTag ("Plate");
	
				if (Value1) {
						plate [0].transform.Translate (new Vector3 (0, 0, 256.0f));

						//	Value2 = true;
						//	Value3 = false;

				}
		//else if(Value1 == false && Value2 == true && Value3 == false){
		//	plate[1].transform.Translate(new Vector3(0, 0, 192.0f));
		//	Value1 = false;
		//	Value2 = false;
		//	Value3 = true;
	//	}
		else {
						plate [1].transform.Translate (new Vector3 (0, 0, 256.0f));

						//Value2 = false;
						//	Value3 = false;
			
				}
				if (Value1) {
						Value1 = false;
				} else {
						Value1 = true;
				}

		}
}
