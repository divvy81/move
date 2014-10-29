using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class HardwareInput : MonoBehaviour {

	int Total_serial_ports=4;
	int move_front = 0; // 0 = movig front 
	//1 = trying to change movement  2 = moving back 

	int[] serialPort = new int[ 6 ]; // No. of consecutive input on this port, 5th one represents previous input. 
	public static bool[] give_output = new bool[5]; // wether/not to reject hardware input.
/*
 * 		 Screen
 * 
 *       	1    
 * 
 * 		 2		3
 * 
 * 			4
 * 
 * 
 */


	SerialPort sp = new SerialPort("COM5", 9600);
	int ch;
	// Use this for initialization
	void Start () {
		int i;
		for (i=0; i<=Total_serial_ports + 1; i++) {
			serialPort[i] = 0;
			give_output[i] = false;
		}
		serialPort[i] = -1;

	}

	
	// Update is called once per frame
	void Update () {
		sp.Open();
		sp.ReadTimeout = 1;
		//sp.Write ("9");
		//Debug.Log ("heai");
	}
	void FixedUpdate () {

		if (sp.IsOpen) 
		{
		try {
				ch = sp.ReadByte ();
			} 
			catch (System.Exception) 
			{
				Debug.Log("bad input from hardware");
			}
		}
	
		//check_move_direction();
		// which is pressed
		if (give_output[ch]==true) 
		{

			if((serialPort[5]!=ch))
			{
				serialPort[serialPort[5]] = 0; //no. of input is 0
				give_output[serialPort[5]] = false;
			}
			serialPort[ch]++;
			serialPort[5] = ch;
			if(serialPort[ch] >=20)
			{
				give_output[ch]=true;
			}
		}
	}
	/*void check_move_direction()
	{

		if ((move_front == 0) && ((give_output[3]) || (give_output[4])))
		{
			move_front = 1; // trying to move back
		}
		if ((move_front == 1) && ((give_output [3]) && (give_output [4]))) {
			move_front = 2;
			give_output [3] = false;
			give_output [4] = false;
		}

		if ((move_front == 3) && ((give_output[1]) || (give_output[2])))
		{
			move_front = 1; // trying to move back
		}
		if ((move_front == 1) && ((give_output [1]) && (give_output [2]))) {
				move_front =0; // now moving front
				give_output [1] = false;
				give_output [2] = false;
					
			}

	}*/
}
