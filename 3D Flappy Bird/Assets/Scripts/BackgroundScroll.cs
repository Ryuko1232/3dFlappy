using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 5f;
    private void Update()
    {
        if (transform.position.x <= -100f)
        {
            transform.position = new Vector3(0f,20f,5f);
        }
        transform.Translate(transform.right * -scrollSpeed * Time.deltaTime);
    }
}
