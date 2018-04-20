using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	/// <summary>
	/// 弾を供給することだけできるクラス
	/// </summary>
	public static class BulletSupplier
	{
		public enum BULLET_TYPE
		{
			LINEAR_ACCEL,
		}

		// マネージャーの参照を内部的に持っておく
		static LinearAccelBulletManager m_linearAccel;

		// マネージャの参照はBulletManagersの初期化時に取得する
		public static void Initialize(LinearAccelBulletManager linearAccel)
		{
			m_linearAccel = linearAccel;
		}

		public static LinearAccelBullet[] GetBullets<LinearAccelBulle>(int num)
		{
			return m_linearAccel.GetBullets(num);
		}
	}
}
