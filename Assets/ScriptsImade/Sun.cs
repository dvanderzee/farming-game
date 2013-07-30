using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {
	
	int months;
	float days;
	float hours;
	public Timemanager Timemanagercomponent;
	//public GameObject sun;

	// Use this for initialization
	void Start () {
		/*months = (int)Timemanagercomponent.howmanymonthstotal();
		days = (int)Timemanagercomponent.howmanydaystotal() - (months*10.0f);
		hours = (int)Timemanagercomponent.howmanyhourstotal() - (days*24.0f);
		sun = GameObject.Find("Sun"); */
	}
	
	// Update is called once per frame
	void Update () {
		/*months = (int)Timemanagercomponent.howmanymonthstotal();
		days = (int)Timemanagercomponent.howmanydaystotal() - (months*10.0f);
		hours = (int)Timemanagercomponent.howmanyhourstotal() - (days*24.0f);
		sun.light.intensity = 5;
		*/
	}
}
