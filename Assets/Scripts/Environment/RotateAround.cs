using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.down, moveSpeed * Time.deltaTime); 
    }
}
