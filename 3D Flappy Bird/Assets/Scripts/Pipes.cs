using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Pipes : MonoBehaviour
{
    [Header("Pipes")]
    public float pipeDistance = 3f;
    public GameObject pipePrefab;
    public float pipeSpeed = 10f;

    SphereCollider madeItThroughCollider;

    private void Awake()
    {
        madeItThroughCollider = GetComponent<SphereCollider>();
        madeItThroughCollider.radius = pipeDistance/Mathf.PI;

        GameObject bottomPipe = Instantiate(pipePrefab,transform);
        GameObject topPipe = Instantiate(pipePrefab,transform);

        bottomPipe.transform.position = transform.position + Vector3.down * pipeDistance;

        topPipe.transform.position = transform.position + Vector3.up * pipeDistance;
        topPipe.transform.Rotate(Vector3.forward * 180f);
    }

    private void Update()
    {
        if(transform.position.x <= -100f)
        {
            Destroy(gameObject);
        }
        transform.Translate(-transform.right * pipeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null)
            {
                playerController.AddScore();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + Vector3.up * pipeDistance, .2f);
        Gizmos.DrawSphere(transform.position + Vector3.down * pipeDistance, .2f);
    }
}
