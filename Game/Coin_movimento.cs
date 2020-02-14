using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_movimento : MonoBehaviour
{
	public GameObject velocidade_global;

	float vel_plat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		vel_plat = velocidade_global.GetComponent<Velocidade_global>().velocidade;     
        transform.Translate(new Vector3(-vel_plat * Time.deltaTime, 0, 0), Space.Self);
    }
}
