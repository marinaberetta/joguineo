using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_controller : MonoBehaviour {

    public int ISHOLDER = 0;


    public float aux_speed = 5.0f;
    public GameObject tiro_obj = null;
    public float intervalo_tiros = 0.5f;
    private float tempodesdeultimotiro = 0;
    public int pontuacao = 0;

    public float maxTempoVida = 5;
    public float tempoVidaAtual = 0;


    public float v_01       = 0f;
    public float v_02       = 0f;
    public float v_03       = 0f;
    public float v_04       = 0f;
    public float v_05       = 0f;
    public float v_06       = 0f;
    public float v_07       = 0f;
    public float v_08       = 0f;
    public float v_09       = 0f;
    public float v_10       = 0f;
    public float v_11       = 0f;
    public float v_12       = 0f;
    public float v_13       = 0f;
    public float aux_mov1   = 0f;
    public float v_21       = 0f;
    public float v_22       = 0f;
    public float v_23       = 0f;
    public float v_24       = 0f;
    public float v_25       = 0f;
    public float v_26       = 0f;
    public float v_27       = 0f;
    public float v_28       = 0f;
    public float v_29       = 0f;
    public float v_30       = 0f;
    public float v_31       = 0f;
    public float v_32       = 0f;
    public float v_33       = 0f;
    public float aux_mov2   = 0f;
    public float v_41       = 0f;
    public float v_42       = 0f;
    public float v_43       = 0f;
    public float v_44       = 0f;
    public float v_45       = 0f;
    public float v_46       = 0f;
    public float v_47       = 0f;
    public float v_48       = 0f;
    public float v_49       = 0f;
    public float v_50       = 0f;
    public float v_51       = 0f;
    public float v_52       = 0f;
    public float v_53       = 0f;
    public float aux_mov3   = 0f;
    public float v_61       = 0f;
    public float v_62       = 0f;
    public float v_63       = 0f;
    public float v_64       = 0f;
    public float v_65       = 0f;
    public float v_66       = 0f;
    public float v_67       = 0f;
    public float v_68       = 0f;
    public float v_69       = 0f;
    public float v_70       = 0f;
    public float v_71       = 0f;
    public float v_72       = 0f;
    public float v_73       = 0f;
    public float aux_atira  = 0f;

    void Start ()
    {
        tempodesdeultimotiro = intervalo_tiros + 1;
        pontuacao = 0;



    }
	
	void Update ()
    {
        if (ISHOLDER == 1) return;

        tempoVidaAtual += Time.deltaTime;
        maxTempoVida = 5 + 2 * pontuacao;

        if (tempoVidaAtual >= maxTempoVida)
        {
            Destroy(gameObject);
        }

        print(pontuacao);
        tempodesdeultimotiro += Time.deltaTime;
        tryActions();
    }

    void tryActions()
    {
        if (ISHOLDER == 1) return;
        int difx_a = 0;
        int difx_b = 0;
        int difx_c = 0;
        int difx_d = 0;
        float difX = 0;
        if (GameObject.FindGameObjectWithTag("Jogador") != null) // calcula infos do player
        {
            Vector3 jogador_pos = GameObject.FindGameObjectWithTag("Jogador").transform.position;
            difX = jogador_pos.x - transform.position.x;
            if (difX < 0) difX *= -1;
            if (difX < 1.0) difx_a = 1;
            if (difX < 0.7) difx_b = 1;
            if (difX < 0.4) difx_c = 1;
            if (difX < 0.1) difx_d = 1;
        }





        var inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        int difx_aa = 0;
        int difx_bb = 0;
        int difx_cc = 0;
        int difx_dd = 0;
        int dify_aa = 0;
        int dify_bb = 0;
        int dify_cc = 0;
        int dify_dd = 0;
        int dify_ee = 0;
        float minDistancia = 0;
        if (inimigos.Length > 0)
        {
            minDistancia = Vector3.Distance(transform.position, inimigos[0].transform.position);
            GameObject minDistanciaInimigo = inimigos[0];
            foreach (GameObject inimigo in inimigos)
            {
                float d = Vector3.Distance(transform.position, inimigo.transform.position);
                if (d < minDistancia)
                {
                    minDistancia = d;
                    minDistanciaInimigo = inimigo;
                }
            }
            difX = minDistanciaInimigo.transform.position.x - transform.position.x;
            if (difX < 0) difX *= -1;

            if (difX < 1.0) difx_aa = 1;
            if (difX < 0.7) difx_bb = 1;
            if (difX < 0.4) difx_cc = 1;
            if (difX < 0.1) difx_dd = 1;
            float difY = minDistanciaInimigo.transform.position.y - transform.position.y;
            if (difY < 0) difY *= -1;
            if (difY < 10) dify_aa = 1;
            if (difY < 8) dify_bb = 1;
            if (difY < 6) dify_cc = 1;
            if (difY < 4) dify_dd = 1;
            if (difY < 2) dify_ee = 1;
        }


        if (
        difx_a * v_01 +
        difx_b * v_02 +
        difx_c * v_03 +
        difx_d * v_04 +
        difx_aa * v_05 +
        difx_bb * v_06 +
        difx_cc * v_07 +
        difx_dd * v_08 +
        dify_aa * v_09 +
        dify_bb * v_10 +
        dify_cc * v_11 +
        dify_dd * v_12 +
        dify_ee * v_13 +
        aux_mov1 >= 0
        )
        {
            vaiCima();
        }
        if (
        difx_a * v_21 +
        difx_b * v_22 +
        difx_c * v_23 +
        difx_d * v_24 +
        difx_aa * v_25 +
        difx_bb * v_26 +
        difx_cc * v_27 +
        difx_dd * v_28 +
        dify_aa * v_29 +
        dify_bb * v_30 +
        dify_cc * v_31 +
        dify_dd * v_32 +
        dify_ee * v_33 +
        aux_mov2 >= 0
        )
        {
            vaiDireita();
        }
        if (
        difx_a  * v_41 +
        difx_b  * v_42 +
        difx_c  * v_43 +
        difx_d  * v_44 +
        difx_aa * v_45 +
        difx_bb * v_46 +
        difx_cc * v_47 +
        difx_dd * v_48 +
        dify_aa * v_49 +
        dify_bb * v_50 +
        dify_cc * v_51 +
        dify_dd * v_52 +
        dify_ee * v_53 +
        aux_mov3 >= 0
        )
        {
            vaiEsquerda();
        }
        if (
        difx_a  * v_61 +
        difx_b  * v_62 +
        difx_c  * v_63 +
        difx_d  * v_64 +
        difx_aa * v_65 +
        difx_bb * v_66 +
        difx_cc * v_67 +
        difx_dd * v_68 +
        dify_aa * v_69 +
        dify_bb * v_70 +
        dify_cc * v_71 +
        dify_dd * v_72 +
        dify_ee * v_73 +
        aux_atira >= 0
        )
        {
            atira();
        }
    }



    void vaiCima()
    {
        if (ISHOLDER == 1) return;
        if (transform.position.y < 0) return;
        transform.Translate(Vector3.up * aux_speed * Time.deltaTime);
    }

    void vaiBaixo()
    {
        if (ISHOLDER == 1) return;
        if (transform.position.y < 0) return;
        transform.Translate(Vector3.down * aux_speed * Time.deltaTime);
    }
    void vaiDireita()
    {
        if (transform.position.y < 0) return;
        if (ISHOLDER == 1) return;
        if (transform.position.x < 9)
            transform.Translate(Vector3.right * aux_speed * Time.deltaTime);
    }
    void vaiEsquerda()
    {
        if (transform.position.y < 0) return;
        if (ISHOLDER == 1) return;
        if (transform.position.x > -9)
            transform.Translate(Vector3.left * aux_speed * Time.deltaTime);
    }


    void atira()
    {
        if (ISHOLDER == 1) return;
        if (transform.position.y < 0) return;

        
            if (tempodesdeultimotiro > intervalo_tiros)
            {
                GameObject tiro = Instantiate(tiro_obj, transform.position + Vector3.up * 1.1f, Quaternion.identity);
                tiro t = (tiro)tiro.GetComponent("tiro");
                t.isFromPlayer = 0;
                tempodesdeultimotiro = 0;
            }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (ISHOLDER == 1) return;
        if (other.tag == "Inimigo")
        {
            Destroy(gameObject);
        }
    }

    public void variar(ai_controller bkp)
    {
        if (ISHOLDER == 1) return;
        print(bkp);
        v_01     = bkp.v_01      +Random.Range(-0.5f, 0.5f);
        v_02     = bkp.v_02      +Random.Range(-0.5f,0.5f);
        v_03     = bkp.v_03      +Random.Range(-0.5f,0.5f);
        v_04     = bkp.v_04      +Random.Range(-0.5f,0.5f);
        v_05     = bkp.v_05      +Random.Range(-0.5f,0.5f);
        v_06     = bkp.v_06      +Random.Range(-0.5f,0.5f);
        v_07     = bkp.v_07      +Random.Range(-0.5f,0.5f);
        v_08     = bkp.v_08      +Random.Range(-0.5f,0.5f);
        v_09     = bkp.v_09      +Random.Range(-0.5f,0.5f);
        v_10     = bkp.v_10      +Random.Range(-0.5f,0.5f);
        v_11     = bkp.v_11      +Random.Range(-0.5f,0.5f);
        v_12     = bkp.v_12      +Random.Range(-0.5f,0.5f);
        v_13     = bkp.v_13      +Random.Range(-0.5f,0.5f);
        aux_mov1 = bkp.aux_mov1  +Random.Range(-0.5f,0.5f);
        v_21     = bkp.v_21      +Random.Range(-0.5f,0.5f);
        v_22     = bkp.v_22      +Random.Range(-0.5f,0.5f);         
        v_23     = bkp.v_23      +Random.Range(-0.5f,0.5f);
        v_24     = bkp.v_24      +Random.Range(-0.5f,0.5f);
        v_25     = bkp.v_25      +Random.Range(-0.5f,0.5f);
        v_26     = bkp.v_26      +Random.Range(-0.5f,0.5f);
        v_27     = bkp.v_27      +Random.Range(-0.5f,0.5f);
        v_28     = bkp.v_28      +Random.Range(-0.5f,0.5f);
        v_29     = bkp.v_29      +Random.Range(-0.5f,0.5f);
        v_30     = bkp.v_30      +Random.Range(-0.5f,0.5f);
        v_31     = bkp.v_31      +Random.Range(-0.5f,0.5f);
        v_32     = bkp.v_32      +Random.Range(-0.5f,0.5f);
        v_33     = bkp.v_33      +Random.Range(-0.5f,0.5f);
        aux_mov2 = bkp.aux_mov2  +Random.Range(-0.5f,0.5f);
        v_41     = bkp.v_41      +Random.Range(-0.5f,0.5f);
        v_42     = bkp.v_42      +Random.Range(-0.5f,0.5f);
        v_43     = bkp.v_43      +Random.Range(-0.5f,0.5f);
        v_44     = bkp.v_44      +Random.Range(-0.5f,0.5f);
        v_45     = bkp.v_45      +Random.Range(-0.5f,0.5f);
        v_46     = bkp.v_46      +Random.Range(-0.5f,0.5f);
        v_47     = bkp.v_47      +Random.Range(-0.5f,0.5f);
        v_48     = bkp.v_48      +Random.Range(-0.5f,0.5f);
        v_49     = bkp.v_49      +Random.Range(-0.5f,0.5f);
        v_50     = bkp.v_50      +Random.Range(-0.5f,0.5f);
        v_51     = bkp.v_51      +Random.Range(-0.5f,0.5f);
        v_52     = bkp.v_52      +Random.Range(-0.5f,0.5f);
        v_53     = bkp.v_53      +Random.Range(-0.5f,0.5f);
        aux_mov3 = bkp.aux_mov3  +Random.Range(-0.5f,0.5f);
        v_61     = bkp.v_61      +Random.Range(-0.5f,0.5f);
        v_62     = bkp.v_62      +Random.Range(-0.5f,0.5f);
        v_63     = bkp.v_63      +Random.Range(-0.5f,0.5f);
        v_64     = bkp.v_64      +Random.Range(-0.5f,0.5f);
        v_65     = bkp.v_65      +Random.Range(-0.5f,0.5f);
        v_66     = bkp.v_66      +Random.Range(-0.5f,0.5f);
        v_67     = bkp.v_67      +Random.Range(-0.5f,0.5f);
        v_68     = bkp.v_68      +Random.Range(-0.5f,0.5f);
        v_69     = bkp.v_69      +Random.Range(-0.5f,0.5f);
        v_70     = bkp.v_70      +Random.Range(-0.5f,0.5f);
        v_71     = bkp.v_71      +Random.Range(-0.5f,0.5f);
        v_72     = bkp.v_72      +Random.Range(-0.5f,0.5f);
        v_73     = bkp.v_73      +Random.Range(-0.5f,0.5f);
        aux_atira = bkp.aux_atira + Random.Range(-0.5f, 0.5f);
        pontuacao = 0;
    }

    public void setValues(ai_controller bkp)
    {
        if (ISHOLDER != 1) return;
        print(bkp);
        v_01 = bkp.v_01 ;
        v_02 = bkp.v_02 ;
        v_03 = bkp.v_03 ;
        v_04 = bkp.v_04 ;
        v_05 = bkp.v_05 ;
        v_06 = bkp.v_06 ;
        v_07 = bkp.v_07 ;
        v_08 = bkp.v_08 ;
        v_09 = bkp.v_09 ;
        v_10 = bkp.v_10 ;
        v_11 = bkp.v_11 ;
        v_12 = bkp.v_12 ;
        v_13 = bkp.v_13 ;
        aux_mov1 = bkp.aux_mov1 ;
        v_21 = bkp.v_21 ;
        v_22 = bkp.v_22 ;
        v_23 = bkp.v_23 ;
        v_24 = bkp.v_24 ;
        v_25 = bkp.v_25 ;
        v_26 = bkp.v_26 ;
        v_27 = bkp.v_27 ;
        v_28 = bkp.v_28 ;
        v_29 = bkp.v_29 ;
        v_30 = bkp.v_30 ;
        v_31 = bkp.v_31 ;
        v_32 = bkp.v_32 ;
        v_33 = bkp.v_33 ;
        aux_mov2 = bkp.aux_mov2;
        v_41 = bkp.v_41 ;
        v_42 = bkp.v_42 ;
        v_43 = bkp.v_43 ;
        v_44 = bkp.v_44 ;
        v_45 = bkp.v_45 ;
        v_46 = bkp.v_46 ;
        v_47 = bkp.v_47 ;
        v_48 = bkp.v_48 ;
        v_49 = bkp.v_49 ;
        v_50 = bkp.v_50 ;
        v_51 = bkp.v_51 ;
        v_52 = bkp.v_52 ;
        v_53 = bkp.v_53 ;
        aux_mov3 = bkp.aux_mov3 ;
        v_61 = bkp.v_61;
        v_62 = bkp.v_62;
        v_63 = bkp.v_63;
        v_64 = bkp.v_64;
        v_65 = bkp.v_65;
        v_66 = bkp.v_66;
        v_67 = bkp.v_67;
        v_68 = bkp.v_68;
        v_69 = bkp.v_69;
        v_70 = bkp.v_70;
        v_71 = bkp.v_71;
        v_72 = bkp.v_72;
        v_73 = bkp.v_73;
        aux_atira = bkp.aux_atira;
        pontuacao = bkp.pontuacao;
    }
}
