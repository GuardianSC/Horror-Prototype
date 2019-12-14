using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorPrototype
{
    public class TriggerSpawnObject : MonoBehaviour
    {
        [SerializeField] private GameObject spawnObject;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private int maxSpawnObjects;
        private int spawnedObjects;

        private void OnTriggerEnter(Collider other)
        {
            if (spawnedObjects < maxSpawnObjects)
            {
                spawnedObjects = spawnedObjects + 1;
                Instantiate(spawnObject, spawnPosition, transform.rotation);
            }                
            //Debug.Log(spawnedObjects);
        }
    }
}