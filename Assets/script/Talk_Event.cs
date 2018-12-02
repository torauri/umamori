using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk_Event : MonoBehaviour {

	public TextAsset talkAsset;
	public GameObject talkUI;
	public GameObject canvas;
	private bool start;
	private List<string[]> talkStringList;
	private int count;
	private int interval;
	private GameObject sumonUI;
	// Use this for initialization
	void Start () {
		count =2;
		start=false;
		interval=10;

		talkStringList = new List<string[]>();
		StringReader reader = new StringReader(talkAsset.text);
		while(reader.Peek() > -1) {
			// 一行読み込む
			string s=reader.ReadLine();
			// カンマ(,)区切りのデータを文字列の配列に変換
			string[] ss = s.Split (',');
			// リストに追加
			string[] sss = {ss[3],ss[2]};
			talkStringList.Add(sss);
			// 末尾まで繰り返し...
    	}
	}
	
	// Update is called once per frame
	void Update () {
		interval++;
		if(start && Input.GetKey("return") && interval>10){
			if(talkStringList.Count>count){
				sumonUI.transform.GetChild(3).GetComponent<Text>().text=talkStringList[count][0];
				sumonUI.transform.GetChild(4).GetComponent<Text>().text=talkStringList[count][1];
				count++;
				interval=0;
			}else{
				Time.timeScale=1f;
				Destroy(sumonUI);
				Destroy(this.gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag=="Touzoku"||other.gameObject.tag=="Doller"){
			start=true;
			Time.timeScale=0;
			sumonUI = (GameObject)Instantiate(talkUI);
			sumonUI.transform.SetParent(canvas.transform, false);
			sumonUI.transform.GetChild(3).GetComponent<Text>().text=talkStringList[1][0];
			sumonUI.transform.GetChild(4).GetComponent<Text>().text=talkStringList[1][1];

		}
	}

}
