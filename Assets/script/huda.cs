using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huda : MonoBehaviour {

	private bool shot;
	private float round;
	private float sicle;
	// Use this for initialization
	void Start () {
		shot = false;
		sicle = Mathf.PI/50;
		round = 1f;
	}

	// Update is called once per frame
	void Update () {
		if(shot){
			//射出時の処理
			
		}else{
			//待機時の処理
			Vector2 parentPos=transform.root.gameObject.transform.position;
			Vector2 pos = transform.position;
			Vector2 newPos = pos;
			float r1=Mathf.Sqrt((pos.x-parentPos.x)*(pos.x-parentPos.x)+(pos.y-parentPos.y)*(pos.y-parentPos.y));
			float r2=r1+(round-r1)/20;
			newPos.x=((pos.x-parentPos.x)/r1*Mathf.Cos(sicle) - (pos.y-parentPos.y)/r1*Mathf.Sin(sicle))*r2 + parentPos.x;
			newPos.y=((pos.y-parentPos.y)/r1*Mathf.Cos(sicle) + (pos.x-parentPos.x)/r1*Mathf.Sin(sicle))*r2 + parentPos.y;
			transform.position=newPos;

		}
	}
}
