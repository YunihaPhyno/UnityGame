using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Aircraft : FlyingObjectBase
{
	protected abstract bool CanShoot();

	protected abstract Bullet[] Shoot();
}
