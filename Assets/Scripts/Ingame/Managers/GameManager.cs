using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField]
		private Player m_player;
		public Player Player { get { return m_player; } }
		public void SetPlayer(Player player) { m_player = player; }

		[SerializeField]
		private EnemyManager m_enemyManager;
		public EnemyManager EnemyManager { get { return m_enemyManager; } }
		public void SetEnemyManager(EnemyManager enemyManager) { m_enemyManager = enemyManager; }

		// 弾関連
		[SerializeField]
		private BulletManagers m_bulletManagers;
		public BulletManagers BulletManagers { get { return m_bulletManagers; } }
		public void SetBulletManagers(BulletManagers bulletManagers) { m_bulletManagers = bulletManagers; }

		private InputManager m_inputManager;

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
			InstantiateMembers();
			InitializeObjects();

			SetState(State.PLAYING);
		}

		private void InstantiateMembers()
		{
			m_inputManager = new InputManager();
		}

		private void InitializeObjects()
		{
			m_bulletManagers.Inisialize();
			m_player.Initialize();
			m_enemyManager.DoInitialize();
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

		#region StatePlaying
		private void InvokeStatePlaying()
		{
			DoInput();
			DoUpdate();
		}

		private void DoInput()
		{
			m_player.Input(new Player.InputParameter(m_inputManager.GetPlayerInput()));
		}

		private void DoUpdate()
		{
			m_player.InvokeUpdate();
			m_enemyManager.DoUpdate();
		}

		// ---- 
		private void InvokeStatePlaying_Fixed()
		{
			DoFixedUpdate();
			DoMove();
			DoFixedUpdateEquipments();
			DoShoot();			
		}
		
		private void DoFixedUpdate()
		{
			m_player.InvokeFixedUpdate();
			m_enemyManager.DoFixedUpdate();
			m_bulletManagers.DoFixedUpdate();
		}

		private void DoMove()
		{
			m_player.DoMove();
			m_bulletManagers.DoMove();
			m_enemyManager.DoMove();
		}

		private void DoShoot()
		{
			m_player.DoShoot();
			m_enemyManager.DoShoot();
		}

		private void DoUpdateEquipments()
		{
			m_player.GetEquipmentsHolder().UpdateAllEquipments();
			m_enemyManager.DoUpdateEquipments();
		}

		private void DoFixedUpdateEquipments()
		{
			m_player.GetEquipmentsHolder().FixedUpdateAllEquipments();
			m_enemyManager.DoFixedUpdateEquipments();
		}
		#endregion // StatePlaying

		#endregion // State
	}
}