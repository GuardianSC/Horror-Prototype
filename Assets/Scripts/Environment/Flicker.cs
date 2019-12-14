using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorPrototype
{
    public class Flicker : MonoBehaviour
    {
        public float minTime, maxTime;
        Light thisLight;

        private void Start()
        {
            thisLight = GetComponent<Light>();
            StartCoroutine("LightFlicker");
        }

        private IEnumerator LightFlicker()
        {
            while (true)
            {
                thisLight.enabled = true;
                yield return new WaitForSeconds(Random.Range(minTime, maxTime));
                thisLight.enabled = false;
                yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            }
        }
    }
}