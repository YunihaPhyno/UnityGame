using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public class Player : Aircraft
	{
		[SerializeField]
		private float m_speed = 5.0f;

		private float m_shootTimer = 0;

		[SerializeField]
		private float m_shootTime;

		protected override string GetTag()
		{
			return "Player";
		}

		protected override string GetLayerName()
		{
			return "Friend";
		}

		protected override Vector3 Move()
		{
			float speed = m_speed;
			if (GameManager.Instance.InputManager.IsSpeedUp())
			{
				speed *= 2;
			}
			else if (GameManager.Instance.InputManager.IsSpeedDown())
			{
				speed /= 2;
			}
			return transform.position + GameManager.Instance.InputManager.GetDistance() * speed * ScalableTime.DeltaTime;
		}

		protected override bool CanShoot()
		{
			
			if (m_shootTimer <= 0)
			{
				if (GameManager.Instance.InputManager.IsShoot())
				{
					m_shootTimer = m_shootTime;
					return true;
				}
			}
			m_shootTimer -= ScalableTime.DeltaTime;
			return false;
		}

		protected override void Shoot()
		{
			LinearAccelBullet[] straightBullets = GameManager.Instance.BulletManagers.Straight.GetBullets(9);

			for (int i = 0; i < straightBullets.Length; i++)
			{
				straightBullets[i].Initialize(transform.position, new Vector3(i - 4, 5 + 1 * Mathf.Sin(((float)(i + 0.5) / (float)straightBullets.Length) * Mathf.PI), 0), Bullet.LAYER.FRIEND);
				straightBullets[i].SetConstantAcceleration(new Vector3(5 * Mathf.Cos(((float)(i + 0.5) / (float)straightBullets.Length) * Mathf.PI), 10, 0));
			}
		}
	}
}