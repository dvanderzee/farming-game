using UnityEngine;
using System.Collections;

public class FlowerManager : MonoBehaviour {
	
	public float TimePicked;
	public bool FlowerIsGone = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(FlowerIsGone == true) {
			if((Timemanager.time - TimePicked) > 1080) {
				renderer.enabled = true;
				this.collider.enabled = true;
				FlowerIsGone = false;
				TimePicked = 0;
			}
		}
		
	}
	
	public  void DestroyFlower () {
		//i need to add an if to player class
		renderer.enabled = false;
		this.collider.enabled = false;
		TimePicked = Timemanager.time;
		FlowerIsGone = true;
		
		
		//Debug.Log("Worked");
		
	}
	

}