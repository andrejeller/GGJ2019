using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour {

    private Rigidbody myBody;
    private float _moveSpeed = 5.8f;
    private float input_moveValue;
    private float input_turnValue;
    
    public Quaternion rotat { get { return rot; } set { rot = value; } }
    private Quaternion rot;
    public GameObject head;

    void Start() {
        myBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        myBody.velocity = transform.forward * input_moveValue * _moveSpeed;
        myBody.velocity += transform.right * input_turnValue * _moveSpeed;
        transform.rotation = new Quaternion(transform.rotation.x, rot.y, transform.rotation.z, rot.w);
        //Turn();
    }

    void Update() {
        input_moveValue = Input.GetAxis("Vertical");
        input_turnValue = Input.GetAxis("Horizontal");

        if (input_turnValue != 0) {
           // Turn();
          //  head.GetComponent<Pvr_UnitySDKHeadTrack>().rotateWithControll = true;
        } else {
           // head.GetComponent<Pvr_UnitySDKHeadTrack>().rotateWithControll = false;
        }

    }

    
    private void Turn() {
        // Determina os graus de rotação baseado no input, velocidade e tempo entre os frames
        float turn = input_turnValue * 20 * Time.deltaTime;


        // Transforma a rotação para o eixo Y
        Quaternion turnRotation;
        //if (input_moveValue == 0) turnRotation = Quaternion.Euler(0f, 0 * turn * 0.5f, 0f);
        //else turnRotation = Quaternion.Euler(0f, turn, 0f);
        turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Aplica a rotação no rigidbody
        //myBody.MoveRotation(myBody.rotation * turnRotation);
        //head.GetComponent<Pvr_UnitySDKHeadTrack>().Rotation = turnRotation;

        //head.transform.localRotation = myBody.rotation * turnRotation;
    }

}
