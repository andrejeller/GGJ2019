using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NavigateMenu : MonoBehaviour {

    public GameObject[] btns;

    private int btn_in = 0;
    public int BotaoEscolhido { get { return btn_in; } }

    private bool canMove = true;


    private void Start() {
        UpdateButtons();
    }

    private void Update() {
        if(canMove) {
            if(Input.GetAxis("Vertical") > 0) {
                btn_in--;
                UpdateButtons();
            } else if(Input.GetAxis("Vertical") < 0) {
                btn_in++;
                UpdateButtons();
            }

            Debug.Log(btn_in);
            StartCoroutine(count());
        }
    }


    private void UpdateButtons() {
        if(btn_in < 0) btn_in = 0;
        if(btn_in > 2) btn_in = 2;

        for(int i = 0; i < 3; i++) {
            if(i == btn_in)
                ChangeSize(i, 1.2f);
            else
                ChangeSize(i, 0.9f);
        }
    }

    private void ChangeSize(int id, float size) {
        btns[id].transform.DOScale(size, 0.3f);
    }

    IEnumerator count() {
        canMove = false;
        yield return new WaitForSeconds(0.05f);
        canMove = true;
    }

}
