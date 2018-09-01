using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour {

	public float maxrange;
	private bool shot;
	private float round;
	private float sicle;
	private float speed;
	private float range;
	// Use this for initialization
	void Start () {
		sicle = Mathf.PI/50;
		round = 1f;
		range = 0;
	}

	// Update is called once per frame
	void Update () {
			//射出時の処理
			Vector2 pos = transform.position;
			pos.x+=speed;
			range+=Mathf.Abs(speed);
			if(range<=maxrange){
				transform.position = pos;
			}else{
				Destroy(this.gameObject);
			}
	}
	public void tamaShot(float x){
		if(shot==false){
			shot = true;
			transform.Rotate(0.0f, 0.0f, 90);
			speed = x;
		}
	}
	void OnCollisionEnter (Collision col){
		if(col.gameObject.tag=="Doll"){
			col.gameObject.GetComponent<Doll>().Doll_Damage(1);
			Destroy(this.gameObject);
		}
	}
}
