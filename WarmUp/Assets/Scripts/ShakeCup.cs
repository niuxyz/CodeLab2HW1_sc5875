using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeCup : MonoBehaviour {
	public GameObject DestinyBall;
	[SerializeField] Text m_text;
	[SerializeField] List<string> destiny;
	[SerializeField] Spawner spawner;
	Vector2 originalPos;
	float offsetX;
	float offsetY;
	float timer;
	// Use this for initialization
	void Start () {
		offsetX = .1f;
		offsetY = .1f;
		originalPos = transform.position;
		timer = 0.0f; 
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			Shake();
			transform.position += Vector3.right * offsetX;
			transform.position += Vector3.up * offsetY;
			timer += Time.deltaTime;
		}
		else{
			timer = 0.0f;
		}

		if(timer >= 2.0f){
			timer = 0.0f;
			// spawner.SpriteTime();
			DestinyBall = spawner.SpriteTime();
			DestinyBall.GetComponent<Collider2D>().enabled = false;
			DestinyBall.GetComponent<Rigidbody2D>().velocity = Vector2.right;
			this.enabled = false;

			switch (spawner.SpriteNum)
			{
				case 0:
					m_text.text = "Blue:" + destiny[0];
					break;
				case 1:
					m_text.text = "Green:" + destiny[1];
					break;
				case 2:
					m_text.text = "Red" + destiny[2];
					break;
				case 3:
					m_text.text = "Yellow" + destiny[3];
					break;
				default:
					break;
			}
		}
	}
	void Shake(){
		//X
		if(transform.position.x - originalPos.x >= .5f){
			offsetX = -Random.Range(0.05f, .1f);
		}
		else if(transform.position.x - originalPos.x <= -.5f){
			offsetX = Random.Range(0.05f, .1f);
		}
		//Y
		if(transform.position.y - originalPos.y >= .5f){
			offsetY = -Random.Range(0.05f, .1f);
		}
		else if(transform.position.y - originalPos.y <= -.5f){
			offsetY = Random.Range(0.05f, .1f);
		}
	}
}
