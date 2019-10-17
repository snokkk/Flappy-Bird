using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;        
    }
}
