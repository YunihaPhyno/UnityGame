using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public abstract class Aircraft : FlyingObjectBase
	{
		protected abstract bool CanShoot();

		protected abstract void Shoot();

		#region turret
		private List<Turret> m_turrets;

		public void AddTurret(Turret turret, Vector3 localPos)
		{
			if(m_turrets == null)
			{
				m_turrets = new List<Turret>();
			}

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
				m_turrets[i].Shoot();
			}
		}
	}
}
