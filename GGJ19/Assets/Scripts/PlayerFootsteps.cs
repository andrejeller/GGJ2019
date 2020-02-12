using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {
    
    private Rigidbody myBody;
    private float distanceToGround;

    public AudioClip audioClipWalk;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClipWalk;
   	}

	// Update is called once per frame
	void Update () {

        if ( myBody.velocity.magnitude > 1 && !audioSource.isPlaying ) {
            audioSource.volume = Random.Range( 0.4f, 0.6f );
            audioSource.pitch = Random.Range( 0.8f, 1f );
            audioSource.Play();
        }
	}
}