using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
	
	public int months;
	float days;
	float currentDay;
	float hours;
	float currentHour;
	float minutes;
	float sleeptime;
	public Timemanager Timemanagercomponent;
	public GameObject sun;
	public Rain Rainhelper;
	public CropClass field;
	public CropClass newField;
	public Material daysky;
	public Material dawnsky;
	public Material dusksky;
	public Material nightsky;
	
	
	// Use this for initialization
	void Start () 
	{
		sun = GameObject.Find("Sun");
		conversion ();
			
	}
	
	// Update is called once per frame
	void Update (){
		conversion();
		//OnGUI();
	}
			
	void conversion () 
	{
		currentDay = days;
		currentHour = hours;
		months = (int)Timemanagercomponent.howmanymonthstotal();
		days = (int)Timemanagercomponent.howmanydaystotal() - (months*10.0f);
		hours = (int)Timemanagercomponent.howmanyhourstotal() - (days*24.0f);
		minutes = (int)Timemanagercomponent.howmanyminutestotal() - (hours*60.0f) - (days*1440);
		
		sleeptime = (int)Timemanagercomponent.howmuchsleep();
		
		if(days > currentDay)
		{
			Rainhelper.ShouldItRain();
			field.randomKilling();
			newField.randomKilling();
			
		}
		
		if(hours > currentHour)
			skyChange();
		
	}
	
	void skyChange()
	{
		if(hours >= 0 && hours < 2)
			sun.light.intensity = 0F; 
		else if(hours >= 2 && hours < 4)
			sun.light.intensity = .4F; 
		else if(hours >= 4 && hours < 6)
			sun.light.intensity = .8F;		
		else if(hours >= 6 && hours < 8)
			sun.light.intensity = 1.2F; 
		else if(hours >= 8 && hours < 10)
			sun.light.intensity = 1.6F; 
		else if(hours >= 10 && hours < 12)
			sun.light.intensity = 2.0F; 
		else if(hours >= 12 && hours < 14)
			sun.light.intensity = 1.6F; 
		else if(hours >= 14 && hours < 16)
			sun.light.intensity = 1.2F; 
		else if(hours >= 16 && hours < 18)
			sun.light.intensity = .8F; 
		else if(hours >= 18 && hours < 20) 
			sun.light.intensity = .4F; 
		else if(hours >= 20 && hours < 22)
			sun.light.intensity = .2F; 
		else if(hours >= 22 && hours < 24)
			sun.light.intensity = 0F;
		
		if(hours >= 5 && hours < 12)
			RenderSettings.skybox = dawnsky;
		if(hours >= 12 && hours < 17)
			RenderSettings.skybox = daysky;
		if(hours >= 17 && hours < 20)
			RenderSettings.skybox = dusksky;
		if(hours >= 20 && hours < 24)
			RenderSettings.skybox = nightsky;
	}
	
	/*void sleep(string howlong) 
	{
		float.TryParse(howlong, out sleeptime);
	}*/
	
	void OnGUI()
	{	
		GUI.Box (new Rect(0,0, 60, 140), "");
		switch (months)
		{
		case 0:
				GUI.Label(new Rect(10, 10, 50, 50), ("Spring"));
				break;
		case 1:
				GUI.Label(new Rect(10, 10, 50, 50), ("Summer"));
				break;
		case 2:
				GUI.Label(new Rect(10, 10, 50, 50), ("Fall" ));
				break;
		case 3:
				GUI.Label(new Rect(10, 10, 50, 50), ("Winter"));
				break;
		default:
				Debug.Log ("Somehow got to a month that doesn't exist");
				break;
			
					
		}
		
		GUI.Label(new Rect(10, 60, 50, 100), ("Day " + (days+1).ToString()));
		GUI.Label(new Rect(10, 110, 50, 150), (hours.ToString() + " : " + minutes.ToString()));
	
		//GUI.Label(new Rect(10,10,50,50), (Timemanagercomponent.howmanyminutestotal()).ToString());
	}
	
	
}