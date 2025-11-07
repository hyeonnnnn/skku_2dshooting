using UnityEngine;

public class StateManager : MonoBehaviour
{
    private IState _currentState;

    public void SwitchState(IState newState)
    {
        if(_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = newState;
        if(_currentState != null)
        {
            _currentState.Enter();
        }
    }

    public void Update()
    {
        if(_currentState != null)
        {
            _currentState.Update();
        }
    }
}
