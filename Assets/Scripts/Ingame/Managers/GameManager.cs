﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public class GameManager : Singleton<GameManager>
	{
		[SerializeField]
		Player m_player;
		public Vector3 GetPlayerPosition () { return m_player.transform.position; }

		[SerializeField]
		EnemyManager m_enemyManager;

		// 弾関連
		[SerializeField]
		private BulletManagers m_bulletManagers;
		public BulletManagers BulletManagers { get { return m_bulletManagers; } }

		[SerializeField]
		ResourceManager m_resourceManager;
		public ResourceManager ResourceManager { get { return m_resourceManager; } }

		private InputManager m_inputManager;
		public InputManager InputManager { get { return m_inputManager; } }

		// Use this for initialization
		void Start()
		{
			m_inputManager = new InputManager();
			m_bulletManagers.Inisialize();
		}

		// Update is called once per frame
		void Update()
		{
			DoMove();
			DoShoot();
		}

		void DoMove()
		{
			m_player.DoMove();
			m_bulletManagers.DoMove();
			m_enemyManager.DoMove();
		}

		void DoShoot()
		{
			m_player.DoShoot();
			m_enemyManager.DoShoot();
		}
	}
}