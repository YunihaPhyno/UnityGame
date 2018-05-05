using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	/// <summary>
	/// BulletManager<T>をまとめるクラス
	/// </summary>
	public class BulletManagers : MonoBehaviour
	{
		[SerializeField]
		LinearAccelBulletManager m_linearAccelBulletManager;
		public LinearAccelBulletManager Straight { get { return m_linearAccelBulletManager; } }

		public void Inisialize()
		{
			m_linearAccelBulletManager.Initialize();

			BulletSupplier.Initialize(m_linearAccelBulletManager);
		}

		public void DoMove()
		{
			m_linearAccelBulletManager.DoMove();
		}

		public void DoUpdateEquipments()
		{
			m_linearAccelBulletManager.DoUpdateEquipments();
		}

		public void DoFixedUpdate()
		{
			m_linearAccelBulletManager.DoFixedUpdate();
		}
	}
}