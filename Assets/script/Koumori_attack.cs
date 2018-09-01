using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koumori_attack : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag=="Doll"){
			other.gameObject.GetComponent<Doll>().Doll_Damage(1);
		}else if(other.gameObject.tag=="Doller"){
			other.gameObject.GetComponent<Doller>().Doller_Damage(1);
		}
	}
}
