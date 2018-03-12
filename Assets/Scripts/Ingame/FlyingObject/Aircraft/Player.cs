using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class Player : Aircraft
	{

		protected override Vector3 Move()
		{
			return transform.position + InputManager.Instance.GetDistance() * Time.deltaTime;
		}

		protected override bool CanShoot()
		{
			throw new System.NotImplementedException();
		}

		protected override Bullet[] Shoot()
		{
			throw new System.NotImplementedException();
		}
	}
}