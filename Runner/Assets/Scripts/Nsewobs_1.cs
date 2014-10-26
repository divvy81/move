using UnityEngine;
using System.Collections;

public class Nsewobs_1 : MonoBehaviour{
public float startDistance = 8;
public float zDistance = 10;
public float minSpread = 10;
public float maxSpread = 25;
	int count=5;

public Transform playerTransform;
//public Transform[] obstaclePrefab;
public GameObject[] objs;
	private bool cancall= true; 

float zSpread;
float lastZPos;
private float x1;
	float k = 0.0f;

	/*void Avake()
	{
				Invoke ("Update", 2);

}
*/
void Start(){
				zSpread = Random.Range (minSpread, maxSpread);
				lastZPos = playerTransform.position.z + (startDistance - zSpread - zDistance);
	}
	
	void Update(){
				if (playerTransform.position.z - lastZPos >= zSpread) {
						if (cancall) {
								StartCoroutine (Wait (0.05f));
								if(Random.Range (-2,3)>0){
				
									x1 = 3.0f;
								}
								else {
									x1 = 5.0f;

								}
				k=lastZPos + zSpread + zDistance + 32.0f;
				if((k%128) > 8 && (k%128) < 120){

								Instantiate (objs [Random.Range (0, objs.Length)], new Vector3 (x1, 0.0f, k), Quaternion.identity);
				}
								lastZPos += zSpread;
								zSpread = Random.Range (minSpread, maxSpread);

						}
			//StartCoroutine (Wait (0.5f));
				}


	}
	IEnumerator Wait(float waitTime) {
		cancall = false;
		yield return new WaitForSeconds(waitTime);
		cancall = true;

		}


}