using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	static int equipped {get;set;}
	public static List<Toolmanager> Inventory;
	public static Toolmanager Waterbucket = new Toolmanager("Waterbucket", 1, 6, 1, 0);
	public static Toolmanager Tomato = new Toolmanager ("Tomato",0,0,1, 0);
	public static Toolmanager T_Seeds = new Toolmanager ("Tomato Seed",1,3,3, 6);
	public static Toolmanager Hoe = new Toolmanager ("Hoe", 1, 10,1, 0);
	public static Toolmanager Hands = new Toolmanager("Hands", 1, 0, 1, 0);
	public static Toolmanager Flower = new Toolmanager("Flower",1,0,0, 0);
	public static Toolmanager C_Seeds = new Toolmanager ("Corn Seed", 1, 3, 3, 4);
	public static Toolmanager Corn = new Toolmanager ("Corn", 0, 0, 0, 0);
	public static Toolmanager Feed = new Toolmanager("Feed", 1, 0, 5, 0);
	public static Toolmanager Egg = new Toolmanager("Egg", 0, 0, 0, 0);
	public static Toolmanager Waterbucket2 = new Toolmanager("Waterbucket Lvl 2", 2, 5, 0, 0);
	public static Toolmanager Hoe2 = new Toolmanager("Hoe Lvl 2", 2, 8, 0, 0);
	public static Toolmanager Milker = new Toolmanager("Milker", 0, 0, 1, 0);
	public static Toolmanager Milk = new Toolmanager("Milk", 0, 0, 0, 0);
	
	// Use this for initialization
	void Start () {
		equipped = 0;
		Inventory = new List<Toolmanager> (100);
		Inventory.Add (Waterbucket);
		Inventory.Add (Tomato);
		Inventory.Add (T_Seeds);
		Inventory.Add (Hoe);
		Inventory.Add (Hands);
		Inventory.Add (Flower);
		Inventory.Add (C_Seeds);
		Inventory.Add (Feed);
		Inventory.Add (Corn);
		Inventory.Add (Egg);
		Inventory.Add (Waterbucket2);
		Inventory.Add (Hoe2);	
		Inventory.Add (Milker);
		Inventory.Add (Milk);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public static void equipnextitem () {
		if(equipped < (Inventory.Count - 1))
		{
			equipped++;
			if(Inventory[equipped].howmany == 0)
			{
				equipnextitem();
			}
		}
		else 
		{
			equipped = 0;
			if(Inventory[equipped].howmany == 0)
			{
				equipnextitem();
			}
		}
	}
	
	public static void equippreviousitem () {
		if(equipped > 0)
		{
			equipped--;
			if(Inventory[equipped].howmany == 0)
			{
				equippreviousitem();
			}
		}
		else 
		{
			equipped = (Inventory.Count - 1);
			if(Inventory[equipped].howmany == 0)
			{
				equippreviousitem();
			}
		}
	}
	
	public static string equippeditem () {
		return Inventory[equipped].Tooltype;
	}
	
	public static void removetool() {
		//Inventory.RemoveAll(Toolmanager => Toolmanager.howmany == 0);
		equipnextitem();
	}
	
	 void OnGUI (){
		
		GUI.Box(new Rect(480, 10, 120, 50), "Item Equipped");
		GUI.Label(new Rect( 500, 30, 120, 100), Inventory[equipped].Tooltype + " " + Inventory[equipped].howmany);
		
		/*GUI.Box(new Rect(480, 60, 120, 200), "Inventory");
		for(int i = 0; i < Inventory.Count; i++)
		{
			GUI.Label(new Rect(500, (70 +i*20), 120, 100), Inventory[i].Tooltype + " " + Inventory[i].howmany);
		}*/
		
	}
	
	
	
}
