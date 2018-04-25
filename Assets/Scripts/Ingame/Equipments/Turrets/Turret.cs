using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class Turret : Equipment
	{
		private bool CanShoot() { return IsCoolTimeElapsed() && m_magazine != null; }

		#region CoolTime
		// クールタイム(最大値)
		private float m_coolTime = 0.0f;
		public void SetCoolTime (float value) { m_coolTime = value; }
		
		// 残りのクールタイム
		private float m_remainingCoolTime = 0.0f;

		// クールタイムを元に戻す
		protected void ResetCoolTime() { m_remainingCoolTime = m_coolTime; }

		// 時間を経過させる
		private void UpdateCoolTime() { m_remainingCoolTime -= Time.fixedDeltaTime; }

		// クールタイムが完了したか
		public bool IsCoolTimeElapsed()
		{
			return m_remainingCoolTime <= 0;
		}
		#endregion // CoolTime

		#region Magazine
		private Bullet[] m_magazine;
		public void Reload(Bullet[] bullets)
		{
			m_magazine = bullets;
		}

		/// <summary>
		/// 現在装填されているbulletを破棄します。
		/// </summary>
		public void DropMagazine() { m_magazine = null; }

		/// <summary>
		/// 弾倉に弾はあるか？
		/// </summary>
		/// <returns>既に弾がこめられていればtrue</returns>
		public bool IsReloaded() { return (m_magazine != null); }
		
		#endregion // Magazine

		public override void InvokeFixedUpdate()
		{
			base.InvokeFixedUpdate();
			UpdateCoolTime();
		}

		/// <summary>
		/// 射撃命令を出す
		/// </summary>
		/// <returns>射撃が実行されたか</returns>
		public bool Shoot()
		{
			if(!CanShoot())
			{
				return false;
			}

			// 射撃の実行
			InvokeShoot(m_magazine);

			// クールタイムリセット
			ResetCoolTime();

			// 弾倉の破棄
			DropMagazine();

			return true;
		}

		/// <summary>
		/// 発射アルゴリズムの実装。これをoverrideして撃ち方を変える
		/// </summary>
		/// <param name="bullets">打ち出す弾</param>
		protected virtual void InvokeShoot(Bullet[] bullets)
		{
			// デフォルトは(0, 1, 0)に向かって弾を発射する(ローテーションの影響を受ける)
			Vector3 direction = transform.rotation * new Vector3(0, 1, 0);
			for(int i = 0; i < bullets.Length; i++)
			{
				bullets[i].Fire(transform.position);
			}
		}

		#region Controller
		public class Controller
		{
			private Turret m_turret;
			public Controller(Turret turret)
			{
				m_turret = turret;
			}

			public bool IsExisted()
			{
				return (m_turret != null);
			}
			
			public void Shoot()
			{
				m_turret.Shoot();
			}

			public void Reload(Bullet[] bullets)
			{
				m_turret.Reload(bullets);
			}

			public bool IsReloaded()
			{
				return m_turret.IsReloaded();
			}

			public void DropMagazine()
			{
				m_turret.DropMagazine();
			}
		}

		public Controller GetController()
		{
			return new Controller(this);
		}
		#endregion // Controller
	}
}
