using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koumori : MonoBehaviour {
	public float koumori_range;
	public float koumori_speed;
	private float v;
	private float posX;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		v=1f;
		posX=0;
		anim=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = transform.position;
		pos.x+=(v*koumori_speed);
		posX+=(v*koumori_speed);
		transform.position = pos;
		anim.SetFloat("speed",v);
		if(posX*v>=koumori_range){
			v=v*(-1f);
		}
	}
}
