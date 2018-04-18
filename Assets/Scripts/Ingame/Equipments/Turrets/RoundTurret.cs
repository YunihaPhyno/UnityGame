using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class RoundTurret : Turret
	{
		protected override void InvokeShoot(Bullet[] bullets)
		{
			float theta = 2.0f / (float)bullets.Length * Mathf.PI;
			for (int i = 0; i < bullets.Length; i++)
			{
				Vector3 direction = new Vector3(Mathf.Cos(theta * i), Mathf.Sin(theta * i), 0);
				bullets[i].Initialize(this.transform.position, direction * 3, GetBulletLayer());
			}
		}
	}
}
