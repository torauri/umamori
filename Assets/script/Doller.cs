using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doller : MonoBehaviour {

	private int HP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Doller_Damage(int d){
		HP-=d;
	}
}
