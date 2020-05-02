using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorPrototype
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] float rotateSpeed;
        [SerializeField] bool rotateX, rotateY, rotateZ;

        // Update is called once per frame
        void Update()
        {
            if (rotateX)
                transform.Rotate(rotateSpeed * Time.deltaTime, transform.rotation.y, transform.rotation.z);
            if (rotateY)
                transform.Rotate(transform.rotation.x, rotateSpeed * Time.deltaTime, transform.rotation.z);
            if (rotateZ)
                transform.Rotate(transform.rotation.x, transform.rotation.y, rotateSpeed * Time.deltaTime);
        }
    }
}