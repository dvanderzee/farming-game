using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour 
{	
	float lifeTimer;
	bool isALive;

	void Start () 
	{
		lifeTimer = Timemanager.time;	// Recorded moment of when the egg is brought into existence
		isALive = true;					// Whether egg has not disappeared yet.
	}
	
	void Update () 
	{
		if((Timemanager.time - lifeTimer) > 2880)	// If egg has been alive for two days, it will die
		{
			isALive = false;
			destroyegg();
		}	
	}
	
	public void destroyegg()	// Function to destroy specific instance of egg
	{
		renderer.enabled = false;
		this.collider.enabled = false;
	}
}
