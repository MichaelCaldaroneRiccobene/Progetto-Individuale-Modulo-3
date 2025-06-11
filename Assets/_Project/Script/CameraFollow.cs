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
        if(playerController == null) return;
        Vector3 posTarget = playerController.transform.position;
        posTarget.z = transform.position.z;

        transform.position = posTarget;
    }
}
