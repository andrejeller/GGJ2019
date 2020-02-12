using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintSystem : MonoBehaviour {


    Vector3 playerInitialPos;
    Vector3 playerLastPos;

    public GameObject leftFoot;
    public GameObject rightFoot;

    bool foot = true; 

    void Start () {
        playerInitialPos = transform.position;
    }
	
	
	void Update () {
        playerLastPos = transform.position;

        float dist = Vector3.Distance(playerInitialPos, playerLastPos);

        if(dist > 2f) {
            if(foot) {
                Instantiate(leftFoot, playerInitialPos - new Vector3(0.6f, 0.4f, 0), transform.rotation * Quaternion.Euler(90, 0, 0));
            } else {
                Instantiate(rightFoot, playerInitialPos - new Vector3(-0.6f, 0.4f, 0), transform.rotation * Quaternion.Euler(90, 0, 0));
            }
            playerInitialPos = playerLastPos;
            foot = !foot;
        }
    }
}
