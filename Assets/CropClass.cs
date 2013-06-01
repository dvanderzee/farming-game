using UnityEngine;
using System.Collections;

public class CropClass : MonoBehaviour {
	
	public int xSize;
	public int ySize;
	
	public CropTileClass cropTileClass;
	
	private CropTileClass[,] cropField;

	// Use this for initialization
	void Start () {
		cropField = new CropTileClass[xSize,ySize];
		
		for( int i = 0; i < xSize; i++){
			for(int j = 0; j< ySize; j++){
				Vector3 tilePosition = new Vector3(this.transform.position.x+i, this.transform.position.y, this.transform.position.z+j);
				
				cropField[i,j] = (CropTileClass)Instantiate(cropTileClass, tilePosition, Quaternion.identity);
			}
		}
				
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
