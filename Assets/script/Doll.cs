using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour {

	private int HP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Doll_Damage(int d){
		HP-=d;
		
	}
}
