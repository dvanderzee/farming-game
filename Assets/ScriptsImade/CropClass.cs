using UnityEngine;
using System.Collections;

public class CropClass : MonoBehaviour {
	
	public int xSize;
	public int ySize;
	
	public int maxXSize;
	public int maxYSize;
	
	public CropTileClass cropTileClass;
	
	private CropTileClass[,] cropField;

	// Use this for initialization
	void Start () {
		cropField = new CropTileClass[maxXSize,maxYSize];
		
		for( int i = 0; i < xSize; i++){
			for(int j = 0; j< ySize; j++){
				createCropTile(i,j);
			}
		}
	}
	
	public bool canUpgrade() {
		if (this.xSize >= this.maxXSize || this.ySize >= this.maxYSize) {
			return false;	
		}
		else {
			return true	;
		}
	}
	
	public bool canUpgrade(int changeInXSize, int changeInYSize) {
		if (changeInXSize < 0 || changeInYSize < 0) {
			return false;
		}
		
		//Cannot exceed maximum size of field
		if ((this.xSize+changeInXSize) >= this.maxXSize) {
			return false;
		}
		if ((this.ySize+changeInYSize) >= this.maxYSize) {
			return false;
		}
		
		return true;
	}
	
	public void upgradeSize(int changeInXSize, int changeInYSize) {
		if (changeInXSize < 0 || changeInYSize < 0) {
			throw new System.Exception("CAN'T MAKE FIELD SMALLER");	
		}
		
		//Cannot exceed maximum size of field
		if ((this.xSize+changeInXSize) >= this.maxXSize) {
			changeInXSize = this.maxXSize-this.xSize;
		}
		if ((this.ySize+changeInYSize) >= this.maxYSize) {
			changeInYSize = this.maxYSize-this.ySize;
		}
		
		for (int x = this.xSize; x < (this.xSize+changeInXSize); x++) {
			for (int y = this.ySize; y < (this.ySize+changeInYSize); y++) {
				this.createCropTile(x,y);	
			}
		}
		for (int x = this.xSize; x < (this.xSize+changeInXSize); x++) {
			for (int y = 0; y < (this.ySize); y++) {
				this.createCropTile(x,y);	
			}
		}
		for (int x = 0; x < (this.xSize); x++) {
			for (int y = this.ySize; y < (this.ySize+changeInYSize); y++) {
				this.createCropTile(x,y);	
			}
		}
		
		this.xSize += changeInXSize;
		this.ySize += changeInYSize;
	}
	
	void createCropTile(int x, int y) {
		if (cropField[x,y] == null) {
			Vector3 tilePosition = this.transform.position + (this.transform.forward*x*2) - (this.transform.right*y*1);
			Quaternion tileRotation = this.transform.rotation * cropTileClass.transform.rotation;
			cropField[x,y] = (CropTileClass)Instantiate(cropTileClass, tilePosition, tileRotation);
			
			cropField[x,y].transform.parent = this.transform;
		}
	}
	public void RainOnTheCrops() {
		for(int i = 0; i < xSize; i++)
			for( int j = 0; j < ySize; j++) 
				cropField[i,j].watercrop();
				
		
	}
	
	public void randomKilling() {
		for(int i = 0; i < xSize; i++)
			for( int j = 0; j < ySize; j++) 
				cropField[i,j].die();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
