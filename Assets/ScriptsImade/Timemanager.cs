using UnityEngine;
using System.Collections;

public class Timemanager : MonoBehaviour {
	/* There are 60 minutes in an hour, 24 hours in a day, 10 days in a month, 4 months in a year. */
	
	float minutes; // in game minutes
	float time; //main variable
	float hours; // in game hours
	float days; // in game days
	float months; // in game months

	
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		time = Time.timeSinceLevelLoad; //time is how many in game minutes have passed
		
	}
		
	public float howmanyminutestotal () 
	{
		minutes = time;
		return minutes;
	}
	
	public float howmanyhourstotal () 
	{
		hours  = time % 60;
		return hours;
	}
	
	public float howmanymonthstotal () 
	{
		months = time % 14400;
		return months;
	}
	
	public float howmanydaystotal () 
	{
		days = time % 1440;
		return days;
	}	
}
