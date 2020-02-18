using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas_Spawn_Destroy : MonoBehaviour
{
	public GameObject prefab_top;
	public GameObject prefab_bot;
	public GameObject velocidade_global;
	public float vel;
	public float Folga;

	BoxCollider2D box;

	float x_inicial;
	float y_bot_inicial;
	float y_top_inicial;

	Camera cam;
	float camera_width;

	// Start is called before the first frame update
	void Start()
	{
		cam = Camera.main;
		camera_width = 2 * cam.orthographicSize * cam.aspect;

		x_inicial = transform.Find("Plataforma_Bot").position.x;
		y_bot_inicial = transform.Find("Plataforma_Bot").position.y;
		y_top_inicial = transform.Find("Plataforma_Top").position.y;
	}

	// Update is called once per frame
	void Update()
	{
		vel = velocidade_global.GetComponent<Velocidade_global>().velocidade;

		foreach(Transform child in transform){
			if(child.position.x  + child.GetComponent<BoxCollider2D>().bounds.extents.x < cam.transform.position.x - (camera_width/2) - Folga){
				Destroy(child.gameObject);
			}
		}  

		if(transform.GetChild(0).position.x < cam.transform.position.x && transform.childCount < 5){
			Instantiate(prefab_top, new Vector2(transform.GetChild(0).position.x + (4 * transform.GetChild(0).GetComponent<BoxCollider2D>().bounds.extents.x) - Folga, y_top_inicial), Quaternion.identity, this.transform);
			Instantiate(prefab_bot, new Vector2(transform.GetChild(0).position.x + (4 * transform.GetChild(0).GetComponent<BoxCollider2D>().bounds.extents.x) - Folga, y_bot_inicial), Quaternion.identity, this.transform);
		}
	}
}
