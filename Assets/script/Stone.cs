using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {


	public float maxrange;
	public float speed;
	private float range;
	// Use this for initialization
	void Start () {
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
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag=="Enemy"){
			other.gameObject.GetComponent<Enemy>().Enemy_Damage(10);
			Destroy(this.gameObject);
		}
	}
}
