using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {


	public float maxrange;
	public float speed;
	private float range;
	private Vector2 mypos;
	// Use this for initialization
	void Start () {
		mypos = transform.position;
		range = 0;
	}

	// Update is called once per frame
	void Update () {
		//射出時の処理
		if (Mathf.Approximately(Time.timeScale, 0f)) {
			return;
		}
		mypos.x+=speed;
		range+=Mathf.Abs(speed);
		if(range<=maxrange){
			transform.position =mypos;
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
