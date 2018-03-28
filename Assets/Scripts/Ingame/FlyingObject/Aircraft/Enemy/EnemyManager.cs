using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class EnemyManager : MonoBehaviour
	{
		[SerializeField]
		EnemyBase[] m_enemies;

		public void DoMove()
		{
			for (int i = 0; i < m_enemies.Length; i++)
			{
				m_enemies[i].DoMove();
			}
		}

		public void DoShoot()
		{
			for (int i = 0; i < m_enemies.Length; i++)
			{
				m_enemies[i].DoShoot();
			}
		}
	}
}
