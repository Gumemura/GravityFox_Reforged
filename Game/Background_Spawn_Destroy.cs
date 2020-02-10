using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script feito para spawn e destroy background
public class Background_Spawn_Destroy : MonoBehaviour
{
	public float Folga;
	public GameObject Prefab;

    float x_inicial;
    float y_inicial;

	float x_destory;
	float x_Spawn;

	Camera cam;
	float camera_height;
	float camera_width;

    void Start()
    {
    	cam = Camera.main;
    	camera_height = 2 * cam.orthographicSize;
		camera_width = camera_height * cam.aspect;

        x_inicial = Prefab.transform.position.x;
        y_inicial = Prefab.transform.position.y;
    }

    void FixedUpdate()
    {
    	BoxCollider2D 		box 		= transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
    	Transform 			transf 		= transform.GetChild(0).gameObject.GetComponent<Transform>();  	

        if(transf.position.x < cam.transform.position.x && transform.childCount < 2){
            Instantiate(Prefab, new Vector2(transf.position.x + 2 * box.bounds.extents.x, transf.position.y), Quaternion.identity, this.transform);
        }

        //Destory
    	if(transf.position.x + box.bounds.extents.x + Folga < cam.transform.position.x - camera_width){
    		//Prefab.GetComponent<Background_Moviment>().enabled = false;
            Destroy(transf.gameObject);
    	}   
    }
}
