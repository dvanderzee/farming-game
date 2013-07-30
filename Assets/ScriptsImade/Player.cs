using UnityEngine;
using System.Collections;
using System.Text;

public class Player : MonoBehaviour
{
	public float Interactdistance;
	public static float MaxStamina = 100;
	public static float CurrentStamina = 100;
	public bool regen = false;
	public float regentimer = 0;
	public float startRegen = 0;
	public static bool selling = false;
	public static bool crosshair = true;
	
	public Texture crosshairsTexture;
	// Use this for initialization
	void Start ()
	{
		this.updateVisibleTool();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		// Health Regeneration Calculation
		startRegen += Time.deltaTime;
		if(startRegen > 5)
			regen = true;
		if(regen == true)
		{
			regentimer += Time.deltaTime;
			if(regentimer > 5) 
			{
				regentimer = 0;
				CurrentStamina += 1;
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Tab))
			selling = true;
		
		if(CurrentStamina > MaxStamina)
			CurrentStamina = MaxStamina;
		
		if(selling == false) 
		{
		if(Input.GetMouseButtonDown(0)) {
			     RaycastHit hit;
		
			if (InventoryManager.equippeditem().Equals("Tomato Seed")) {
				var t_seeds = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Tomato Seed");
				if(CurrentStamina >= t_seeds.cost) {
					RaycastHit hitinfo;
					if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
						CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
						if (CropTileComponent != null) {
							if(CropTileComponent.plantseed (t_seeds.howmuchtowater, "Tomato"))
							{
								if(t_seeds.minustool() == false) {
									InventoryManager.removetool();
								}
								CurrentStamina -= t_seeds.cost;
								regen = false;
								regentimer = 0;
								startRegen = 0;
							}
						}	
					}
				}
			}
			
			else if (InventoryManager.equippeditem().Equals("Corn Seed")) {
				var c_seeds = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Corn Seed");
				if(CurrentStamina >= c_seeds.cost) {
					RaycastHit hitinfo;
					if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
						CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
						if (CropTileComponent != null) {
							if(CropTileComponent.plantseed (c_seeds.howmuchtowater, "Corn"))
							{
								if(c_seeds.minustool() == false) {
									InventoryManager.removetool();
								}
								CurrentStamina -= c_seeds.cost;
								regen = false;
								regentimer = 0;
								startRegen = 0;
							}
						}	
					}
				}
			}
			
			else if (InventoryManager.equippeditem().Equals("Waterbucket")) {
				var waterbucket = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Waterbucket");
				if(CurrentStamina >= waterbucket.cost) {
					RaycastHit hitinfo;
					if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
						CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
						if (CropTileComponent != null) {
							CropTileComponent.watercrop();
							CurrentStamina -= waterbucket.cost;
							regen = false;
							regentimer = 0;
							startRegen = 0;
							
						}	
					}
				}
			}
				
			else if (InventoryManager.equippeditem().Equals("Waterbucket Lvl 2")) {
				var waterbucket2 = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Waterbucket Lvl 2");
				if(CurrentStamina >= waterbucket2.cost) {
					RaycastHit hitinfo;
					if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
						CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
						if (CropTileComponent != null) {
							CropTileComponent.watercrop();
							CurrentStamina -= waterbucket2.cost;
							regen = false;
							regentimer = 0;
							startRegen = 0;
							
						}	
					}
				}
			}
			
					
			else if (InventoryManager.equippeditem().Equals("Hoe")) {
				var hoe = InventoryManager.Inventory.Find(Toolmanager => Toolmanager.Tooltype == "Hoe");
				if(CurrentStamina >= hoe.cost) {
					RaycastHit hitinfo;
					if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
						CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
						if (CropTileComponent != null) {
							CropTileComponent.tillcrop();
							CurrentStamina -= hoe.cost;
							regen = false;
							regentimer = 0;
							startRegen = 0;
						}	
					}
				}
			}
				
			else if (InventoryManager.equippeditem().Equals("Hoe Lvl 2")) {
				var hoe2 = InventoryManager.Inventory.Find(Toolmanager => Toolmanager.Tooltype == "Hoe Lvl 2");
				if(CurrentStamina >= hoe2.cost) {
					RaycastHit hitinfo;
					if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
						CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
						if (CropTileComponent != null) {
							CropTileComponent.tillcrop();
							CurrentStamina -= hoe2.cost;
							regen = false;
							regentimer = 0;
							startRegen = 0;
						}	
					}
				}
			}
			else if (InventoryManager.equippeditem().Equals("Hands")) 
			{
				RaycastHit hitinfo; //TO HARVEST CROPS
				if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Crops"))) {
					CropTileClass CropTileComponent = (CropTileClass)hitinfo.collider.gameObject.GetComponent ("CropTileClass");
					if (CropTileComponent != null) {
						CropTileComponent.harvestcrop();
						var takecrop = InventoryManager.Inventory.Find(Toolmanager => Toolmanager.Tooltype == CropTileComponent.cropname);
						//if(InventoryManager.Inventory.Find(Toolmanager => (Toolmanager.Tooltype == CropTileComponent.cropname)) != new Toolmanager("0", 0, 0, 0, 0))
							Debug.Log("inside if statement");
							takecrop.addtool();
							Debug.Log(takecrop.Tooltype);
						
					}
				} //TO PICK UP FLOWERS	
				else if(Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Flowers"))) {
					var flower = InventoryManager.Inventory.Find (Toolmanager => (Toolmanager.Tooltype == "Flower"));
					flower.addtool();
					FlowerManager myFlower = (FlowerManager)hitinfo.collider.gameObject.GetComponent ("FlowerManager");
					myFlower.DestroyFlower ();
				}
				
				else if(Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Egg"))) {
					Egg pickedEgg = (Egg)hitinfo.collider.gameObject.GetComponent("Egg");
					pickedEgg.destroyegg();
					var egg = InventoryManager.Inventory.Find (Toolmanager => (Toolmanager.Tooltype =="Egg"));
					egg.addtool();
					//InventoryManager.Inventory.Add(new Toolmanager("Egg", 0, 0, 1, 0));
				}
					
					
			}
			else if (InventoryManager.equippeditem().Equals("Tomato")) {
				var tomato = InventoryManager.Inventory.Find(Toolmanager => Toolmanager.Tooltype == "Tomato");
				tomato.minustool();
				Debug.Log("EATING A TOMATO");
				CurrentStamina += 50;
			}
			
			else if (InventoryManager.equippeditem().Equals ("Feed")) {
				RaycastHit hitinfo;
				var feed = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Feed");
				if (Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Chicken"))) {
					Debug.Log("Hit chicken");
					Chicken chickenComponent = (Chicken)hitinfo.collider.gameObject.GetComponent("Chicken");
					chickenComponent.feed();
					if(feed.minustool() == false) {
						InventoryManager.removetool();
					}					
				}
				else if(Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Cow"))) {
					Debug.Log("Hit Cow");
					Cow cowComponent = (Cow)hitinfo.collider.gameObject.GetComponent("Cow");
					cowComponent.feed();
					if(feed.minustool() == false) {
						InventoryManager.removetool();
					}
				}
			}
			
			if(InventoryManager.equippeditem().Equals("Milker")) {
				RaycastHit hitinfo;
				if(Physics.Raycast (this.transform.position, this.transform.forward, out hitinfo, this.Interactdistance, 1 << LayerMask.NameToLayer ("Cow"))) {
					Cow cowComponent = (Cow)hitinfo.collider.gameObject.GetComponent("Cow");
					int milkNum = cowComponent.milk();
					var milk = InventoryManager.Inventory.Find (Toolmanager => (Toolmanager.Tooltype =="Milk"));
					while(milkNum > 0)
					{
						milk.addtool ();
						milkNum--;
					}
				}
			}
		}
		
		if (Input.GetKeyDown(KeyCode.RightArrow)) {//cycle through inventory
			InventoryManager.equipnextitem();
			this.updateVisibleTool();
			
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			InventoryManager.equippreviousitem();
			this.updateVisibleTool();
			
		}
		
		}
		
	}
	
	//Disables and enables renderers of tools
	//NOTE: Depends on tools being children to active camera
	public void updateVisibleTool() {
		
		foreach (Transform childOfCamera in Camera.mainCamera.transform) {
			if (childOfCamera.gameObject.name.Equals(InventoryManager.equippeditem())) {
//				MeshRenderer[] childrenRenderers = child.GetComponentsInChildren<MeshRenderer>();
//				foreach (MeshRenderer renderer in childrenRenderers) {
//					renderer.enabled = true;	
//				}
				childOfCamera.gameObject.SetActive(true);
			}
			else {
				childOfCamera.gameObject.SetActive(false);	
			}
		}
		
		
	}
	
	void OnGUI() 
		{
			GUI.Box(new Rect(1200, 10, 100, 100), "Stamina");
			GUI.Label(new Rect(1200, 50, 100, 100), (CurrentStamina + " / " + MaxStamina));
			//GUI.Box(new Rect(/**/),crosshairsTexture);
			float xMin = (Screen.width / 2) - (crosshairsTexture.width / 8) /2;
			float yMin = (Screen.height / 2) - (crosshairsTexture.height / 8) /2;
			if(selling == false)
				GUI.DrawTexture(new Rect(xMin, yMin, crosshairsTexture.width / 8 , crosshairsTexture.height / 8), crosshairsTexture);
		
		
		}
}
