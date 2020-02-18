using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invasora_Spawn : MonoBehaviour
{
	public GameObject plat_invade;
	public GameObject player_score;

	int launch_plataforma_invad;
	bool spawn_plat_invade;
    // Start is called before the first frame update
    void Start()
    {
        spawn_plat_invade = true;
        launch_plataforma_invad = 10;
    }

    // Update is called once per frame
    void Update()
    {
    	float spawn_invasor = Random.Range(0, 100);
		int score = player_score.GetComponent<Player>().contador_moedas;

        if(score == launch_plataforma_invad){
			if(spawn_plat_invade){
				float y_random = Random.Range(0, 1);
				float y_plat_invade;

				if(y_random < .5f){
					y_plat_invade = .3f;
				}else{
					y_plat_invade = 1 + .3f;
				}
				Instantiate(plat_invade, new Vector2(32, y_plat_invade), Quaternion.identity, this.transform);
				spawn_plat_invade = false;
				launch_plataforma_invad += 10;
			}
		}else{
			spawn_plat_invade = true;
		}
    }
}
