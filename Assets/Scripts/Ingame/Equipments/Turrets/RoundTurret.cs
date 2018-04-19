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
				direction = transform.rotation * direction;
				// 第一引数の「+ direction」は同時に弾を生成したときにコリジョン判定が大量に動いてしまうのの防止策
				bullets[i].Initialize(this.transform.position + direction, direction * 3, GetBulletLayer());
			}
		}
	}
}
