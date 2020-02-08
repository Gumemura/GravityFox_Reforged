using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titulo_pulse : MonoBehaviour
{
	public float limite_pulse = .2f;
	public float velocidade_aumento = .01f;


	private RectTransform rectTransform;
	private float x_scale_inicial;
	private bool pode_crescer = true;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        x_scale_inicial = rectTransform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
    	if(pode_crescer){
    		pode_crescer = (rectTransform.localScale.x <= x_scale_inicial + limite_pulse);
        	rectTransform.localScale += new Vector3(velocidade_aumento, velocidade_aumento, 0);
    	}else{
    		pode_crescer = (rectTransform.localScale.x <= x_scale_inicial);
        	rectTransform.localScale -= new Vector3(velocidade_aumento, velocidade_aumento, 0);
    	}
    }
}
