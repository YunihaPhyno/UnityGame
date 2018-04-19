using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class EquipmentsHolder
	{
		Transform m_parent;

		public EquipmentsHolder(Transform parent)
		{
			m_parent = parent;
			SetAllEquipmentLayer(m_equipments, parent.gameObject.layer);
		}

		private static void SetAllEquipmentLayer(List<Equipment> equipments, int layer)
		{
			if(equipments == null)
			{
				return;
			}

			for(int i = 0; i < equipments.Count; i++)
			{
				equipments[i].gameObject.layer = layer;
				SetAllEquipmentLayer(equipments[i].GetEquipmentsHolder().m_equipments, layer);
			}
		}

		private List<Equipment> m_equipments;
		public void AddEquipment(Equipment equipment, Vector3 localPos)
		{
			if(m_equipments == null)
			{
				m_equipments = new List<Equipment>();
			}

			equipment.transform.parent = m_parent;
			equipment.transform.localPosition = localPos;
			m_equipments.Add(equipment);

			SetAllEquipmentLayer(m_equipments, m_parent.gameObject.layer);
		}

		public void UpdateAllEquipments()
		{
			if(m_equipments == null)
			{
				return;
			}

			for(int i = 0; i < m_equipments.Count; i++)
			{
				m_equipments[i].InvokeUpdate();
				m_equipments[i].GetEquipmentsHolder().UpdateAllEquipments();
			}
		}

		#region Turret
		private List<Turret.AllowShootDelegate> m_allowShootDelegateList;
		public void AddTurret(Turret turret, Vector3 localPos)
		{
			if(m_allowShootDelegateList == null)
			{
				m_allowShootDelegateList = new List<Turret.AllowShootDelegate>();
			}

			m_allowShootDelegateList.Add(turret.AllowShootThisFrame);
			AddEquipment(turret, localPos);
		}

		public void AllowShootAllTurrets()
		{
			AllowShootAllThisHolderTurrets();

			// 子要素にも伝播する
			AllowShootAllChildrenTurrets();
		}

		private void AllowShootAllThisHolderTurrets()
		{
			if(m_allowShootDelegateList == null)
			{
				return;
			}

			for(int i = 0; i < m_allowShootDelegateList.Count; i++)
			{
				if(m_allowShootDelegateList[i] == null)
				{
					continue;
				}

				m_allowShootDelegateList[i]();
			}
		}

		private void AllowShootAllChildrenTurrets()
		{
			if(m_equipments == null)
			{
				return;
			}
			
			for(int i = 0; i < m_equipments.Count; i++)
			{
				m_equipments[i].GetEquipmentsHolder().AllowShootAllTurrets();
			}
		}
		#endregion // Turret
	}
}
