using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class Player : Aircraft
	{

		protected override Vector3 Move()
		{
			return transform.position + GameManager.Instance.InputManager.GetDistance() * Time.deltaTime;
		}

		protected override bool CanShoot()
		{
			return GameManager.Instance.InputManager.IsShoot();
		}

		protected override void Shoot()
		{
			StraightBullet[] straightBullets = GameManager.Instance.BulletManagers.Straight.GetBullets(3);
			for(int i = 0; i < straightBullets.Length; i++)
			{
				straightBullets[i].Initialize(transform.position, new Vector3(0, 1 + i, 0));
			}
		}
	}
}