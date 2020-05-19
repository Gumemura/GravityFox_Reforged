using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouder : MonoBehaviour
{
	[Range(0f, 500f)]
	public float forca_x;
	[Range(0f, 500f)]
	public float forca_y;

	Rigidbody2D rb2d;

	// Start is called before the first frame update
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.AddForce(new Vector2(-forca_x, 0));
	}

	// Update is called once per frame
	void FixedUpdate()
	{

	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.layer == 10){
			rb2d.AddForce(new Vector2(-forca_x, forca_y));
		}
	}
}
