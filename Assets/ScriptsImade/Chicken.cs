using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class Chicken : MonoBehaviour 
{
	CharacterController _controller;
  	Transform _transform;
	
	float speed = 2f;
	float gravity = 20f;
	Vector3 moveDirection;
	
	Vector3 target;
	float maxRotSpeed = 200.0f;
	float minTime = 0.1f;
	float velocity;
	
	bool change;
	float range;
	
	int turn = 0;
	Vector3 _rotation;
	
	public Egg eggclass;
	private Egg[,] eggfield;
	
	bool isFed = false;
	float timeFed;

	void Start () 
	{
		_controller = GetComponent<CharacterController>();
      	_transform = GetComponent<Transform>();
		//_rotation = Collider.bounds.center;
		
		range = 2f;
	    target = GetTarget();
		
		timeFed = Timemanager.time;
	    //InvokeRepeating ("NewTarget",0.01f,2.0f);
	}

	void Update () 
	{
		NewTarget();
		if(change)
		{
       		target = GetTarget ();
		}
		
   		if(Vector3.Distance(_transform.position,target)>range)
		{
      		Move();
   		}
		
		if(isFed == true)
		{
			if(Timemanager.time - timeFed > 1080)
			{
				layEgg();
				isFed = false;
			}
		}
		
		if(Timemanager.time - timeFed > 2880)
		{
			renderer.enabled = false;
			this.collider.enabled = false;	
		}
			

	/*	turn++;
		if(turn > 5)
		{
			_transform.RotateAround(_rotation.zero, _rotation.up, 20*Time.deltaTime);
			turn = 0;
		}
	*/	
		
	}
	
	Vector3 GetTarget()
	{
   		return new Vector3(Random.Range (-50000,50000),0,Random.Range (-50000,50000));
	}
	
	void Move() 
	{	
		moveDirection = _transform.forward;
	    moveDirection *= speed;
	    moveDirection.y -= gravity;
	    _controller.Move(moveDirection * Time.deltaTime);
		
		
		var newRotation = Quaternion.LookRotation(target - _transform.position).eulerAngles;
    	var angles = _transform.rotation.eulerAngles;
    	_transform.rotation = Quaternion.Euler(angles.x, Mathf.SmoothDampAngle(angles.y, newRotation.y, ref velocity, minTime, maxRotSpeed), angles.z);
		
	}
	
	void NewTarget()
	{
	  	int choice = Random.Range (0,3);
	   	switch(choice)
		{
	      case 0: 
	         change = true;
	         break;
	      case 1: 
	         change = false;
	         break;
	      case 2:
	         target = _transform.position;
	         break; 
		} 
	}
	
	void layEgg()
	{
		
		eggfield = new Egg[1,1];
		
		for(int i = 0; i < 1; i++) 
		{
			for(int j = 0; j < 1; j++)
			{
				Vector3 eggPosition = new Vector3(this.transform.position.x+i, this.transform.position.y, this.transform.position.z+j);
				eggfield[i,j] = (Egg)Instantiate(eggclass, eggPosition, Quaternion.identity);
			}
		}
	}
	
	public void feed() 
	{
		isFed = true;
		timeFed = Timemanager.time;
	}
	
}
