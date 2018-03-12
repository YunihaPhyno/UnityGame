using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class StraightBulletManager : BulletManagerBase<StraightBullet>
	{
		public StraightBulletManager(int max, string prefabPath) : base(max, prefabPath) { }
		public StraightBulletManager(int max, GameObject prefab) : base(max, prefab) { }
	}
}