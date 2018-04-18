using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public abstract class Aircraft : FlyingObjectBase
	{
		protected virtual bool CanShoot() { return true; }

		#region turret
		private List<Turret> m_turrets;

		public void AddTurret(Turret turret, Vector3 localPos)
		{
			if(m_turrets == null)
			{
				m_turrets = new List<Turret>();
			}

			turret.transform.parent = transform;
			turret.transform.localPosition = localPos;

			m_turrets.Add(turret);
		}
		#endregion // Turret


		public void DoShoot()
		{
			if(m_turrets == null || m_turrets.Count <= 0)
			{
				return;
			}

			if(!CanShoot())
			{
				return;
			}

			for(int i = 0; i < m_turrets.Count; i++)
			{
				if(!m_turrets[i].IsCoolTimeElapsed())
				{
					break;
				}
				m_turrets[i].Shoot();
			}
		}
	}
}
