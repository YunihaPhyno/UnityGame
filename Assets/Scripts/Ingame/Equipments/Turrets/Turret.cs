using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class Turret : Equipment
	{
		// クールタイムが完了したか？(あくまで制御は外部で行う)
		public bool IsCoolTimeElapsed() {
			if(m_param == null)
			{
				return false;
			}
			return (Time.time - m_lastShootTime) > m_param.coolTime;
		}
		
		// 最後に発射した時間
		private float m_lastShootTime = 0.0f;
		protected void ResetCoolTime() { m_lastShootTime = Time.time; }

		public class Parameter
		{
			// 発射される弾の種類
			public BulletSupplier.BULLET_TYPE bulletType = BulletSupplier.BULLET_TYPE.LINEAR_ACCEL;

			// 一回で装填される弾の数
			public int numBullets = 1;

			// 発射される弾の初速度
			public float initializeSpeed = 1.0f;

			// クールタイム
			public float coolTime = float.MaxValue;
		}

		private Parameter m_param;
		public void SetParam(Parameter param) { m_param = param; }

		/// <summary>
		/// 弾を発射する
		/// CoolTimeに関係なく実行したら弾が発射される
		/// </summary>
		/// <param name="bullets">発射する弾の配列</param>
		public void Shoot()
		{
			if(m_param == null)
			{
				Debug.LogError("パラメーターがありません！");
				return;
			}

			ResetCoolTime();
			InvokeShoot(BulletSupplier.GetBullets(m_param.bulletType, m_param.numBullets));
		}

		// デフォルトは(0, 1, 0)に向かって弾を発射する(ローテーションの影響を受ける)
		protected virtual void InvokeShoot(Bullet[] bullets)
		{
			Vector3 direction = transform.rotation * new Vector3(0, 1, 0);
			for(int i = 0; i < bullets.Length; i++)
			{
				bullets[i].Initialize(transform.position, direction * m_param.initializeSpeed, GetBulletLayer());
			}
		}


		// 弾のレイヤーを取得
		protected Bullet.LAYER GetBulletLayer()
		{
			string layerName = LayerMask.LayerToName(gameObject.layer);
			switch(layerName)
			{
				case "Enemy":
					return Bullet.LAYER.ENEMY;

				case "Player":
					return Bullet.LAYER.FRIEND;
			}

			Debug.LogError("レイヤーが設定されていないか、想定しないレイヤー名です。");
			return Bullet.LAYER.FRIEND;//とりあえずFRIENDを返す
		}
	}
}
