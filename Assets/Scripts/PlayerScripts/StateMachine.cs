using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public Istate _currentState;

    public event Action <Istate> HandleStateChange;

    public List<StateTransition> transitions = new List<StateTransition>();
    public List<StateTransition> transitionsFromAnyState = new List<StateTransition>();
    public void AddTransition(Istate from, Istate to, Func<bool> condition)
    {
        StateTransition newtransition = new StateTransition(from, to, condition);
        transitions.Add(newtransition);

    }

    public void addTransitionFromAnyState (Istate to, Func<bool> condition)
    {
        StateTransition newtransition = new StateTransition(null, to, condition);
        transitionsFromAnyState.Add(newtransition);
    }

    public void Tick()
    {
        StateTransition transition = checkForTransition();
        if (transition != null)
        {
            SetState(transition._to);
        }

        _currentState.OnUpdate();
    }

    public void SetState(Istate state)
    {
        if (_currentState == state)
        {
            return;
        }
        _currentState?.OnExit();
        _currentState = state;
        HandleStateChange?.Invoke(state);
        _currentState.OnEnter();
    }

    StateTransition checkForTransition()
    {
        foreach (var trans in transitionsFromAnyState)
        {
            if (trans._condition())
            {
                return trans;
            }
        }

        foreach (var trans in transitions)
        {

            if (_currentState == trans._from && trans._condition())
            {
                return trans;
            }
        }
        return null;
    }
}


public class StateTransition
{
    public Istate _from;
    public Istate _to;
    public Func<bool> _condition;

    public StateTransition(Istate from, Istate to, Func<bool> condition)
    {
        _from = from;
        _to = to;
        _condition = condition;
    }
}