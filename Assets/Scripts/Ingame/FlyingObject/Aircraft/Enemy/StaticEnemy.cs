using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public class StaticEnemy : EnemyBase
	{
		protected override void Initialize()//ForDebug
		{
			RotateTable rotateTable = GetDebugRotateTable();
			rotateTable.GetEquipmentsHolder().AddTurret(GetDebugRoundTurret(), new Vector3(0,0,0));

			GetEquipmentsHolder().AddEquipment(rotateTable, new Vector3(0,0,0));
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

			Turret.Parameter param = new Turret.Parameter();
			param.bulletType = BulletSupplier.BULLET_TYPE.LINEAR_ACCEL;
			param.numBullets = 10;
			param.initializeSpeed = 1.0f;
			param.coolTime = 0.5f;

			turretComponent.SetParam(param);

			return turretComponent;
		}

		protected override Vector3 GetMoveVector()
		{
			return new Vector3(0, 0, 0);
		}
	}
}
