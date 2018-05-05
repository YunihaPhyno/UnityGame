using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class BulletManagerBase<T> : MonoBehaviour where T : Bullet
	{
		[SerializeField]
		private int m_numMaxBullets;
		public int NumMaxBullets { get { return m_numMaxBullets; } }

		[SerializeField]
		private GameObject m_prefab;

		private T[] m_ringBuffer;
		private int m_tail;
		
		public void Initialize()
		{
			m_tail = 0;
			m_ringBuffer = new T[m_numMaxBullets];

			for (int i = 0; i < m_ringBuffer.Length; i++)
			{
				GameObject gobj = InstantiateBullet(m_prefab, this.transform);
				m_ringBuffer[i] = gobj.GetComponent<T>();
			}
		}

		static private GameObject InstantiateBullet(GameObject prefab, Transform parent)
		{
			GameObject gobj = GameObject.Instantiate<GameObject>(prefab);
			gobj.transform.parent = parent;
			gobj.SetActive(false);
			return gobj;
		}

		#region DoMove
		public void DoMove()
		{
			CommonUpdate(DoMoveProcessing);
		}

		private void DoMoveProcessing(T bullet)
		{
			bullet.DoMove();
		}
		#endregion // DoMove

		#region DoUpdateEquipments
		public void DoUpdateEquipments()
		{
			CommonUpdate(DoUpdateEquipmentsProcessing);
		}

		public void DoUpdateEquipmentsProcessing(T bullet)
		{
			bullet.GetEquipmentsHolder().UpdateAllEquipments();
		}
		#endregion // DoUpdateEquipMents

		#region DoFixedUpdate
		public void DoFixedUpdate()
		{
			CommonUpdate(FixedUpdateDelegate);
		}

		private void FixedUpdateDelegate(T bullet)
		{
			bullet.InvokeFixedUpdate();
		}
		#endregion // DoFixedUpdate

		#region Common
		// 弾一個一個に対する処理のデリゲート
		delegate void UpdateProcessingDelegate(T bullet);

		// 共通処理
		private void CommonUpdate(UpdateProcessingDelegate onUpdate)
		{
			for(int i = 0; i < m_ringBuffer.Length; i++)
			{
				if(!m_ringBuffer[i].gameObject.activeSelf)
				{
					continue;
				}
				onUpdate(m_ringBuffer[i]);
			}
		}
		#endregion // Common

		public T GetBullet()
		{
			T bullet = m_ringBuffer[m_tail];
			m_tail++;
			if(m_tail >= m_ringBuffer.Length)
			{
				m_tail -= m_ringBuffer.Length;
			}
			return bullet;
		}
		
		public T[] GetBullets(int num)
		{
			T[] bullets = new T[num];
			for (int i = 0; i < bullets.Length; i++)
			{
				bullets[i] = GetBullet();
			}
			return bullets;
		}
	}
}