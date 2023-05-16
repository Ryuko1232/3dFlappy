using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] GameObject pipesPrefab;
    [SerializeField] Transform spawnTransform;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float spawnYMin = 1f;
    [SerializeField] float spawnYMax = 30f;

    private void Start()
    {
        if(spawnTransform == null)
        {
            spawnTransform = transform;
        }

        SpawnPipes();
    }

    void SpawnPipes()
    {
        float randomY = Random.Range(spawnYMin, spawnYMax);
        GameObject pipes = Instantiate(pipesPrefab);
        pipes.transform.position = spawnTransform.position + new Vector3(spawnTransform.position.x,randomY,spawnTransform.position.z);
        StartCoroutine(SpawnPipesConstantly());
    }

    IEnumerator SpawnPipesConstantly()
    {
        yield return new WaitForSeconds(spawnInterval);
        SpawnPipes();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + transform.up * spawnYMin, .3f);
        Gizmos.DrawSphere(transform.position + transform.up * spawnYMax, .3f);
    }
}
