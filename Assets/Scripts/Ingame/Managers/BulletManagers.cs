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
		LinearAccelBulletManager m_straightBulletManager;
		public LinearAccelBulletManager Straight { get { return m_straightBulletManager; } }

		public void Inisialize()
		{
			m_straightBulletManager.Initialize();
		}

		public void DoMove ()
		{
			m_straightBulletManager.DoMove();
		}
	}
}