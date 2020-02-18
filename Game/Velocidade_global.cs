using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidade_global : MonoBehaviour
{
	public GameObject Player_Score;
	public float limite_vel;
	public float velocidade;
	public float aumento_velocidade;

	public int parametro_score_inicial;
	public int aumento_score;

	int score;

    void Start()
    {

    }

    void Update()
    {
    	score = Player_Score.GetComponent<Player>().contador_moedas;
    	if(velocidade < limite_vel){
	    	if(score > parametro_score_inicial){
	    		velocidade *= (1 + aumento_velocidade);
	    		parametro_score_inicial += aumento_score;
	    	}
    	}else{
    		velocidade = limite_vel;
    	}
    	//Usar update para aumentar a velocidade com o passar do tempo (ou pontuacao)    
    }
}
