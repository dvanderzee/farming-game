using UnityEngine;
using System.Collections;
using System.Text;

public class Timemanager : MonoBehaviour {
	/* There are 60 minutes in an hour, 24 hours in a day, 10 days in a month, 4 months in a year. */
	
	float minutes; 					// in game minutes
	public static float time;		// main variable
	float hours; 					// in game hours
	float days; 					// in game days
	float months; 					// in game months
	float sleeptime = 0; 			// how long the player decides to sleep for
	bool inputdisplay = false;		// whether the input display is shown or not
	string stringToEdit = "";		// holder for player input before converted into float sleeptime
	public MouseLook MouseLookcomponent;
	public MouseLook MouseLookcomponent2;
	

	// Use this for initialization
	void Start () 
	{
	time = 540;
	}
	
	// Update is called once per frame
	void Update () 
	{
		time = time + Time.deltaTime;//time is how many in game minutes have passed
		sleeptime = 0;
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			inputdisplay = true;
		}
	
	}
		
	public float howmanyminutestotal () 
	{
		minutes = time;
		
		return minutes;
	}
	
	public float howmanyhourstotal () 
	{
		hours  = (time/60);
		return hours;
	}
	
	public float howmanydaystotal () 
	{
		days = (time/1440.0f);
		return days;
	}	
	
	public float howmanymonthstotal () 
	{
		months = (time/14400.0f);
		return months;
	}
	
	public float howmuchsleep ()
	{
		return sleeptime;	
	}
	
	void OnGUI()
	{
		if(inputdisplay == true) 
		{	
          	MouseLookcomponent.pausecamera = true;
			MouseLookcomponent2.pausecamera = true;

			GUI.Box(new Rect(600, 10, 400, 150), "How many hours would you like to sleep?");
			stringToEdit = GUI.TextField (new Rect (650, 50, 200, 20), stringToEdit, 25);
			if(GUI.Button(new Rect(600, 80, 80, 70), "Sleep")) 
			{
				inputdisplay = false;
				float.TryParse(stringToEdit, out sleeptime);
				MouseLookcomponent.pausecamera = false;
				MouseLookcomponent2.pausecamera = false;
				if(sleeptime > 24 || sleeptime < 0)
				{
					sleeptime = 0;
				    stringToEdit = "Enter an appropriate time to sleep"; 
					inputdisplay = true;
				}
				else 
				{
					Player.CurrentStamina += sleeptime*15;
					sleeptime = sleeptime * 60;
					time += sleeptime;
					stringToEdit = "";
				}
				
			}
			if(GUI.Button(new Rect(700, 80, 80, 70), " Don't Sleep")) 
			{
				inputdisplay = false;
				stringToEdit = "";
				MouseLookcomponent.pausecamera = false;
				MouseLookcomponent2.pausecamera = false;
			}
		}
	}
}


			/*
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				inputdisplay = false;
				float.TryParse(stringToEdit, out sleeptime);
				stringToEdit = "Sleep?";
				
			}
			*/
