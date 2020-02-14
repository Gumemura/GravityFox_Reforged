using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public GameObject velocidade_global;

	BoxCollider2D boxcollider_coin;

	float vel_coin;

    // Start is called before the first frame update
    void Start()
    {
		boxcollider_coin = GetComponent<BoxCollider2D>();        
    }

    // Update is called once per frame
    void Update()
    {
    	vel_coin = velocidade_global.GetComponent<Velocidade_global>().velocidade;     
        transform.Translate(new Vector3(-vel_coin * Time.deltaTime, 0, 0), Space.Self);

        // if(boxcollider_coin.IsTouchingLayers()){
        // 	Destroy(gameObject);
        // }
    }
}
