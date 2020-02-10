using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Transicao : MonoBehaviour
{
	Transform top;
	Transform bot;

	public float bot_y;
	public float top_y;

	public float vel_trans;

	bool top_ok;
	bool bot_ok;


    // Start is called before the first frame update
    void Start()
    {
        bot = transform.Find("bot");
        top = transform.Find("top");

        bot_ok = false;
        top_ok = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(bot.position.y < bot_y){
        	bot.Translate(new Vector3(0, vel_trans * Time.deltaTime, 0), Space.Self);
        }else{
        	bot_ok = true;
        }

        if(top.position.y > top_y){
        	top.Translate(new Vector3(0, vel_trans * Time.deltaTime * -1, 0), Space.Self);
        }else{
        	top_ok = true;
        }

        if(bot_ok && top_ok){
        	troca_cena();
        }
    }

    void troca_cena(){
		SceneManager.LoadScene("Game");
		bot_ok = false;
        top_ok = false;
    }
}
