using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Moviment : MonoBehaviour
{
	//Nao importa a velocidade global pois ela é constante
	public float Velocidade_Back;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector2(-Velocidade_Back * Time.deltaTime , 0));
    }
}
