using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawn_Destroy : MonoBehaviour
{
	public GameObject moeda;
	public int folga_destroy;
	public GameObject velocidade_global;
	public float vel;

	int Quantidade_moedas_altera_altura;
	int cont_moeda;
	int altura_moeda;

	Camera cam;
	float camera_width;


	// // // // Start is called before the first frame update
	void Start()
	{
		Quantidade_moedas_altera_altura = 10;
		cam = Camera.main;
		camera_width = 2 * cam.orthographicSize * cam.aspect;
		StartCoroutine(Invoca_moeda());
		cont_moeda = 0;    
		altura_moeda = 0;    
	}

	// Update is called once per frame
	void Update()
	{
		vel = velocidade_global.GetComponent<Velocidade_global>().velocidade;

		foreach(Transform child in transform){
			if(child.position.x < cam.transform.position.x - (camera_width/2) - folga_destroy){
				Destroy(child.gameObject);
			}
		}
	}

	IEnumerator Invoca_moeda(){
		while(1 == 1){
			 if(cont_moeda > Quantidade_moedas_altera_altura){
				// altura_moeda = (int)Random.Range(0, 6);
				// if(altura_moeda == 6){
				// 	 altura_moeda = 5;
				// }
				int sorteio = (int)Random.Range(0, 100);
				if(sorteio < 20)		{altura_moeda = 0;}
				else if(sorteio < 40)	{altura_moeda = 5;}
				else if(sorteio < 55)	{altura_moeda = 2;}
				else if(sorteio < 70)	{altura_moeda = 3;}
				else if(sorteio < 85)	{altura_moeda = 4;}
				else if(sorteio <= 100)	{altura_moeda = 1;}

				cont_moeda = 0;
				Quantidade_moedas_altera_altura = (int)Random.Range(10, 25);
			}
			Instantiate(moeda, new Vector2(24, -3 - .2f + ((1 + .24f) * altura_moeda)), Quaternion.identity, this.transform);
			cont_moeda++;

			vel = velocidade_global.GetComponent<Velocidade_global>().velocidade;
			float tempo_spawn_moeda = (10 / vel) * .2f;

			yield return new WaitForSeconds(tempo_spawn_moeda);
		}
	//         Instantiate(moeda, new Vector2(24, -3 - .2f + ((1 + .24f) * 0)), Quaternion.identity, this.transform);
	//         Instantiate(moeda, new Vector2(24, -3 - .2f + ((1 + .24f) * 1)), Quaternion.identity, this.transform);
	//         Instantiate(moeda, new Vector2(24, -3 - .2f + ((1 + .24f) * 2)), Quaternion.identity, this.transform);
	//         Instantiate(moeda, new Vector2(24, -3 - .2f + ((1 + .24f) * 3)), Quaternion.identity, this.transform);
	//         Instantiate(moeda, new Vector2(24, -3 - .2f + ((1 + .24f) * 4)), Quaternion.identity, this.transform);
	//         Instantiate(moeda, new Vector2(24, -3 - .2f + ((1 + .24f) * 5)), Quaternion.identity, this.transform);
	}
}