using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aguia : MonoBehaviour
{
	[SerializeField]float forca_x;
	Rigidbody2D rb_aguia;

    // Start is called before the first frame update
    void Start()
    {
        rb_aguia = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(forca_x < 7){
    		forca_x = .4f * transform.parent.GetComponent<Inimigos_Spawn_Destroy>().vel;
    	}

     	rb_aguia.AddForce(new Vector2(-forca_x, 0));   
    }
}
