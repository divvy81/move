using UnityEngine;
using System.Collections;

public class obsgen : MonoBehaviour{
	public float startDistance = 8;
	public float zDistance = 10;
	public float minSpread = 10;
	public float maxSpread = 25;
	
	public Transform playerTransform;
	//public Transform[] obstaclePrefab;
	public GameObject[] objs;
	private bool cancall= true; 
	public float wtime;
	
	float zSpread;
	float lastZPos;
	private float x1;
	private float x2;
	
	void Awake()
	{
				//wtime=settings.time;

     }

	IEnumerator Start(){
		zSpread = Random.Range (minSpread, maxSpread);
		lastZPos = playerTransform.position.z + (startDistance - zSpread - zDistance);
		while(true)
		{
			yield return new WaitForSeconds(wtime);
			genr();
		}
	}

	void Update(){
		if (playerTransform.position.z - lastZPos >= zSpread) {
			if (cancall) {
				StartCoroutine (Wait(0.005f));
			
				
				lastZPos += zSpread;
				zSpread = Random.Range (minSpread, maxSpread);
				x2 = playerTransform.position.x;
			}
			//StartCoroutine (Wait (0.5f));
		}
		
		
	}
	IEnumerator Wait(float waitTime) {
		cancall = false;
		yield return new WaitForSeconds(waitTime);
		cancall = true;
		
	}
	void genr() {

				if (x2==5) {
			
						x1 = 3.0f;
				} else {
						x1 = 5.0f;
			
				}
				Instantiate (objs [Random.Range (0, objs.Length)], new Vector3 (x1, 0.0f, lastZPos + zSpread + zDistance + 32.0f), Quaternion.identity);
		}
	
}