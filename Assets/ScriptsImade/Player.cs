using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float Interactdistance;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1)) {
			RaycastHit hitinfo;
			if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
				CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
				if (CropTileComponent != null) {
					CropTileComponent.plantseed ();
				}	
			}
		}
		
		if (Input.GetKeyDown (KeyCode.Alpha2)|| Input.GetKeyDown (KeyCode.Keypad2)) {
			RaycastHit hitinfo;
			if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
				CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
				if (CropTileComponent != null) {
					CropTileComponent.watercrop();
				}	
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)|| Input.GetKeyDown (KeyCode.Keypad3)) {
			RaycastHit hitinfo;
			if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
				CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
				if (CropTileComponent != null) {
					CropTileComponent.harvestcrop();
				}	
			}
		}		
		
		if (Input.GetKeyDown (KeyCode.Alpha4)|| Input.GetKeyDown (KeyCode.Keypad4)) {
			RaycastHit hitinfo;
			if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
				CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
				if (CropTileComponent != null) {
					CropTileComponent.tillcrop();
				}	
			}
		}
		
	/*
		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log("Frame Updated");
			RaycastHit hitinfo;
			if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
				//Debug.Log(hitinfo.collider.gameObject);
				//Debug.Log("Hit sometrhing");
				CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
				//Debug.Log(CropTileComponent);
				//Debug.DrawLine(this.transform.position, hitinfo.point, Color.red, 0.5f);
				if (CropTileComponent != null) {
					CropTileComponent.plantseed ();
				}
				
					
			}
		}*/
	}
					
			
	
}
