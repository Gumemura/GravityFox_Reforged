using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawn_Destroy : MonoBehaviour
{
	public GameObject moeda;
	public int Quantidade_moedas_altera_altura;
	public float Tempo_de_invocao;
	public int Delay_primeira_moeda;
	public int folga_destroy;

	int cont_moeda;
   	int altura_moeda;

   	Camera cam;
	float camera_width;


    // Start is called before the first frame update
    void Start()
    {
    	cam = Camera.main;
		camera_width = 2 * cam.orthographicSize * cam.aspect;

    	InvokeRepeating("Invoca_moeda", Delay_primeira_moeda, Tempo_de_invocao);
		cont_moeda = 0;    
		altura_moeda = 0;    
    }

    // Update is called once per frame
    void Update()
    {
    	foreach(Transform child in transform){
     		if(child.position.x < cam.transform.position.x - (camera_width/2) - folga_destroy){
     			Destroy(child.gameObject);
     		}
     	}
    }

    void Invoca_moeda(){
    	if(cont_moeda > Quantidade_moedas_altera_altura){
    		altura_moeda = (int)Random.Range(0, 6);
    		if(altura_moeda == 6){
    			altura_moeda = 5;
    		}
    		cont_moeda = 0;
    	}
    	Instantiate(moeda, new Vector2(24, -3 - .2f + ((1 + .24f) * altura_moeda)), Quaternion.identity, this.transform);
    	cont_moeda++;
    }
}