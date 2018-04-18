using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public class StaticEnemy : EnemyBase
	{
		private void Awake()//ForDebug
		{
			GameObject turret = new GameObject();
			Turret turretComponent = turret.AddComponent<Turret>();

			Turret.Parameter param = new Turret.Parameter();
			param.bulletType = BulletSupplier.BULLET_TYPE.LINEAR_ACCEL;
			param.numBullets = 2;
			param.initializeSpeed = 1.0f;
			param.coolTime = 1.0f;

			turretComponent.SetParam(param);
			AddTurret(turretComponent, new Vector3(0,0,0));
		}

		protected override Vector3 GetMoveVector()
		{
			return new Vector3(0, 0, 0);
		}
	}
}
