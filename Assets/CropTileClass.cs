using UnityEngine;
using System.Collections;

public class CropTileClass : MonoBehaviour {
	
	int Cropstage = 0; //0 is no crop. 1 is seed planted. 2 is watered. 3 is harvestable. 4 is tillable
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void plantseed() {
		//Debug.Log("HELLO WORLD");	
		this.transform.gameObject.GetComponent<Renderer>().material.color = new Color (Color.green);//(Random.Range (0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range (0f,1f));
		Cropstage = 1;
	}
	
	public void watercrop () {
		this.transform.gameObject.GetComponent<Renderer>().material.color = new Color (Color.blue);
		Cropstage = 2;
		
		//You water multiple times until
		//Cropstage = 3;
		
	}
	
	public void harvestcrop () {
		this.transform.gameObject.GetComponent<Renderer>().material.color = new Color (Color.red);
		Cropstage = 4;
		
	}
	
	public void tillcrop () {
		this.transform.gameObject.GetComponent<Renderer>().material.color = new Color (153,128,0);
		Cropstage = 0;
}
