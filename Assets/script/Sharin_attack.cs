using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharin_attack : MonoBehaviour {

	public float sharin_attack_speed;
	public float sharin_attack_range;
	private float range;
	private float rad;
	
	void Start(){
		range=0;
	}
	// Update is called once per frame
	void Update () {
		Vector2 pos = transform.position;
		pos.x+=sharin_attack_speed*Mathf.Sin(rad);
		pos.y+=sharin_attack_speed*Mathf.Cos(rad);
		transform.position=pos;
		range+=sharin_attack_speed;
		if(range>sharin_attack_range){
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag=="Doll"){
			other.gameObject.GetComponent<Doll>().Doll_Damage(1);
			Destroy(this.gameObject);
		}else if(other.gameObject.tag=="Doller"){
			other.gameObject.GetComponent<Doller>().Doller_Damage(1);
			Destroy(this.gameObject);
		}else if(other.gameObject.tag=="Touzoku"){
			Destroy(this.gameObject);
		}
	}
	public void SetTarget(float target){
		rad=target;
	}

}
