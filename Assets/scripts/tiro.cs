using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour {


    public int tiro_sobe_desce = 0;
    public float aux_speed = 1;

    public float tempoVivo = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        tempoVivo += Time.deltaTime;

        if (tempoVivo > 6)
        {
            Destroy(gameObject);
        }

        if (tiro_sobe_desce == 0)
        {
            transform.Translate(Vector3.up * aux_speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * aux_speed * Time.deltaTime);
        }
        transform.rotation = new Quaternion(0, 0, 0, 0);
	}


    void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
    }
}
