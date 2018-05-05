using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public abstract class Bullet : FlyingObjectBase
	{
		#region FixedUpdate
		public override void InvokeFixedUpdate()
		{
			base.InvokeFixedUpdate();
			UpdateLocalRotation();
		}

		#region LocalVelocity
		private Vector3 m_localVelocity;
		public Vector3 LocalVelocity { get { return m_localVelocity; } protected set { m_localVelocity = value; } }

		// グローバル座標の速度を取得(重ければキャッシュを使うこと)
		public Vector3 Velocity { get { return transform.rotation * m_localVelocity; } }
		protected virtual void UpdateVelocity (){}
		#endregion // LocalVelocity

		#region ConstantRotation
		private Vector3 m_constantRotation = Vector3.zero;
		public Vector3 ConstantRotation { get { return m_constantRotation; } private set { m_constantRotation = value; } }
		public void SetConstantRotation(Vector3 value){ ConstantRotation = value; }
		public void AddConstantRotation(Vector3 value){ ConstantRotation += value; }

		float rotate_dtime = 0;
		public void UpdateLocalRotation() {
			rotate_dtime += Time.fixedDeltaTime;
			if(rotate_dtime > 0.032f) {// なぜか分からないけど32ms/回の制限をつけないとphysicsの計算量が爆発する
				transform.Rotate(ConstantRotation * Time.fixedDeltaTime);
				rotate_dtime = 0;
			}
		}//ConstantRotation; }
		#endregion // ConstantRotation
		#endregion // FixedUpdate

		// 存在できる時間(0になると自動消滅)
		float m_lifetime = float.MaxValue;

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

		// 発射されたか(trueのとき移動する)
		private bool m_isFired = false;

		// 発射命令(Turretがメッセージを送る)
		public void Fire(Vector3 position)
		{
			transform.position = position;
			gameObject.SetActive(true);
			m_isFired = true;
			Initialize();
		}

		/// <summary>
		/// 弾を初期化する(発射するときに使う)
		/// </summary>
		/// <param name="pos">初期位置</param>
		/// <param name="velocity">初速度</param>
		/// <param name="layer">レイヤー(当たり判定など)</param>
		/// <param name="damage">攻撃力</param>
		/// <param name="hp">耐久力</param>
		/// <param name="lifetime">滞空時間</param>
		public virtual void SetParam(Vector3 localVelocity, LAYER layer)
		{
			// 初速度(0,1,0基準)
			LocalVelocity = localVelocity;

			// 回復力設定(弾は回復しない(今のところ))
			SetHealPower(0);

			// 攻撃力設定
			SetAttackPower(1);

			// 弾のレイヤー(当たり判定とかで使う)
			m_layer = layer;

			// HP初期化
			InitHp(1);

			// 生存可能時間設定
			m_lifetime = float.MaxValue;
		}

		protected override string GetTag()
		{
			return "Bullet";
		}

		// bulletはlocalPosision(0,1,0)に向かって飛ぶ
		protected sealed override Vector3 GetMoveVector()
		{
			//発射されていなければ0になる
			if(!m_isFired)
			{
				return Vector3.zero;
			}

			UpdateVelocity();
			return Velocity * Time.deltaTime;
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

			m_isFired = false;
			m_constantRotation = new Vector3(0, 0, 0);
			m_lifetime = float.MaxValue;
			m_localVelocity = Vector3.zero;
			gameObject.SetActive(false);
		}
	}
}
