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

		protected override Bullet[] Shoot()
		{
			throw new System.NotImplementedException();
		}
	}
}