using UnityEngine;
using System.Collections;

public class Rain : MonoBehaviour {

	public CropClass Cropclasshelper;
	public CropClass OtherCropclasshelper;
	public bool ItsRaining = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void ShouldItRain () {
		int chance = Random.Range(1, 10);
		if(chance <= 3)
			MakeItRain(true);
		else
			MakeItRain(false);
		
		
	}
	void MakeItRain (bool shouldRain) {
			
		if(shouldRain == true) {
			particleEmitter.emit = true;
			Cropclasshelper.RainOnTheCrops();
			OtherCropclasshelper.RainOnTheCrops();
			ItsRaining = true;
			
		}
		else {
			particleEmitter.emit = false;
			ItsRaining = false;
		}
		
		
	}
	
	
	
	
}
