using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharin : MonoBehaviour {

	public GameObject sharin_attack;
	public float sharin_interval;
	public float sharin_range;
	public float sharin_speed;
	private float v;
	private float posX;
	private Animator anim;
	private float time;
	private Vector2 target;
	private bool targetCome;
	// Use this for initialization
	void Start () {
		time = 0;
		v=1f;
		target = new Vector2(0,0);
		targetCome=false;
		anim=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Approximately(Time.timeScale, 0f)) {
			return;
		}
		Vector2 pos = transform.parent.transform.position;
		pos.x+=(v*sharin_speed);
		posX+=(v*sharin_speed);
		transform.parent.transform.position = pos;
		anim.SetFloat("speed",v);
		if(posX*v>=sharin_range){
			v=v*(-1f);
		}

		time+=Time.deltaTime;
		if(targetCome){
			if(time>sharin_interval){
				// プレハブからインスタンスを生成
				time=0;
				Vector2 mypos = transform.position;
				Vector2 distance = target - mypos;
				float rad = Mathf.Atan2(distance.x,distance.y);
				GameObject obj = (GameObject)Instantiate(sharin_attack, transform.position, Quaternion.identity);
				// 作成したオブジェクトを子として登録
				//obj.transform.SetParent(transform, false);
				obj.transform.position=mypos;
				obj.GetComponent<Sharin_attack>().SetTarget(rad);
			}
		}
	}
	void OnTriggerStay2D (Collider2D col){
		if(col.gameObject.tag=="Doll" || col.gameObject.tag=="Doller" || col.gameObject.tag=="Touzoku"){
			targetCome=true;
			target = col.gameObject.transform.position;
		}
	}
}
