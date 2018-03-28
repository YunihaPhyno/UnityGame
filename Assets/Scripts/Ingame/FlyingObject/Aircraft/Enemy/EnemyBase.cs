using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame 
{
	public abstract class EnemyBase : Aircraft
	{
		protected override string GetTag()
		{
			return "Enemy";
		}

		protected override string GetLayerName()
		{
			return "Enemy";
		}
	}
}
