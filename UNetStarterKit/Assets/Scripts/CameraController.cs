using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    static public Transform player;
    static private PlayerController playerController;

    void Update ()
    {
        if (player && !player.GetComponent<PlayerController>().stopCamera)
        {
            transform.SetPositionAndRotation(player.position + new Vector3(0.0f, 5.0f, -5.0f), Quaternion.identity);
            transform.LookAt(player.position + new Vector3(0.0f, 2.0f, 0.0f), Vector3.up);
        }
	}
}