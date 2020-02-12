using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateScript : MonoBehaviour {

    public GameObject r_Gate;
    public GameObject l_Gate;

    void Start () {
		
	}

    private void OnTriggerEnter(Collider other) {
        r_Gate.transform.DOLocalRotate(new Vector3(0, 75, 0), 3.5f, RotateMode.Fast);//60
        //l_Gate.transform.DORotate(new Vector3(0, -60, 0), 0.5f, RotateMode.Fast);//-60
        l_Gate.transform.DOLocalRotate(new Vector3(0, -75, 0), 3.5f, RotateMode.Fast);//-60
    }
}
