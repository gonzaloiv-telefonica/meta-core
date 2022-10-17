using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.FlowControl;

namespace Meta.Panels
{

    public class StateMapSample : MonoBehaviour
    {

        [SerializeField] private FlowData data;
        [SerializeField] private FlowMap map;

        private void Awake()
        {
            SetupStates();
            map.SetFlowData(data);
        }

        private void SetupStates()
        {
            StateMachine stateMachine = new StateMachine();
            State first = new StateBuilder<State>()
                .Route("First")
                .Enter(() => Debug.LogWarning("Entering First"))
                .Build();
            stateMachine.Register(first);
            State second = new StateBuilder<State>()
               .Route("Second")
               .Enter(() => Debug.LogWarning("Entering Second"))
               .Build();
            stateMachine.Register(second);
            State third = new StateBuilder<State>()
               .Route("Third")
               .Enter(() => Debug.LogWarning("Entering Third"))
               .Build();
            stateMachine.Register(third);
            Router.Init(stateMachine);
        }

    }

}