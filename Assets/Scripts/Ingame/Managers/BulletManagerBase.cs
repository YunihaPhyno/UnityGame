using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class BulletManagerBase<T> : MonoBehaviour where T : Bullet
	{
		[SerializeField]
		private int m_numMaxBullets;
		public int numMaxBullets { get { return m_numMaxBullets; } }

		[SerializeField]
		private GameObject m_prefab;

		private T[] m_ringBuffer;
		
		public void Initialize()
		{
			m_ringBuffer = new T[m_numMaxBullets];

			for (int i = 0; i < m_ringBuffer.Length; i++)
			{
				GameObject gobj = Instantiate();
				m_ringBuffer[i] = gobj.GetComponent<T>();
			}
		}

		private GameObject Instantiate()
		{
			GameObject gobj = GameObject.Instantiate<GameObject>(m_prefab);
			gobj.transform.parent = this.transform;
			gobj.SetActive(false);
			return gobj;
		}
	}
}