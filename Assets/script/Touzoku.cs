using UnityEngine;
using System.Collections;

public class Touzoku : MonoBehaviour {

	public float touzoku_speed = 4f;
	public float touzoku_jumpPower = 700;
	public LayerMask touzoku_groundLayer;
	public GameObject touzoku_mainCamera;
	public GameObject stone;
	private int hudaNum;
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool isGrounded;
	private Vector3 cameraTarget;
	private float v;
	


	void Start () {
		//いろんな初期化
		rigidbody2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		v=1;
		hudaNum=0;
		//カメラ初期化
		cameraTarget = transform.position;
		cameraTarget.x = cameraTarget.x+4;
	}
//********** 開始 **********//
	void Update ()
	{
		if (Mathf.Approximately(Time.timeScale, 0f)) {
			return;
		}
		//Linecastでユニティちゃんの足元に地面があるか判定
		isGrounded = Physics2D.Linecast (
		transform.position + transform.up * 200,
		transform.position - transform.up * 100,
		touzoku_groundLayer);
		//スペースキーを押し、
		if (Input.GetKeyDown ("space")) {
			//着地していた時、
			if (isGrounded) {
				//着地判定をfalse
				isGrounded = false;
				//AddForceにて上方向へ力を加える
				rigidbody2D.AddForce (Vector2.up * touzoku_jumpPower);
			}
		}

		if(this.transform.childCount==0 && Input.GetKeyDown("f")){
			StoneSummon();
		}

	}
//********** 終了 **********//

	void FixedUpdate ()
	{
		//移動、カメラ制御
		float x = Input.GetAxisRaw ("Horizontal");
		if (x != 0) {
			anim.SetFloat("speed",x);
			anim.SetBool("move",true);
			v=x;
			rigidbody2D.velocity = new Vector2 (x * touzoku_speed, rigidbody2D.velocity.y);

			if (x>0) {
				cameraTarget = transform.position;
				cameraTarget.x = cameraTarget.x+200;
			}else{
				cameraTarget = transform.position;
				cameraTarget.x = cameraTarget.x-200;
			}
			Vector2 pos = transform.position;
			transform.position = pos;
		} else {
			anim.SetBool("move",false);
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
		}
		Vector3 cameraPos = touzoku_mainCamera.transform.position;
		cameraPos.x = cameraPos.x + (cameraTarget.x-cameraPos.x)/20;
		cameraPos.y = transform.position.y+150;
		touzoku_mainCamera.transform.position = cameraPos;
	}

	void StoneSummon(){
				// プレハブからインスタンスを生成
				Vector2 pos = transform.position;
				pos.y+=50;
				GameObject obj = (GameObject)Instantiate(stone, transform.position, Quaternion.identity);
				// 作成したオブジェクトを子として登録
				obj.transform.SetParent(transform, false);
				obj.transform.position=pos;
				obj.GetComponent<Stone>().speed = 10*(v/Mathf.Abs(v));
	}
}
