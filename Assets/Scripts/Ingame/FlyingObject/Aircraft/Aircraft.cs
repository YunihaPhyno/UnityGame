using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public abstract class Aircraft : FlyingObjectBase
	{
		protected abstract bool CanShoot();

		protected abstract Bullet[] Shoot();
	}
}
