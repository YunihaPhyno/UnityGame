using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class BulletManagerBase<T> where T : Bullet
	{

		private T[] m_ringBuffer;
		private int m_numMaxBullets;
		public int numMaxBullets { get { return m_numMaxBullets; } }

		public BulletManagerBase(int max, string prefabPath)
		{
			GameObject prefab = Resources.Load<GameObject>(prefabPath);
			Initialize(max, prefab);
		}

		public BulletManagerBase(int max, GameObject prefab)
		{
			Initialize(max, prefab);
		}

		public void Initialize(int max, GameObject prefab)
		{
			m_numMaxBullets = max;
			m_ringBuffer = new T[max];

			for (int i = 0; i < m_ringBuffer.Length; i++)
			{
				GameObject gobj = GameObject.Instantiate<GameObject>(prefab);
				m_ringBuffer[i] = gobj.GetComponent<T>();
			}
		}
	}
}