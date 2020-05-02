using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorPrototype
{
    public class StateMoveToTest : AIState
    {
        private Vector3 destination;

        public StateMoveToTest(Enemy enemy) : base(enemy) { }
        
        public override void Tick()
        {
            destination = new Vector3(0, enemy.transform.position.y, 11);
            enemy.nma.SetDestination(destination);            
            //if (enemy.nma.remainingDistance <= enemy.nma.stoppingDistance)
            //    Debug.Log("Arrived at destination");
        }
    }
}