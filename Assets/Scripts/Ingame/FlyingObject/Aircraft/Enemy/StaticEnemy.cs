using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public class StaticEnemy : EnemyBase
	{
		[SerializeField]
		private float m_shootTime;
		public float ShootTime { get { return m_shootTime; } }
		public void SetShootTime(float time) { m_shootTime = time; }

		private float m_shootTimer = 0;

		protected override bool CanShoot()
		{
			m_shootTimer -= ScalableTime.DeltaTime;
			if (m_shootTimer < 0)
			{
				m_shootTimer += ShootTime;
				return true;
			}
			return false;
		}

		protected override Vector3 Move()
		{
			return transform.position;
		}

		protected override void Shoot()
		{
			/*
			LinearAccelBullet[] linearAccelBullets = GameManager.Instance.BulletManagers.Straight.GetBullets(36);
			float theta = 2.0f / (float)linearAccelBullets.Length * Mathf.PI;
			for (int i = 0; i < linearAccelBullets.Length; i++)
			{
				Vector3 direction = new Vector3(Mathf.Cos(theta * i), Mathf.Sin(theta * i), 0);
				linearAccelBullets[i].Initialize(this.transform.position, direction * 3, Bullet.LAYER.ENEMY);
				linearAccelBullets[i].SetConstantAcceleration(-direction * 2 + GetPlayerDirection() * 2);
			}
			*/
		}

		/*
		private Vector3 GetPlayerDirection()
		{
			Vector3 p_pos = GameManager.Instance.GetPlayerPosition();
			Vector3 e_pos = this.transform.position;
			Vector3 vec = p_pos - e_pos;
			return vec.normalized;
		}
		*/
	}
}
