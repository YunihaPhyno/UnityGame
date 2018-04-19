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

		[SerializeField]
		private EnemyManager m_enemyManager;

		// 弾関連
		[SerializeField]
		private BulletManagers m_bulletManagers;

		[SerializeField]
		private ResourceManager m_resourceManager;

		private InputManager m_inputManager;

		// Use this for initialization
		private void Start()
		{
			m_inputManager = new InputManager();
			m_bulletManagers.Inisialize();
		}

		// Update is called once per frame
		private void Update()
		{
			DoInput();
			DoMove();
			DoShoot();
			DoUpdateEquipments();
		}

		private void DoMove()
		{
			m_player.DoMove();
			m_bulletManagers.DoMove();
			m_enemyManager.DoMove();
		}

		private void DoInput()
		{
			m_player.Input(new Player.InputParameter(m_inputManager.GetPlayerInput(), m_enemyManager));
		}

		private void DoShoot()
		{
			m_player.DoShoot();
			m_enemyManager.DoShoot();
		}

		private void DoUpdateEquipments()
		{
			m_player.UpdateEquipments();
			m_enemyManager.DoUpdateEquipments();
		}
	}
}