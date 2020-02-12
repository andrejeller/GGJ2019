using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour {

    private Rigidbody myBody;
    float _moveSpeed = 10.0f;
    Vector2 moveVector;

    
    public Transform frontVector { get { return front; } set { front = value; } }
    private Transform front;

    public Quaternion rotat { get { return rot; } set { rot = value; } }
    private Quaternion rot;

    void Start () {
        myBody = GetComponent<Rigidbody>();
	}

    private void FixedUpdate() {
        
        myBody.velocity = transform.forward * moveVector.y * 10;
        transform.rotation = new Quaternion(transform.rotation.x, rot.y, transform.rotation.z, rot.w);
        
    }

    void Update () {
        Debug.Log("Front - " + front);
        
        //O que melhor funcionou
        //Quaternion target = Quaternion.Euler(0, front.rotation.y * 140, 0);
        //transform.rotation = target;

        

        moveVector.y = Input.GetAxis("Vertical");
        moveVector.x = Input.GetAxis("Horizontal");
    }
}
