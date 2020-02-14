using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public GameObject player;
	

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    	int score = player.GetComponent<Player>().contador_moedas;

    	transform.GetComponent<Text>().text = score.ToString();
    }
}
