using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public abstract class Aircraft : FlyingObjectBase
	{
		protected virtual bool CanShoot() { return true; }

		#region EquipmentsHolder
		private EquipmentsHolder m_equipmentsHolder;
		public EquipmentsHolder GetEquipmentsHolder()
		{
			if(m_equipmentsHolder == null)
			{
				m_equipmentsHolder = new EquipmentsHolder(transform);
			}
			return m_equipmentsHolder;
		}

		public void UpdateEquipments()
		{
			GetEquipmentsHolder().UpdateAllEquipments();
		}

		public void DoShoot()
		{
			if(!CanShoot())
			{
				return;
			}

			GetEquipmentsHolder().AllowShootAllTurrets();
		}
		#endregion // EquipmentsHolder
	}
}
