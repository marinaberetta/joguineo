using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class scene_controller : MonoBehaviour {

    public GameObject player_obj = null;
    public GameObject inimigo1_obj = null;
    public GameObject inimigo2_obj = null;
    public GameObject pl = null;
    public int pontuacao_maxima = 0;
    public float tempo_atual = 0;
    public InputField nome = null;
    public InputField senha = null;
    public GameObject menu = null;



    private int tipoInimigo = 0;


    void Start () {
		pl = Instantiate(player_obj, new Vector3(0,1,0) , Quaternion.identity);
        menu.SetActive(false);
        pontuacao_maxima = 0;
        tempo_atual = 0;
        tipoInimigo = 0;
    }
	



	void Update () {

        GameObject inimigo_usando = null;

        if (tipoInimigo == 0)
        {
            inimigo_usando = inimigo1_obj;
        }
        else if (tipoInimigo == 1)
        {
            inimigo_usando = inimigo2_obj;
        }

            if (GameObject.FindGameObjectWithTag("Jogador") == null) return;

        tempo_atual += Time.deltaTime;


        if (tempo_atual > 5)
        {
            linhaInimigo(inimigo_usando);
            tempo_atual = 0;
            tipoInimigo = 1;
        }
    }


    void linhaInimigo(GameObject tipoInimigo)
    {
        for (float i = -10; i < 10; i += (tipoInimigo.transform.localScale.x) + 0.1f)
        {
            Instantiate(tipoInimigo, new Vector3(i, 12, 0), Quaternion.identity);
        }
    }



    void OnGUI()
    {
        if ((GameObject)GameObject.FindGameObjectWithTag("Jogador") != null){
            if (((Space_Ship_Controller)((GameObject)GameObject.FindGameObjectWithTag("Jogador")).GetComponent("Space_Ship_Controller")).pontuacao > pontuacao_maxima)
            {
                menu.SetActive(false);
                pontuacao_maxima = ((Space_Ship_Controller)((GameObject)GameObject.FindGameObjectWithTag("Jogador")).GetComponent("Space_Ship_Controller")).pontuacao;
            }
        }else
        {
            menu.SetActive(true);
            if (GUI.Button(new Rect(50, 200, 50, 50), "Enviar"))
                enviaPontuacao();
        }

        GUI.Label(new Rect(50, 20, 100, 20), "Pontuação: "+pontuacao_maxima);
    }

    void enviaPontuacao()
    {
        var url = "http://localhost/api.php";
        WWWForm form = new WWWForm();
        form.AddField("nome", nome.text);
        form.AddField("senha", senha.text);
        form.AddField("pontuacao", pontuacao_maxima);
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        
        if (www.error == null)
        {
            Start();
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
