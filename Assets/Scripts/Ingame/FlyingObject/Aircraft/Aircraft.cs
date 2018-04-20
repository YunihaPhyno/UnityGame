using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public abstract class Aircraft : FlyingObjectBase
	{
		protected virtual bool CanShoot() { return true; }

		public void DoShoot()
		{
			if(!CanShoot())
			{
				return;
			}

			GetEquipmentsHolder().AllowShootAllTurrets();
		}
	}
}
