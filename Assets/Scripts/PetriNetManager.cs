using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetriNetManager : MonoBehaviour {

    State currentState;

    [SerializeField]
    GameObject[] statesRepresentation;
    [SerializeField]
    GameObject identifier;

    [SerializeField]
    GameObject[] states;
    [SerializeField]
    GameObject resource;


    public class State
    {
        State nextState1;
        State nextState2;
        State previousState;

        int index;

        bool active = false;

        public State()
        {
            nextState1 = null;
            nextState2 = null;
            previousState = null;
            active = false;
            index = -1;
        }

        public void InitializeState(State nState1, State nState2, State pState, bool _active, int _index)
        {
            nextState1 = nState1;
            nextState2 = nState2;
            previousState = pState;
            active = _active;
            index = _index;
        }
        public State GetNextState1()
        {
            return nextState1;
        }

        public State GetNextState2()
        {
            return nextState2;
        }

        public State GetPreviousState()
        {
            return previousState;
        }

        public void SetStatus(bool status)
        {
            active = status;
        }

        public bool GetStatus()
        {
            return active;
        }

        public int GetIndex()
        {
            return index;
        }

    }

    public State generatorState, resourcesState, mixtureState, verificatorState, nextState, destroyState;

    private void Start()
    {
        generatorState = new State();
        resourcesState = new State();
        mixtureState =  new State();
        verificatorState =  new State();
        nextState = new State();
        destroyState = new State();

        generatorState.InitializeState(resourcesState, null, null, true, 0);
        resourcesState.InitializeState(mixtureState, verificatorState, generatorState, false, 1);
        mixtureState.InitializeState(resourcesState, null, resourcesState, false, 2);
        verificatorState.InitializeState(nextState, destroyState, resourcesState, false, 3);
        nextState.InitializeState(null, null, verificatorState, false, 4);
        destroyState.InitializeState(generatorState, null, verificatorState, false, 5);

        currentState = generatorState;
    }

    private void Update()
    {
        int currentIndex = currentState.GetIndex();

        identifier.transform.position = statesRepresentation[currentIndex].transform.position;
        resource.transform.position = states[currentIndex].transform.position;
    }

    public void MoveToTheNextState1()
    {
        currentState.SetStatus(false);
        currentState = currentState.GetNextState1();
        currentState.SetStatus(true);
    }

    public void MoveToTheNextState2()
    {
        currentState.SetStatus(false);
        currentState = currentState.GetNextState2();
        currentState.SetStatus(true);
    }

    public void ReturnToThePreviousState()
    {
        currentState.SetStatus(false);
        currentState = currentState.GetPreviousState();
        currentState.SetStatus(true);
    }

    public int GetCurrentCellIndex()
    {
        return currentState.GetIndex();
    }


}
