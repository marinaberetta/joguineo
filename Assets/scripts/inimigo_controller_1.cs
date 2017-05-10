using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo_controller_1 : MonoBehaviour {
    public float aux_speed = 2f;
    public float vida = 1;

    public float tempoVivo = 0;
    public int pontos_que_o_inimigo_da = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        tempoVivo += Time.deltaTime;
        if (tempoVivo > 6)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.down * aux_speed * Time.deltaTime);
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tiro")
        {
            Destroy(other.gameObject);

            ((Space_Ship_Controller)((GameObject)GameObject.FindGameObjectWithTag("Jogador")).GetComponent("Space_Ship_Controller")).pontuacao = ((Space_Ship_Controller)((GameObject)GameObject.FindGameObjectWithTag("Jogador")).GetComponent("Space_Ship_Controller")).pontuacao+pontos_que_o_inimigo_da;

            vida -= 1;
        }
    }
}
