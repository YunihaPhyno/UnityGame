using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class RoundTurret : Turret
	{
		protected override void InvokeShoot(Bullet[] bullets)
		{
			// TODO:bullet一個一個を回転させる
			for (int i = 0; i < bullets.Length; i++)
			{
				bullets[i].transform.rotation = Quaternion.Euler(0, 0, 360 * i / bullets.Length) * transform.rotation;
				bullets[i].Fire(transform.position);
			}
		}
	}
}
