using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float folga_manter_passo;
	public float velocidade_manter_passo;
	public LayerMask plataforma_contato;
	public LayerMask moeda_layer;
	public GameObject velocidade_global;
	public int contador_moedas;



	Rigidbody2D player_rb;
	BoxCollider2D box_player;
	Camera cam;
	Vector2 posicao_raycast;

	float camera_height;
	float camera_width;
	float x_inicial;


	// Start is called before the first frame update
	void Start()
	{
		x_inicial = -7;//transform.position.x;
		player_rb = GetComponent<Rigidbody2D>();
		box_player = GetComponent<BoxCollider2D>();
		cam = Camera.main;
		camera_height = cam.orthographicSize;
		camera_width = camera_height * cam.aspect;
		contador_moedas = 0;

		posicao_raycast = box_player.bounds.center;
	}

	void FixedUpdate()
	{
		Mantendo_Passo();
		rotacao();
		morte();
	}

	void Mantendo_Passo(){
		Vector2 velocity = player_rb.velocity;
		velocity.x = velocidade_manter_passo;

		if(transform.position.x < x_inicial && /*transform.position.x > cam.transform.position.x - camera_width - folga_manter_passo*/ morte() == false){
			//player_rb.velocity = new Vector2(velocidade_manter_passo, player_rb.velocity.y);
			player_rb.velocity = velocity;
		}
	}

	float y_contato;
	float distancia_player_plataforma;
	int alternante;

	void rotacao(){
		int sinal_gravidade = (int)Mathf.Sign(Physics2D.gravity.y) * -1;
		int ang_rotacao;
		float vel = velocidade_global.GetComponent<Velocidade_global>().velocidade;

		RaycastHit2D raycast = Physics2D.Raycast(posicao_raycast, Vector2.up * sinal_gravidade, Mathf.Infinity, plataforma_contato);

		float delta_s = Mathf.Sqrt(2 * raycast.distance/ (player_rb.gravityScale * (9 + .8f)));
		posicao_raycast = new Vector2(box_player.bounds.center.x + (vel * delta_s), box_player.bounds.center.y - (box_player.bounds.extents.y * sinal_gravidade));

		if(box_player.IsTouchingLayers(plataforma_contato)){
			foreach(Touch touch in Input.touches){
				if (touch.phase == TouchPhase.Began){
					distancia_player_plataforma = raycast.distance;
					y_contato = box_player.bounds.center.y - (box_player.bounds.extents.y * sinal_gravidade);
					//alternante =  -1 * (int)Mathf.Sign(y_contato);
					alternante = sinal_gravidade;
				}
			}
		}

		float metade = y_contato + (distancia_player_plataforma / 2 * alternante) ;

		if(box_player.bounds.center.y > metade){
			ang_rotacao = 180;
		}else{
			ang_rotacao = 0;
		}

		transform.rotation = new Quaternion(ang_rotacao, 0, 0, 0);

		//Raio metade
		Debug.DrawRay(new Vector2(-10, metade), Vector2.right * 10, Color.blue, 1, true);

		//Estimativa do pouso
		Debug.DrawRay(posicao_raycast, Vector2.up * raycast.distance * sinal_gravidade, Color.red, 1, true);

		// print("1. raycast.distance: " + raycast.distance);
		// print("2. delta_s: " + delta_s);
		// print("3. posicao_raycast: " + posicao_raycast);
		// print("4. vel: " + vel);
		// print("5. sinal_gravidade: " + sinal_gravidade);
		// print("6. y_contato: " + y_contato);
	}

	bool morte(){
		float diagonal_camera_metade = .5f *  Mathf.Sqrt(Mathf.Pow(2 * camera_height, 2) + Mathf.Pow(2 * camera_width, 2));

		if(Vector2.Distance(box_player.bounds.center, cam.transform.position) > diagonal_camera_metade + folga_manter_passo){
			print("morreu!");
			return true;
		}
		return false;
	}

	void OnTriggerEnter2D(Collider2D moeda_collider){
		if(moeda_collider.gameObject.layer == 12){
			contador_moedas++;
			Destroy(moeda_collider.gameObject);
		}
	}
}
