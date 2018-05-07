using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public class GameManager : MonoBehaviour
	{
		#region Managers
		#region FlyingObjectManager
		private FlyingObjectManager m_flyingObjectManager = new FlyingObjectManager();
		public FlyingObjectManager FlyingObjectManager { get { return m_flyingObjectManager; } }
		#endregion // FlyingObjectManager

		#region InputManager
		private InputManager m_inputManager = new InputManager();
		public InputManager InputManager { get { return m_inputManager; } }
		#endregion // InputManager
		#endregion // Managers

		#region State
		enum State
		{
			INIT,
			PLAYING,
		}
		State m_currentState = State.INIT;
		State CurrentState { get { return m_currentState; } }
		void SetState(State state) { Debug.Log(state); m_currentState = state; }

		#region Start
		private void Start()
		{
			InitializeObjects();

			SetState(State.PLAYING);
		}

		private void InitializeObjects()
		{
			StageBuilder.Build(FlyingObjectManager, this.transform);
		}

		#endregion //Start

		// Update is called once per frame
		private void Update()
		{
			Debug.Log("Update : " + Time.fixedDeltaTime.ToString());
			switch(m_currentState)
			{
				case State.INIT:
					break;

				case State.PLAYING:
					InvokeStatePlaying();
					break;
			}
			
		}



		#region StatePlaying
		private void InvokeStatePlaying()
		{
			FlyingObjectManager.DoUpdate();
		}
			

		// ---- 
		private void FixedUpdate()
		{
			Debug.Log("FixedUpdate : " + Time.fixedDeltaTime.ToString());
			switch(m_currentState)
			{
			case State.INIT:
				break;

			case State.PLAYING:
				InvokeStatePlaying_Fixed();
				break;
			}
		}


		private void InvokeStatePlaying_Fixed()
		{
			DoFixedUpdate();
			DoMove();
			DoFixedUpdateEquipments();
			DoShoot();			
		}
		
		private void DoFixedUpdate()
		{
			FlyingObjectManager.DoFixedUpdate();
		}

		private void DoMove()
		{
			FlyingObjectManager.DoMove();
		}

		private void DoShoot()
		{
		}

		private void DoUpdateEquipments()
		{
		}

		private void DoFixedUpdateEquipments()
		{
		}
		#endregion // StatePlaying

		#endregion // State
	}
}