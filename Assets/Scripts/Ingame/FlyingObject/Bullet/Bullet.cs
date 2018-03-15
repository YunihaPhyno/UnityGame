using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public abstract class Bullet : FlyingObjectBase
	{
		private Vector3 m_velocity;

		public void Initialize(Vector3 pos, Vector3 velocity)
		{
			transform.position = pos;
			m_velocity = velocity;
			gameObject.SetActive(true);
		}

		protected sealed override Vector3 Move()
		{
			return transform.position + m_velocity * Time.deltaTime;
		}
	}
}
