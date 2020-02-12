using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour {

    public Transform target;
    public Transform head;

    private float distance = 3.6f;
    private float height = 1f;

    private float damping = 8f;
    private float rotationDamping = 7f;

    private PlayerMovement player;
    private Pvr_UnitySDKEyeManager pvr;
    private void Start() {
        player = target.gameObject.GetComponent<PlayerMovement>();
        pvr = FindObjectOfType<Pvr_UnitySDKEyeManager>();
    }

    private void Update() {
        player.rotat = head.rotation;
    }

    void FixedUpdate() {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
    }
}
