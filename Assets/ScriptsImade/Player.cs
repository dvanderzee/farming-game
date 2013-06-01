using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float Interactdistance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	if( Input.GetMouseButtonDown(0)){
			Debug.Log("Frame Updated");
			RaycastHit hitinfo;
			if(Physics.Raycast(this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1<<LayerMask.NameToLayer("Crops"))){
				//Debug.Log(hitinfo.collider.gameObject);
				Debug.Log("Hit sometrhing");
				CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent("CropTileClass");
				Debug.Log(CropTileComponent);
				Debug.DrawLine(this.transform.position, hitinfo.point, Color.red, 0.5f);
				if(CropTileComponent != null){
					CropTileComponent.plant();
				}
				
			}
		}
	}
					
			
	
}
