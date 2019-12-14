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
            enemy.nma.SetDestination(destination);
            destination = new Vector3(0, transform.position.y, 11);
        }
    }
}