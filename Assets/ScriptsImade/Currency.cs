using UnityEngine;
using System.Collections;

public class Currency : MonoBehaviour
{
	
	int money; //player's money
	bool marketdisplay = false;
	bool buy = false;
	bool sell = false;
	
	public CropClass Cropclasscomponent;
	public CropClass NewField;
	
	public MouseLook MouseLookcomponent;
	public MouseLook MouseLookcomponent2;
	
	// Use this for initialization
	void Start ()
	{
	
		money = 1000;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetKeyDown (KeyCode.Tab)) {
			marketdisplay = true;
		}
		
		
	}
	
	public bool spend (int cost)
	{ // function used to purchase items. Checks to see if you have enough money. 
		//Subtracts money if true, returns false if insufficent funds.
		
		if (money >= cost) {
			money -= cost;
			return true;
		} else {
			return false;
		}
	}
	
	public void addmoney (int newmoney)
	{ //function used to add money. Used when you sell an item
		
		money += newmoney;
	}
	
	void OnGUI ()
	{
		GUI.Box (new Rect (1090, 10, 60, 60), "Money");
		
		GUI.Label (new Rect (1100, 35, 120, 100), ("$ " + money));
	
		if (marketdisplay == true) {
			
			MouseLookcomponent.pausecamera = true;
			MouseLookcomponent2.pausecamera = true;
			
			GUI.Box (new Rect (430, 100, 700, 400), "What would you like to do?");
			
			if(GUI.Button (new Rect(460, 120, 200, 70), "Buy"))
			{
				sell = false;
				buy = true;
			}
			if(GUI.Button (new Rect(670, 120, 200, 70), "Sell"))
			{
				buy = false;
				sell = true;
			}
			
			if (GUI.Button (new Rect (880, 120, 200, 70), "Exit")) {
				marketdisplay = false;
				Player.selling = false;
				MouseLookcomponent.pausecamera = false;
				MouseLookcomponent2.pausecamera = false;
			}
			
			if(buy == true)
			{
				if (GUI.Button (new Rect (460, 200, 200, 70), "Tomato Seeds ($50)")) {
					if (spend (50)) {	
						//if (InventoryManager.Inventory.Contains (InventoryManager.T_Seeds)) {
						var T_seeds = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Tomato Seed");
						T_seeds.addtool ();
						Debug.Log ("Yayy");
						//}
						//else
						//InventoryManager.Inventory.Add (InventoryManager.T_Seeds);
					}
				}
				
				if (InventoryManager.Inventory.Contains (InventoryManager.Tomato)) {
					if (GUI.Button (new Rect (670, 200,200, 70), "Tomato ($100)")) {
						if (spend (100)) {
							//if (InventoryManager.Inventory.Contains (InventoryManager.Tomato)) {
							var tomato = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Tomato");
							tomato.addtool ();
							Debug.Log ("Yayy");
							//}
						}
						//else
						//InventoryManager.Inventory.Add (InventoryManager.Tomato);				
					}
				}
				
				if (GUI.Button (new Rect (880, 200, 200, 70), "Corn Seeds ($30)")) {
					if (spend (30)) {	
						//if (InventoryManager.Inventory.Contains (InventoryManager.C_Seeds)) {
						var C_seeds = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Corn Seed");
						C_seeds.addtool ();
						
						//	}
						//else
						//	InventoryManager.Inventory.Add (InventoryManager.C_Seeds);
					}
				}
				
				if(GUI.Button(new Rect (460, 280, 200, 70), "Land($100)")) {
					if(spend (100)) {
						if(Cropclasscomponent.canUpgrade(3,3) == true)
							Cropclasscomponent.upgradeSize(3,3);
					}
				}
				
				if(GUI.Button(new Rect(670, 280, 200, 70), "Hoe Lvl 2($300)")) {
					if(spend (300)) {
						var hoe2 = InventoryManager.Inventory.Find(Toolmanager => Toolmanager.Tooltype == "Hoe Lvl 2");
						hoe2.addtool();
					}
				}
				
				if(GUI.Button(new Rect(880, 280, 200, 70), "Waterbucket Lvl 2($300)")) {
					if(spend (300)) {
						var bucket2 = InventoryManager.Inventory.Find(Toolmanager => Toolmanager.Tooltype == "Waterbucket Lvl 2");
						bucket2.addtool();
					}
				}
				
				if(GUI.Button (new Rect(460, 360, 200, 70), "New Field($200")) {
					if(spend (200)) {
						if(NewField.canUpgrade(3,3) == true)
							NewField.upgradeSize(3,3);
					}
				}
				
				if(GUI.Button (new Rect(670, 360, 200, 70), "Chicken($200)")) {
					if(spend (200)) {
						var chick = GameObject.Find ("Chicken");
						Instantiate(chick, chick.transform.position, chick.transform.rotation);
					}
				}
				
			}
			
			if(sell == true)
			{
				if (GUI.Button (new Rect (460, 200, 200, 70), "Tomato Seeds ($30)")) {
					if (InventoryManager.Inventory.Contains (InventoryManager.T_Seeds)) {
						var T_seeds = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Tomato Seed");
						if (T_seeds.minustool () == true)
							addmoney (30);
					}
				}
				
				
				if (InventoryManager.Inventory.Contains (InventoryManager.Tomato)) {
					if (GUI.Button (new Rect (670, 200, 200, 70), "Tomato ($100)")) {
	
						var tomato = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Tomato");
						if (tomato.minustool () == true)
							addmoney (100);
					}
				}
				if (InventoryManager.Inventory.Contains (InventoryManager.Hoe)) {
					if (GUI.Button (new Rect (880, 200, 200, 70), "Hoe ($300)")) {
						var hoe = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Hoe");
						
						if (hoe.Tooltype == "Hoe" && hoe.minustool () == true)
							addmoney (300);
							
					
					}
					
				}
				if (InventoryManager.Inventory.Contains (InventoryManager.Waterbucket)) {
					if (GUI.Button (new Rect (460, 280, 200, 70), "Bucket ($300)")) {
						var bucket = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Waterbucket");
						if (bucket.minustool () == true)
							addmoney (300);
					
					}
				}
				if (InventoryManager.Inventory.Contains (InventoryManager.Corn)) {
					if (GUI.Button (new Rect (670, 280, 200, 70), "Corn ($150)")) {
						var corn = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Corn");
						if (corn.minustool () == true)
							addmoney (150);
					
					}
				}
				if (InventoryManager.Inventory.Contains (InventoryManager.Flower)) {
					if (GUI.Button (new Rect (880, 280, 200, 70), "Flower ($10)")) {
						var flower = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Flower");
						if (flower.minustool () == true)
							addmoney (10);
					
					}
				}
				if (InventoryManager.Inventory.Contains (InventoryManager.Egg)) {
					if (GUI.Button (new Rect (460, 360, 200, 70), "Egg ($10)")) {
						var egg = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Egg");
						if (egg.minustool () == true)
							addmoney (10);
					
					}
				}
				if (InventoryManager.Inventory.Contains (InventoryManager.Milk)) {
					if(GUI.Button (new Rect ( 670, 360, 200, 70), "Milk ($15)")) {
						var milk = InventoryManager.Inventory.Find (Toolmanager => Toolmanager.Tooltype == "Milk");
						if (milk.minustool () == true)
							addmoney (15);
					}
				}
			}
		}
	}
}
