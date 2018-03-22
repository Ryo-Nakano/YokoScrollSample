using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン遷移扱う

public class PlayerScript : MonoBehaviour {

	[SerializeField] float speed;//Playerの移動スピード
	[SerializeField] float jumpPower;//Playerがジャンプする時のパワー

	Rigidbody rb;//取って来たRigidbody入れておく為の変数

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();//Rigidbody取って来て変数rbに格納
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}


	//==========以下、関数==========

	//Playerの移動
	void Move()
	{
		if(Input.GetKey("right"))
		{
			this.transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		}

		if(Input.GetKey("left"))
		{
			this.transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
		}

		if(Input.GetKeyDown("space"))
		{
			rb.velocity = this.transform.up * jumpPower;//方向ベクトル×大きさ
		}
	}

	//当たり判定
	void OnCollisionEnter(Collision col)
	{
		//当たった相手のタグが"Enemy"だった時
		if(col.gameObject.tag == "Enemy")
		{
			SceneManager.LoadScene ("GameOver");//GameOverシーンの読み込み
		}
	}
}
