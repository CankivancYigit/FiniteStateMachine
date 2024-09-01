using UnityEngine;

public abstract class State : MonoBehaviour
{
	protected StateMachine StateMachine;
	
	public virtual void Setup(StateMachine stateMachine)
	{
		StateMachine = stateMachine;
		enabled = false;
	}
	public void Enter()
	{
		enabled = true;
		EnterState();
	}

	public void Exit()
	{
		enabled = false;
		ExitState();
	}
	public abstract void EnterState();
	public abstract void ExitState();
}
