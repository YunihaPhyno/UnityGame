using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class GameManager : Singleton<GameManager>
	{

		// aircrafts関連
		// TODO
		private Aircraft[] m_aircrafts;

		// 弾関連
		[SerializeField]
		int m_numMaxStraightBullets;
		private BulletsManager m_bulletsManager;

		[SerializeField]
		ResourceManager m_resourceManager;
		public ResourceManager ResourceManager { get { return m_resourceManager; } }

		// Use this for initialization
		void Start()
		{
			m_bulletsManager = new BulletsManager(m_numMaxStraightBullets);
		}

		// Update is called once per frame
		void Update()
		{
		}
	}
}