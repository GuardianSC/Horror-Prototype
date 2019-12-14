using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorPrototype
{
    public abstract class AIState : MonoBehaviour
    {
        protected Enemy enemy;

        public abstract void Tick();
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }

        public AIState(Enemy enemy)
        {
            this.enemy = enemy;
        }
    }
}
