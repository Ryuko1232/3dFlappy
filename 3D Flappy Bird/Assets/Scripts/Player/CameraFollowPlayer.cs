using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float distanceFromPlayer = 10f;

    private void LateUpdate()
    {
        transform.position = player.transform.position + Vector3.forward * -distanceFromPlayer;
        transform.LookAt(player.transform.position);
    }
}
