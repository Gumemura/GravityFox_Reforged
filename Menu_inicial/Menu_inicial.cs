using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Menu_inicial : MonoBehaviour
{
	public float velocidade_ui;
	public float tempo_liga_cena;

	bool pega_tempo;
	bool pode_mover;

	void Start(){

	}

	void Update(){
		if(pode_mover){
			pega_tempo = true;
			move_botoes();

			if(move_botoes() == true){
				SceneManager.LoadScene("Game");
			}
		}
	}

	public void Botao_play(){
		pode_mover = true;
	}

	bool move_botoes(){
		float tempo_1a_chamda = 0;

		if(pega_tempo){
			tempo_1a_chamda = Time.time;
			pega_tempo = false;
		}

		RectTransform play_posicao = transform.GetChild(0).GetComponent<RectTransform>();
		play_posicao.anchorMin += new Vector2(velocidade_ui,0);
		play_posicao.anchorMax += new Vector2(velocidade_ui,0);
		
		RectTransform credits_posicao = transform.GetChild(1).GetComponent<RectTransform>();
		credits_posicao.anchorMin -= new Vector2(velocidade_ui,0);
		credits_posicao.anchorMax -= new Vector2(velocidade_ui,0);

		RectTransform titulo_posicao = transform.parent.GetChild(0).GetComponent<RectTransform>();
		titulo_posicao.anchorMin += new Vector2(0, velocidade_ui);
		titulo_posicao.anchorMax += new Vector2(0, velocidade_ui);

		//Hardcode total. A funcao retorna true apos uma determinado tempo. O correto seria
		/*
		if(x_botao_play > x_inicial_play + x_camera){
			return true;
		}
		Mas ta foda pq o codigo de movimentacao dos botoes move o achor, que nao tem um transform.position;
		*/ 

		if(Time.time > tempo_1a_chamda + tempo_liga_cena){
			return true;
		}
		return false;

		
	}
}