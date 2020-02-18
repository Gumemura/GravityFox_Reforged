using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos_Spawn_Destroy : MonoBehaviour
{
	public GameObject Aguia;
	public GameObject velocidade_global;

	public float spawn_aguia;
	public float folga_destroy;
	public float vel;

	Camera cam;
	float camera_width;
    // Start is called before the first frame update
    void Start()
    {
    	cam = Camera.main;
		camera_width = 2 * cam.orthographicSize * cam.aspect;
		StartCoroutine(Spawn_Aguia());
    }

    // Update is called once per frame
    void Update()
    {
    	vel = velocidade_global.GetComponent<Velocidade_global>().velocidade;

    	foreach(Transform child in transform){
			if(child.position.x  < cam.transform.position.x - (camera_width/2) - folga_destroy){
				Destroy(child.gameObject);
			}
		}
    }

    IEnumerator Spawn_Aguia(){
    	while(1 == 1){
    		vel = velocidade_global.GetComponent<Velocidade_global>().velocidade;
    		float tempo_Spawn_aguia = 50/vel;
	    	float y_spawn_aguia = Random.Range(1 + .2f, 2 + .3f);
	    	int gravidade_sinal = (int)Mathf.Sign(Physics2D.gravity.y) * -1;
	    	Instantiate(Aguia, new Vector2(12 + .5f, y_spawn_aguia * gravidade_sinal), Quaternion.identity, this.transform);
	    	yield return new WaitForSeconds(tempo_Spawn_aguia);
    	}
    }
}
