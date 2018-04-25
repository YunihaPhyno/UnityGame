using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public class StaticEnemy : EnemyBase
	{
		protected override void OnInitialize()
		{
			base.OnInitialize();
			RotateTable rotateTable = GetDebugRotateTable();

			Turret turret = GetDebugRoundTurret();
			RegisterTurretController(turret.GetController());

			rotateTable.GetEquipmentsHolder().AddEquipment(turret, Vector3.zero);
			GetEquipmentsHolder().AddEquipment(rotateTable, Vector3.zero);
		}

		private RotateTable GetDebugRotateTable()
		{
			GameObject rotateTable = new GameObject("RotateTable");
			RotateTable rotateTableComponent = rotateTable.AddComponent<RotateTable>();

			return rotateTableComponent;
		}

		private Turret GetDebugRoundTurret()
		{
			GameObject turret = new GameObject("RoundTurret");
			Turret turretComponent = turret.AddComponent<RoundTurret>();
			turretComponent.SetCoolTime(0.2f);
			return turretComponent;
		}

		protected override Vector3 GetMoveVector()
		{
			return new Vector3(0, 0, 0);
		}

		public override void InvokeFixedUpdate()
		{
			base.InvokeFixedUpdate();
			ReloadAllTurrets();
		}

		private void ReloadAllTurrets()
		{
			List<Turret.Controller> turretControllers = GetTurretControllers();
			for(int i = 0; i < turretControllers.Count; i++)
			{
				if(!turretControllers[i].IsExisted())
				{
					continue;
				}

				if(turretControllers[i].IsReloaded())
				{
					continue;
				}

				LinearAccelBullet[] bullets = BulletSupplier.GetBullets<LinearAccelBullet>(30);

				InitializeBullets(bullets);

				turretControllers[i].Reload(bullets);
			}
		}

		private static void InitializeBullets(LinearAccelBullet[] bullets)
		{
			for(int i = 0; i < bullets.Length; i++)
			{
				bullets[i].SetParam(Vector3.up * 5, Bullet.LAYER.ENEMY);
			}
		}
	}
}
