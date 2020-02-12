using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOverScript : MonoBehaviour {    

    private void OnTriggerEnter(Collider other) {

        Pvr_UnitySDKEye [] eyes = FindObjectsOfType<Pvr_UnitySDKEye>();

        for(int i = 0; i<eyes.Length; i++) {
            eyes[i].FadeIn();
        }
        Invoke("LoadCredits", 2.95f);        
    }

    private void LoadCredits() {
        SceneLoader.instance.LoadCredts();
    }
}
