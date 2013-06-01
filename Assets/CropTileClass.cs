using UnityEngine;
using System.Collections;

public class CropTileClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void plant() {
		Debug.Log("HELLO WORLD");	
		this.transform.gameObject.GetComponent<Renderer>().material.color = new Color (Random.Range (0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range (0f,1f));
	}
}
