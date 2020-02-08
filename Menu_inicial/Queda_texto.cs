using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Queda_texto : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public float queda_y_text = 2;

	private Vector2 posicao_inicial_text;
	private RectTransform rec;

	void Start(){
		posicao_inicial_text = transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition;
	}

	// Update is called once per frame
	void Update()
	{
		if (ispressed)
			transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(posicao_inicial_text.x, posicao_inicial_text.y - queda_y_text);
		else{
			transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = posicao_inicial_text;
		}

	}

	bool ispressed = false;
	public void OnPointerDown(PointerEventData eventData){
	 	ispressed = true;
	}

	public void OnPointerUp(PointerEventData eventData){
		ispressed = false;
	}
}
