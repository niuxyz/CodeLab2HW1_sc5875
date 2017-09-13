using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public Sprite[] sprites;
	public int SpriteNum;
	[SerializeField] PhysicsMaterial2D phyMat;
	void Start (){
		// InvokeRepeating("SpriteTime",1,.1f);
		for (int i = 0; i < 16; i++)
		{
			SpriteTime();
		}
	}
	void Update (){

	}

	public GameObject SpriteTime(){
		SpriteNum = GetComponent<NumberGenerator>().Next();

		return MakeSprite(SpriteNum);
	}
	GameObject MakeSprite(int num){
		GameObject goSprite = new GameObject();
		SpriteRenderer sr = goSprite.AddComponent<SpriteRenderer>();
		sr.sprite = sprites[num];
		goSprite.AddComponent<Rigidbody2D>();
		Rigidbody2D m_rigid = goSprite.GetComponent<Rigidbody2D>();
		m_rigid.gravityScale = 0.0f;
		m_rigid.velocity = new Vector2(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f));
		goSprite.AddComponent<CircleCollider2D>();
		goSprite.GetComponent<CircleCollider2D>().sharedMaterial = phyMat;

		return goSprite;
	}

}
