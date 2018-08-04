using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 4f;
	public float jumpPower = 700;
	public LayerMask groundLayer;
	public GameObject mainCamera;
	public GameObject[] hudas;
	private int hudaNum;
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool isGrounded;
	private Vector3 cameraTarget;
	private float v;

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		v=1;
		hudaNum=0;
		//カメラ初期化
		cameraTarget = transform.position;
		cameraTarget.x = cameraTarget.x+4;
	}
//********** 開始 **********//
	void Update ()
	{
		//Linecastでユニティちゃんの足元に地面があるか判定
		isGrounded = Physics2D.Linecast (
		transform.position + transform.up * 1,
		transform.position - transform.up * 0.05f,
		groundLayer);
		//スペースキーを押し、
		if (Input.GetKeyDown ("space")) {
			//着地していた時、
			if (isGrounded) {
				//着地判定をfalse
				isGrounded = false;
				//AddForceにて上方向へ力を加える
				rigidbody2D.AddForce (Vector2.up * jumpPower);
			}
		}
		if(Input.GetKeyDown("f")){
			foreach( Transform child in transform ) {
				child.gameObject.GetComponent<Huda>().hudaShot(v/2);
			}
		}
		if(Input.GetKeyDown("g")){
			hudaNum=(hudaNum+1)%hudas.Length;
			foreach( Transform child in transform ) {
				Destroy(child.gameObject);
			}
		}
		if(this.transform.childCount==0){
			hudaSummon();
		}

	}
//********** 終了 **********//

	void FixedUpdate ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		if (x != 0) {
			v=x;
			rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);

			if (x>0) {
				cameraTarget = transform.position;
				cameraTarget.x = cameraTarget.x+4;
			}else{
				cameraTarget = transform.position;
				cameraTarget.x = cameraTarget.x-4;
			}
			Vector2 pos = transform.position;
			transform.position = pos;
		} else {
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
		}
		Vector3 cameraPos = mainCamera.transform.position;
		cameraPos.x = cameraPos.x + (cameraTarget.x-cameraPos.x)/20;
		cameraPos.y = transform.position.y+3;
		mainCamera.transform.position = cameraPos;
	}

	void hudaSummon(){
		for(float i=-0.2f;i<=0.2f;i+=0.4f){
			for(float j=-0.2f;j<=0.2f;j+=0.4f){
				Vector2 pos = new Vector2(i,j+10);
				// プレハブからインスタンスを生成
				GameObject obj = (GameObject)Instantiate(hudas[hudaNum], transform.position, Quaternion.identity);
				// 作成したオブジェクトを子として登録
				obj.transform.SetParent(transform, false);
				obj.transform.localPosition=pos;
			}
		}
	}
}
