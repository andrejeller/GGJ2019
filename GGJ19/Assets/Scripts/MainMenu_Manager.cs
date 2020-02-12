using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_Manager: MonoBehaviour {

    [Header("Para Sumir")]
    public GameObject title;
    public GameObject btn_0;
    public GameObject btn_1;
    public GameObject btn_2;

    [Header("Para Aparecer")]
    public Slider load_slide;
    public Text load_txt;
    private LOAD_Script ld;
    private NavigateMenu nm;

    private void Start() {
        title.SetActive(true);
        btn_0.SetActive(true);
        btn_1.SetActive(true);
        btn_2.SetActive(true);
        load_slide.gameObject.SetActive(false);
        load_txt.gameObject.SetActive(false);
        ld = GetComponent<LOAD_Script>();
        nm = GetComponent<NavigateMenu>();
    }


    private void Update() {
        if(Input.GetButtonDown("Fire1")) {
            switch(nm.BotaoEscolhido) {
                case 0:
                    StartGame();
                    break;
                case 1:
                    Debug.Log("Creditos");
                    SceneLoader.instance.LoadCredts();
                    break;
                case 2:
                    Debug.Log("Sair");
                    SceneLoader.instance.QuitGame();
                    break;
            }
        }
          
    }


    public void StartGame() {
        ChangeVisibility();
        ld.StartLoading(load_slide, load_txt, 1);
    }

    public void GoCredts() {
        ChangeVisibility();
        ld.StartLoading(load_slide, load_txt, 1);
    }

    private void ChangeVisibility() {
        title.SetActive(false);
        btn_0.SetActive(false);
        btn_1.SetActive(false);
        btn_2.SetActive(false);
        load_slide.gameObject.SetActive(true);
        load_txt.gameObject.SetActive(true);
    }

}
