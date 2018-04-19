using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public abstract class Equipment : MonoBehaviour
	{
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
		#endregion // EquipmentsHolder

		public abstract void InvokeUpdate();
	}
}
