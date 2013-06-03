using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
	
	float months;
	float days;
	float hours;
	float minutes;
	//public Timemanager Timemanagercomponent;

	// Use this for initialization
	void Start () 
	{
		
			
	}
	
	// Update is called once per frame
	void Update (){/*
		conversion();
		OnGUI();
	}
			
	void conversion () 
	{
		
		months = Timemanagercomponent.howmanymonthstotal();
		days = Timemanagercomponent.howmanydaystotal() - (months*10);
		hours = Timemanagercomponent.howmanyhourstotal() - (days*24);
		minutes = Timemanagercomponent.howmanyminutestotal() - (hours*60);
		
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 50, 50), (months.ToString()));
		GUI.Label(new Rect(10, 60, 50, 100), (days.ToString()));
		GUI.Label(new Rect(10, 110, 50, 150), (hours.ToString()));
		GUI.Label(new Rect(10, 160, 50, 200), (minutes.ToString()));
	}
	*/
	}
}
