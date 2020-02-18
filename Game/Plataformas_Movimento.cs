using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas_Movimento : MonoBehaviour
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
		vel_plat = transform.parent.GetComponent<Plataformas_Spawn_Destroy>().vel;     
        transform.Translate(new Vector3(-vel_plat * Time.deltaTime, 0, 0), Space.Self);
    }
}
