using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public abstract class Bullet : FlyingObjectBase
	{
		private Vector3 m_velocity;
		public Vector3 Velocity { get { return m_velocity; } protected set { m_velocity = value; } }
		private LAYER m_layer;

		public enum LAYER
		{
			FRIEND,
			ENEMY,
		}

		protected override string GetLayerName()
		{
			switch (m_layer)
			{
				case LAYER.FRIEND:
					return "FriendBullet";

				case LAYER.ENEMY:
					return "EnemyBullet";
			}

			Debug.LogError("Unknown Bullet Layer Name");
			return "Default";
		}

		public virtual void Initialize(Vector3 pos, Vector3 velocity, LAYER layer, int damage = 1, int hp = 1)
		{
			transform.position = pos;
			m_velocity = velocity;
			InitHp(hp);
			SetAttackPower(damage);
			SetHealPower(0);
			m_layer = layer;
			gameObject.SetActive(true);
			Start();
		}

		protected override string GetTag()
		{
			return "Bullet";
		}

		protected virtual void UpdateVelocity (){}

		protected sealed override Vector3 Move()
		{
			UpdateVelocity();
			return transform.position + m_velocity * ScalableTime.DeltaTime;
		}

		protected override void OnDamagedEvent(int value)
		{
			if(HP == 0)
			{
				gameObject.SetActive(false);
			}
		}
	}
}
