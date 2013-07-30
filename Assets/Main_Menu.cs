using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {

	void OnGUI() 
	{
		
		GUI.Box(new Rect(100, 0, 200, 130), "My Dad is a Farmer!");
		
		if(GUI.Button(new Rect(110, 30, 80, 70), "Start Game")) 
		{
			Application.LoadLevel(0);
		}
		
	}		
		
}
