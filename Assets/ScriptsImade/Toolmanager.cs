using UnityEngine;
using System.Collections;

public class Toolmanager : MonoBehaviour {
	
	public string Tooltype = "0"; //{get; set; } //tells us what kind of tool it is
	public int distance = 0; // distance of crops it affects
	public int cost = 0; //cost to use tool
	public int howmany = 0; //how many you have in your inventory
	public int howmuchtowater = 0; //how many waters it takes the plant to grow
	
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Toolmanager(string tool, int dist, int acost, int num, int hours) {
		Tooltype = tool;
		distance = dist;
		cost = acost;
		howmany = num;
		howmuchtowater = hours;
	}
	
	public void addtool ()
	{
		howmany++;
	}
	
	public bool minustool () 
	{	
		if(howmany > 0){
			howmany--;
			if(howmany == 0)
				InventoryManager.removetool();
			return true;
		}
		else
		{
			//InventoryManager.removetool();
			return false;
		}
	}
	
	public bool equals(Toolmanager other) 
	{
		return this.Tooltype == other.Tooltype;
	}
	
	public string whatTool()
	{
		return Tooltype;
	}
}