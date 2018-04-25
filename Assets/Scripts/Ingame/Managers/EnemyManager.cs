using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class EnemyManager : MonoBehaviour
	{
		[SerializeField]
		EnemyBase[] m_enemies;

		#region CommonProcess
		delegate void PartProcessDelegate(EnemyBase enemy);
		private void CommonProcess(PartProcessDelegate processDelegate)
		{
			if(m_enemies == null)
			{
				return;
			}

			for(int i = 0; i < m_enemies.Length; i++)
			{
				if(m_enemies[i] == null)
				{
					continue;
				}

				processDelegate(m_enemies[i]);
			}
		}
		#endregion // CommonProcess

		#region Initialize
		public void DoInitialize()
		{
			CommonProcess(InitializeDelegate);
		}

		private void InitializeDelegate(EnemyBase enemy)
		{
			enemy.Initialize();
		}
		#endregion //Initialize

		#region Move
		public void DoMove()
		{
			CommonProcess(MoveDelegate);
		}

		private void MoveDelegate(EnemyBase enemy)
		{
			enemy.DoMove();
		}
		#endregion // Move

		#region Update
		public void DoUpdate()
		{
			CommonProcess(UpdateDelegate);
		}

		private void UpdateDelegate(EnemyBase enemy)
		{
			enemy.InvokeUpdate();
		}
		#endregion // Update

		#region FixedUpdate
		public void DoFixedUpdate()
		{
			CommonProcess(FixedUpdateDelegate);
		}

		private void FixedUpdateDelegate(EnemyBase enemy)
		{
			enemy.InvokeFixedUpdate();
		}
		#endregion // FixedUpdate

		#region DoShoot
		public void DoShoot()
		{
			CommonProcess(ShootDelegate);
		}

		private void ShootDelegate(EnemyBase enemy)
		{
			enemy.DoShoot();
		}
		#endregion // DoShoot

		#region DoUpdateEquipments
		public void DoUpdateEquipments()
		{
			CommonProcess(UpdateEquipmentsDelegate);
		}

		private void UpdateEquipmentsDelegate(EnemyBase enemy)
		{
			enemy.GetEquipmentsHolder().UpdateAllEquipments();
		}
		#endregion // DoUpdateEquipments

		#region DoFixedUpdateEquipments
		public void DoFixedUpdateEquipments()
		{
			CommonProcess(FixedUpdateEquipmentsDelegate);
		}

		private void FixedUpdateEquipmentsDelegate(EnemyBase enemy)
		{
			enemy.GetEquipmentsHolder().FixedUpdateAllEquipments();
		}
		#endregion // DoFixedUpdateEquipments
	}
}
