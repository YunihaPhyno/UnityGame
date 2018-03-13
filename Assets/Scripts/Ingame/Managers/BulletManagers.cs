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
		StraightBulletManager m_straightBulletManager;

		public void Inisialize()
		{
			m_straightBulletManager.Initialize();
		}

	}
}