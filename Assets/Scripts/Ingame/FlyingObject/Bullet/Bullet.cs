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

		#region LAYER
		public enum LAYER
		{
			FRIEND,
			ENEMY,
		}

		private LAYER m_layer;

		protected override string GetLayerName()
		{
			switch(m_layer)
			{
				case LAYER.FRIEND:
					return "FriendBullet";

				case LAYER.ENEMY:
					return "EnemyBullet";
			}

			Debug.LogError("Unknown Bullet Layer Name");
			return "Default";
		}
		#endregion // LAYER

		float m_lifetime;

		public virtual void Initialize(Vector3 pos, Vector3 velocity, LAYER layer, int damage = 1, int hp = 1, float lifetime = float.MaxValue)
		{
			transform.position = pos;
			m_velocity = velocity;
			InitHp(hp);
			SetAttackPower(damage);
			SetHealPower(0);
			m_layer = layer;
			gameObject.SetActive(true);
			Start();
			m_lifetime = lifetime;
		}

		protected override string GetTag()
		{
			return "Bullet";
		}

		protected virtual void UpdateVelocity (){}

		protected sealed override Vector3 GetMoveVector()
		{
			UpdateVelocity();
			return m_velocity * Time.deltaTime;
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
