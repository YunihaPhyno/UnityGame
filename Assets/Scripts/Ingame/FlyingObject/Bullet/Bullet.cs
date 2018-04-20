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

		// 存在できる時間(0になると自動消滅)
		float m_lifetime = float.MaxValue;

		/// <summary>
		/// 弾を初期化する(発射するときに使う)
		/// </summary>
		/// <param name="pos">初期位置</param>
		/// <param name="velocity">初速度</param>
		/// <param name="layer">レイヤー(当たり判定など)</param>
		/// <param name="damage">攻撃力</param>
		/// <param name="hp">耐久力</param>
		/// <param name="lifetime">滞空時間</param>
		public virtual void Initialize(Vector3 pos, Vector3 velocity, LAYER layer, int damage = 1, int hp = 1, float lifetime = float.MaxValue)
		{
			// 射出される位置へ移動
			transform.position = pos;

			// 初速度
			m_velocity = velocity;

			// HP初期化
			InitHp(hp);

			// 攻撃力設定
			SetAttackPower(damage);

			// 回復力設定(弾は回復しない(今のところ))
			SetHealPower(0);

			// 弾のレイヤー(当たり判定とかで使う)
			m_layer = layer;

			// 生存可能時間設定
			m_lifetime = lifetime;

			// ゲームオブジェクト起動
			gameObject.SetActive(true);

			// 強制的に初期化
			Start();
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
			if(HP == 0 || m_lifetime <= 0)
			{
				OnDestroyEvent();	
			}
		}

		private void OnDestroyEvent()
		{
			GetEquipmentsHolder().DestroyAllEquipments();
			gameObject.SetActive(false);
		}
	}
}
