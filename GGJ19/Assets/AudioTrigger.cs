using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {

    public AudioSource audioData;
    bool play = true;
	


    private void OnTriggerEnter(Collider other) {
        if(play) {
            audioData.Play(0);
            play = false;
        }
        
    }
}
