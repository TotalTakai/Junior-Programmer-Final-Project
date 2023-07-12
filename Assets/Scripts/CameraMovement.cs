using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const float cameraPosZ = -10f;
    private const float cameraPosY = 4f;
    private const float cameraXDiff = 8f;

    [SerializeField] GameObject player;

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + cameraXDiff, cameraPosY, cameraPosZ);
    }
}
