using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huda : MonoBehaviour {


	public float maxrange;
	private bool shot;
	private float round;
	private float sicle;
	private float speed;
	private float range;
	// Use this for initialization
	void Start () {
		shot = false;
		sicle = Mathf.PI/50;
		round = 1f;
		range = 0;
	}

	// Update is called once per frame
	void Update () {
		if(shot){
			//射出時の処理
			Vector2 pos = transform.position;
			pos.x+=speed;
			range+=Mathf.Abs(speed);
			if(range<=maxrange){
				transform.position = pos;
			}else{
				Destroy(this.gameObject);
			}
		}else{
			//待機時の処理
			Vector2 parentPos=transform.root.gameObject.transform.position;
			parentPos.y+=1;
			Vector2 pos = transform.position;
			Vector2 newPos = pos;
			float r1=Mathf.Sqrt((pos.x-parentPos.x)*(pos.x-parentPos.x)+(pos.y-parentPos.y)*(pos.y-parentPos.y));
			float r2=r1+(round-r1)/20;
			newPos.x=((pos.x-parentPos.x)/r1*Mathf.Cos(sicle) - (pos.y-parentPos.y)/r1*Mathf.Sin(sicle))*r2 + parentPos.x;
			newPos.y=((pos.y-parentPos.y)/r1*Mathf.Cos(sicle) + (pos.x-parentPos.x)/r1*Mathf.Sin(sicle))*r2 + parentPos.y;
			transform.position=newPos;

		}
	}
	public void hudaShot(float x){
		shot = true;
		transform.Rotate(0.0f, 0.0f, 90);
		speed = x;
	}
}
