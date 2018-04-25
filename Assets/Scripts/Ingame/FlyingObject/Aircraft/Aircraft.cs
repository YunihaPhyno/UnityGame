using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public abstract class Aircraft : FlyingObjectBase
	{
		#region Turret
		private List<Turret.Controller> m_TurretControllerList;
		protected List<Turret.Controller> GetTurretControllers()
		{
			if(m_TurretControllerList == null)
			{
				m_TurretControllerList = new List<Turret.Controller>();
			}
			return m_TurretControllerList;
		}

		public void RegisterTurretController(Turret.Controller turretController)
		{
			if(turretController == null)
			{
				return;
			}

			GetTurretControllers().Add(turretController);
		}
		#endregion // Turret

		protected virtual bool CanShoot() { return true; }

		public void DoShoot()
		{
			List<Turret.Controller> turretControllers = GetTurretControllers();
			for(int i = 0; i < turretControllers.Count; i++)
			{
				if(!turretControllers[i].IsExisted())
				{
					continue;
				}
				turretControllers[i].Shoot();
			}
		}
	}
}
