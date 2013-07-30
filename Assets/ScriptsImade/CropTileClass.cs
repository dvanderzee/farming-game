using UnityEngine;
using System.Collections;

public class CropTileClass : MonoBehaviour
{
	public Mesh dirtMesh;
	public Avatar dirtAvatar;
	public Material dirtMaterial;
	public Mesh tilledMesh;
	public Avatar tilledAvatar;
	public Material tilledMaterial;
	public Mesh wetdirtMesh; //variable for wet dirt mesh and its avatar
	public Avatar wetdirtavatar;
	public Material wetdirtMaterial;
	public Mesh wettilled; //variable for wet tiled mesh and its avatar
	public Avatar wettilledavatar; 
	public Material wettilledMaterial;
	public int howmanywater; // how many times the specific crop needs to be watered
	public string cropname;
	
	//public GameObject Inventorycomponent;
	
	int Cropstage = 0; //0 is untilled. 1 is tilled. 2 is planted. 3 is watered. 4 is harvestable
	float timeLastWatered = 0;
	public int timesWatered = 999;
	int badwater = 0; //how many times you incorrectly watered the plant
	int growthstage = 0; //stage to show what model needs to be represented. 0 is nothing.
	bool canbewatered; //bool if the crop can be watered
	public Rain DatRainHelper;  //used to see if its raining in order to water
	
	
	
	// Use this for initialization
	void Start ()
	{
		/*
		var c = GameObject("Crop");
		Vector3 turn = c.Collider.bounds.center;
		c.RotateAround(turn);	
		*/
		
		
		this.DatRainHelper = (Rain)Object.FindObjectOfType(typeof(Rain));
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		
		// THIS KILLS A PLANT IF YOU DON'T WATER IT OFTEN ENOUGH
		if (Cropstage == 3 && (Timemanager.time - timeLastWatered) > 2880) { //Change the color and model back to dirt and black
			this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.black);
			MeshFilter mesh = this.GetComponent<MeshFilter>();
			mesh.mesh = this.dirtMesh;	
			this.renderer.material = this.dirtMaterial;
			Animator animate = this.GetComponent<Animator>();
			animate.avatar = this.dirtAvatar;
			
			
			Cropstage = 0; //resets crop
			growthstage = 0;
			timesWatered =999;
			badwater = 0;
		}
		// IF CROPS ARE READY TO BE WATERED AGAIN, IT CHANGES TO DRY TILLED MODEL
		
		if (Cropstage == 3 && (Timemanager.time - timeLastWatered) > 720) 
		{ 
			MeshFilter mesh = this.GetComponent<MeshFilter>();
			mesh.mesh = this.tilledMesh;
			this.renderer.material = this.tilledMaterial;
			Animator animate = this.GetComponent<Animator>();
			animate.avatar = this.tilledAvatar;
			canbewatered = true; //ready to be watered
			if(DatRainHelper.ItsRaining == true) //checks to see if its raining, so that the crop is watered for the second half of the day
				watercrop();
			//this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.gray);
			
			
		}
		
		
		// IF YOU WATER CORRECTLY ENOUGH THE PLANT WILL GROW
		if (timesWatered ==  howmanywater && (Timemanager.time - timeLastWatered) > 720) 
		{ 
			this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.red);
			growthstage = 4; //model should change to harvestable model
			Cropstage = 4;
			badwater = 0;
			timesWatered = 999;
			//Change model to dry
			MeshFilter othermesh = this.GetComponent<MeshFilter>();
			othermesh.mesh = this.tilledMesh;
			this.renderer.material = this.tilledMaterial;
			Animator otheranimate = this.GetComponent<Animator>();
			otheranimate.avatar = this.tilledAvatar;
					
				
		}		
		
		
		
	}
	
	public bool plantseed (int numberofwaters, string acropname)
	{
		if (Cropstage == 1 ) {
		
			//this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.green);//(Random.Range (0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range (0f,1f));
			Cropstage = 2;
			howmanywater = numberofwaters;
			cropname = acropname;
			growthstage = 1; //seed model should appear
			return true;
		}
		else
		{
			return false;
		}
	}
	
	public void watercrop ()
		{
		// IF WATERING FOR THE FIRST TIME
		if (Cropstage == 2) 
		{	//this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.blue);
			Cropstage = 3;
			timeLastWatered = Timemanager.time;
			timesWatered = 1;
			canbewatered = false; //now watered. dont water again
			
			//Change model to wet
			MeshFilter mesh = this.GetComponent<MeshFilter>();
			mesh.mesh = this.wettilled;
			this.renderer.material = this.wettilledMaterial;
			Animator animate = this.GetComponent<Animator>();
			animate.avatar = this.wettilledavatar;
		
			
		} // IF YOU WATER CORRECTLY
		else if (canbewatered == true) //Plants can be watered every 12 hours
		{ 
			//this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.blue);
			timeLastWatered = Timemanager.time;
			timesWatered++;
			if(timesWatered >= (howmanywater/2))
				growthstage = 2; //model changes to small leaves. halfway done
			else if( timesWatered >= (howmanywater * .7))
				growthstage = 3; //model changes to big leaves. 3/4 done
			
			//Change model to wet
			MeshFilter mesh = this.GetComponent<MeshFilter>();
			mesh.mesh = this.wettilled;
			this.renderer.material = this.wettilledMaterial;
			Animator animate = this.GetComponent<Animator>();
			animate.avatar = this.wettilledavatar;
		
			
			
			
		}	
			 //IF YOU WATER A PLANT TOO MANY TIMES. IT DIES
		else if(Cropstage ==3)
		{
			badwater++;
			if(badwater > 4){
				this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.black);
				MeshFilter mesh = this.GetComponent<MeshFilter>();
				mesh.mesh = this.dirtMesh;
				this.renderer.material = this.dirtMaterial;
				Animator animate = this.GetComponent<Animator>();
				animate.avatar = this.dirtAvatar;
				growthstage = 0;
				Cropstage = 0;
				timesWatered =999;
				badwater = 0;
			}
		}
		//YOURE WATERING NOT SOILED DIRT. YOURE PROBABLY STUPID
		else {
			MeshFilter mesh = this.GetComponent<MeshFilter>();
			mesh.mesh = this.wetdirtMesh;
			this.renderer.material = this.wetdirtMaterial;
			Animator animate = this.GetComponent<Animator>();
			animate.avatar = this.wetdirtavatar;
		}
	}
	
		
	
	
	public void harvestcrop ()
	{
		if (Cropstage == 4) {
			this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.black);
			Cropstage = 0;
			growthstage = 0;
			MeshFilter mesh = this.GetComponent<MeshFilter>();
			mesh.mesh = this.dirtMesh;
			this.renderer.material = this.dirtMaterial;
			Animator animate = this.GetComponent<Animator>();
			animate.avatar = this.dirtAvatar;
			//code that adds crop to your inventory
		}
		
	}
	
	public void tillcrop ()
	{
		if (Cropstage == 0) {
			//this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.white);//new Color (153, 128, 0);
			MeshFilter mesh = this.GetComponent<MeshFilter>();
			mesh.mesh = this.tilledMesh;
			this.renderer.material = this.tilledMaterial;
			Animator animate = this.GetComponent<Animator>();
			animate.avatar = this.tilledAvatar;
			Cropstage = 1;
		}
	}
	public void die ()
	{
		int death = Random.Range (1,7);
		if(Cropstage == 3 && death == 1)
		{
			this.transform.gameObject.GetComponent<Renderer> ().material.color = (Color.black);
			MeshFilter mesh = this.GetComponent<MeshFilter>();
			mesh.mesh = this.dirtMesh;
			this.renderer.material = this.dirtMaterial;
			Animator animate = this.GetComponent<Animator>();
			animate.avatar = this.dirtAvatar;
			growthstage = 0;
			Cropstage = 0;
			timesWatered =999;
			badwater = 0;
		}
	}
			
}
