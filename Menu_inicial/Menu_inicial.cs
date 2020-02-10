using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Menu_inicial : MonoBehaviour
{
	public float velocidade_ui;
	public float distancia_folga;

	bool pode_mover;

	void Start(){

	}

	void Update(){
		if(pode_mover){
			if(move_botoes() == true){
				SceneManager.LoadScene("Transicao");
			}
		}
	}

	public void Botao_play(){
		pode_mover = true;
	}

	bool move_botoes(){
		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
 		float width = height * cam.aspect;

		BoxCollider2D box_play = transform.GetChild(0).GetComponent<BoxCollider2D>();
		RectTransform play_posicao = transform.GetChild(0).GetComponent<RectTransform>();
		play_posicao.anchorMin += new Vector2(velocidade_ui,0);
		play_posicao.anchorMax += new Vector2(velocidade_ui,0);
		
		BoxCollider2D box_credits = transform.GetChild(1).GetComponent<BoxCollider2D>();
		RectTransform credits_posicao = transform.GetChild(1).GetComponent<RectTransform>();
		credits_posicao.anchorMin -= new Vector2(velocidade_ui,0);
		credits_posicao.anchorMax -= new Vector2(velocidade_ui,0);

		RectTransform titulo_posicao = transform.parent.GetChild(0).GetComponent<RectTransform>();
		titulo_posicao.anchorMin += new Vector2(0, velocidade_ui);
		titulo_posicao.anchorMax += new Vector2(0, velocidade_ui);

		//Gambiarra porca, mas funfa
		if(box_play.Distance(box_credits).distance / 100 > width + distancia_folga){
			return true;
		}
		return false;
	}
}



 // Camera cam = Camera.main;
 // float height = 2f * cam.orthographicSize;
 // float width = height * cam.aspect;