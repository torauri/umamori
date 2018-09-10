using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	
	public int HP;
	private int hp;
	private float barmax;

	void Start(){
		hp=HP;
		barmax=transform.FindChild ("Enemy_HP_Bar").gameObject.transform.localScale.x;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag=="Doll"){
			other.gameObject.GetComponent<Doll>().Doll_Damage(1);
		}else if(other.gameObject.tag=="Doller"){
			other.gameObject.GetComponent<Doller>().Doller_Damage(1);
		}
	}
	public void Enemy_Damage(int d){
		hp-=d;
		transform.FindChild ("Enemy_HP_Bar").gameObject.transform.localScale=new Vector2((hp/(float)HP)*barmax,1f);
		if(hp<=0){
			Destroy(this.gameObject);
		}
	}
}
