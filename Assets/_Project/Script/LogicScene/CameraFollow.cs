using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void LateUpdate()
    {     
        transform.position = new Vector3 (playerController.transform.position.x, playerController.transform.position.y,transform.position.z);
    }
}
