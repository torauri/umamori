using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_Event : MonoBehaviour {

	private bool start;
	// Use this for initialization
	void Start () {
		start=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(start && Input.GetKey("return")){
			Time.timeScale=1f;
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag=="Touzoku"||other.gameObject.tag=="Doller"){
			start=true;
			Time.timeScale=0;
		}
	}

}
