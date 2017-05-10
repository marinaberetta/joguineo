using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Ship_Controller : MonoBehaviour {

    public float aux_speed = 5.0f;
    public GameObject tiro_obj = null;
    public float intervalo_tiros = 0.8f;
    private float tempodesdeultimotiro = 0;

    public int pontuacao = 0;

	// Use this for initialization
	void Start () {
        tempodesdeultimotiro = intervalo_tiros+1;
        pontuacao = 0;
    }
	
	// Update is called once per frame
	void Update () {

        getClickToMove();
        tempodesdeultimotiro += Time.deltaTime;

    }

    void getClickToMove()
    {
        if (Input.GetKey(KeyCode.W))
            if (transform.position.y < 9)
                transform.Translate(Vector3.up * aux_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            if(transform.position.y>1)
                transform.Translate(Vector3.down * aux_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            if (transform.position.x < 9)
                transform.Translate(Vector3.right * aux_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            if (transform.position.x > -9)
                transform.Translate(Vector3.left * aux_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
            atira();
    }


    void atira()
    {
        if (tempodesdeultimotiro > intervalo_tiros)
        {
            Instantiate(tiro_obj, transform.position + Vector3.up*1.1f, Quaternion.identity);
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
