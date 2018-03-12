using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	/// <summary>
	/// BulletManager<T>をまとめるクラス
	/// </summary>
	public class BulletsManager
	{

		StraightBulletManager m_straightBulletManager;

		public BulletsManager(int straight)
		{
			m_straightBulletManager = new StraightBulletManager(straight, GameManager.Instance.ResourceManager.StraightBulletPrefab);

		}
	}
}