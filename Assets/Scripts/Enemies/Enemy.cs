using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorPrototype
{
    public class Enemy : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent nma;
        private AIState currentState;


        // Start is called before the first frame update
        void Start()
        {
            nma = GetComponent<UnityEngine.AI.NavMeshAgent>();
            SetState(new StateMoveToTest(this));
        }

        // Update is called once per frame
        void Update()
        {
            currentState.Tick();
        }

        public void SetState(AIState state)
        {
            if (currentState != null)
                currentState.OnStateExit();

            currentState = state;

            if (currentState != null)
                currentState.OnStateEnter();
        }
    }
}