using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public static event Action<Bubble> Collided;
    public float speed = 10f;
    Vector3 dir;
    void OnTriggerEnter(Collider other)
    {
        Bubble b = other.gameObject.GetComponent<Bubble>();
        if(b != null)
        {
            Collided?.Invoke(this);
            
        }
    }

    void Update()
    {
        transform.position += dir * Time.deltaTime;
    }
    public void Init(Vector3 dir)
    {
        this.dir = dir;
    }
}
