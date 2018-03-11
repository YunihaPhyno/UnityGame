using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBulletManager : BulletManagerBase<StraightBullet> {
	public StraightBulletManager(int max, string prefabPath) : base (max, prefabPath){}
}
