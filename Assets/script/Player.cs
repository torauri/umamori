using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 4f;
	public float jumpPower = 700;
	public LayerMask groundLayer;
	public GameObject mainCamera;
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool isGrounded;
	private Vector3 cameraTarget;

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
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
				//Dashアニメーションを止めて、Jumpアニメーションを実行
				//着地判定をfalse
				isGrounded = false;
				//AddForceにて上方向へ力を加える
				rigidbody2D.AddForce (Vector2.up * jumpPower);
			}
		}

	}
//********** 終了 **********//

	void FixedUpdate ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		if (x != 0) {
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
}
