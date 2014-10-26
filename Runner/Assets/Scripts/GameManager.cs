using UnityEngine;
using System.Collections;

public class GameManager : GameSetup {


	void OnTriggerEnter(Collider C){
		//Debug.Log ("Its Working!!");
		if(C.collider.tag == "Plate"){
		//	GameSetup g = new GameSetup();
			Track ();
		}
	}

}
