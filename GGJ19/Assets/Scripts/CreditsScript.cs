using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreditsScript: MonoBehaviour {


    private bool canMove = true;

    [Header("Botoes")]
    private int btn_in = 0;
    public GameObject[] btns;


    private void Start() {
        UpdateButtons();
    }

    private void Update() {

        if (canMove) {
            if (Input.GetAxis("Horizontal") > 0) {
                Debug.Log(btn_in);
                btn_in++;
                UpdateButtons();
            } else if (Input.GetAxis("Horizontal") < 0) {
                btn_in--;
                UpdateButtons();
            }


            if (Input.GetButtonDown("Fire1")) {
                switch (btn_in) {
                    case 0:
                        SceneLoader.instance.LoadMainMenu();
                        break;
                    case 1:
                        Debug.Log("Sair");
                        SceneLoader.instance.QuitGame();
                        break;
                }
            }
            
        }
        
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

}
