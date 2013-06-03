using UnityEngine;
using System.Collections;

public class CropTileClass : MonoBehaviour
{
	
	int Cropstage = 0; //0 is no crop. 1 is seed planted. 2 is watered. 3 is harvestable. 4 is tillable
	float timeLastWatered;
	int timesWatered = 0;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void plantseed ()
	{
		//Debug.Log("HELLO WORLD");	
		if (Cropstage == 0) {
		
			this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.green);//(Random.Range (0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range (0f,1f));
			Cropstage = 1;
		}
	}
	//IEnumerator flashBlack(){	}
	public void watercrop ()
	{
		if (Cropstage == 1) {
			this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.blue);
			Cropstage = 2;
			timeLastWatered = Time.time;
			timesWatered++;
		} else if (Cropstage == 2 && (Time.time - timeLastWatered) > 5) {
			this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.black);
			//yield return new WaitForSeconds(5.0f);
			this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.blue);
			timeLastWatered = Time.time;
			timesWatered++;
			if (timesWatered == 3) {
				this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.red);
				Cropstage = 3;
				timesWatered = 0;
				
			}			
			
		}
		
		//You water multiple times until
		//Cropstage = 3;
		
	}
	
	public void harvestcrop ()
	{
		if (Cropstage == 3) {
			this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.black);
			Cropstage = 4;
		}
		
	}
	
	public void tillcrop ()
	{
		if (Cropstage == 4) {
			this.transform.gameObject.GetComponent<Renderer> ().material.color = new Color (153, 128, 0);
			Cropstage = 0;
		}
	}
}
