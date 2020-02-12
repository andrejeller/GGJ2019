using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopMenu: MonoBehaviour {

    //Script para controlar o POP-MENU

    public static PopMenu Instance { get; private set; }

    private float PopTime = 0.15f;
    private bool isActive;
    public GameObject MenuPanel;

    private bool canMove = true;
    private bool canPop = true;

    [Header("Botoes")]
    private int btn_in = 0;
    public GameObject[] btns;

    private void Awake() {
        /*
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        */
    }
    private void Start() {

        //Debug.Log(controlls.descriptiveName);
        isActive = false;
        MenuPanel.SetActive(true);
        MenuPanel.transform.localScale = new Vector3(0, 0, 0);
        //  AssignAllJoysticksToSystemPlayer(true);
    }

    private void Update() {
        if (Input.GetButtonDown("OpenMenu")) {
            Debug.Log("so vai");
            if (!isActive && canPop) {
                Time.timeScale = 0.01f;//Pausa o Jogo
                //EvSysManager.Instance.es.SetSelectedGameObject(MenuPanel.GetComponentInChildren<Button>().gameObject);
                isActive = true;
                UpdateButtons();
                MenuPanel.transform.DOScale(1, PopTime);
                StartCoroutine(countPop());
            } else if (isActive) {
                Time.timeScale = 1;
                MenuPanel.transform.DOScale(0, PopTime);
                isActive = false;
                StartCoroutine(countPop());
            }

        }
        if (isActive && canMove) {
            if (Input.GetAxis("Vertical") > 0) {
                Debug.Log(btn_in);
                btn_in--;
                UpdateButtons();
            } else if (Input.GetAxis("Vertical") < 0) {
                btn_in++;
                UpdateButtons();
            }
            

            if (Input.GetButtonDown("Fire1")) {
                switch (btn_in) {
                    case 0:
                        SceneLoader.instance.ResetScene();
                        break;
                    case 1:
                        Debug.Log("Sair");
                        SceneLoader.instance.QuitGame();
                        break;
                }
            }

            //Debug.Log(btn_in);
            //  StartCoroutine(countMove());
        }

        /*
        if (controll_0.GetButtonDown("NextScene")) {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            MenuPanel.transform.localScale = new Vector3(0, 0, 0);
        }*/
    }



    private void UpdateButtons() {
        if (btn_in < 0) btn_in = 0;
        if (btn_in > 1) btn_in = 1;

        for (int i = 0; i < 2; i++) {
            if (i == btn_in)
                ChangeSize(i, 1.2f);
            else
                ChangeSize(i, 0.9f);
        }
    }

    private void ChangeSize(int id, float size) {
        btns[id].transform.DOScale(size, 0.3f);
    }

    IEnumerator countMove() {
        canMove = false;
        yield return new WaitForSeconds(0.05f);
        canMove = true;
    }

    IEnumerator countPop() {
        canPop = false;
        yield return new WaitForSeconds(0.5f);
        canPop = true;
    }
}
