using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_controller : MonoBehaviour {

    public float aux_speed = 5.0f;
    public GameObject tiro_obj = null;
    public float intervalo_tiros = 0.5f;
    private float tempodesdeultimotiro = 0;
    public int pontuacao = 0;



    void Start () {
		
	}
	
	void Update () {

    }



    void vaiCima()
    {
        if (transform.position.y < 9)
            transform.Translate(Vector3.up * aux_speed * Time.deltaTime);
    }

    void vaiBaixo()
    {
        if (transform.position.y > 1)
            transform.Translate(Vector3.down * aux_speed * Time.deltaTime);
    }
    void vaiDireita()
    {
        if (transform.position.x < 9)
            transform.Translate(Vector3.right * aux_speed * Time.deltaTime);
    }
    void vaiEsquerda()
    {
        if (transform.position.x > -9)
            transform.Translate(Vector3.left * aux_speed * Time.deltaTime);
    }


    void atira()
    {
        if (tempodesdeultimotiro > intervalo_tiros)
        {
            Instantiate(tiro_obj, transform.position + Vector3.up * 1.1f, Quaternion.identity);
            tempodesdeultimotiro = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Inimigo")
        {
            Destroy(gameObject);
        }
    }
}
