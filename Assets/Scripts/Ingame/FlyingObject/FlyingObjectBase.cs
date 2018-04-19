using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public abstract class FlyingObjectBase : MonoBehaviour
	{
		#region HP
		/// <summary>
		/// HPの最大値
		/// </summary>
		[SerializeField]
		private int m_maxHp = int.MaxValue;

		/// <summary>
		/// HPの最大値を取得します。
		/// </summary>
		public int MaxHp { get { return m_maxHp; } }

		/// <summary>
		/// HPの最大値を設定します。
		/// </summary>
		/// <param name="maxhp">HPの最大値</param>
		protected void SetMaxHp (int maxhp) { m_maxHp = maxhp; }

		/// <summary>
		/// 現在のHP。(0～MaxHp)
		/// </summary>
		[SerializeField]
		private int m_currentHp = int.MaxValue;

		/// <summary>
		/// 現在のHPを取得します。(0～MaxHp)
		/// </summary>
		public int HP {
			get { return m_currentHp; }
			private set
			{
				if (value > MaxHp)
				{
					m_currentHp = m_maxHp;
				}
				else if (value < 0)
				{
					m_currentHp = 0;
				}
				else
				{
					m_currentHp = value;
				}
			}
		}

		/// <summary>
		/// 現在のHPを設定します。(0～MaxHp)
		/// </summary>
		/// <param name="hp"></param>
		protected void SetHp(int hp)
		{
			HP = hp;
		}

		/// <summary>
		/// HPの最大値をセットして現在のHPも更新します。
		/// </summary>
		/// <param name="hp">HP</param>
		protected void InitHp(int hp)
		{
			SetMaxHp(hp);
			SetHp(hp);
		}

		#endregion

		#region Attack
		/// <summary>
		/// 攻撃力
		/// </summary>
		[SerializeField]
		private int m_attackPower = 0;

		/// <summary>
		/// 攻撃力を取得します。
		/// </summary>
		public int AttackPower { get { return m_attackPower; } }
		
		/// <summary>
		/// 攻撃力を設定します。
		/// </summary>
		/// <param name="power">攻撃力</param>
		protected void SetAttackPower (int power){ m_attackPower = power; }

		/// <summary>
		/// HPを減少させます。(0～MaxHp)
		/// </summary>
		/// <param name="damage"></param>
		protected void Damaged(int damage)
		{
			if(damage < 0)
			{
				return;
			}
			HP -= damage;
			OnDamagedEvent(damage);
		}

		protected virtual void OnDamagedEvent (int value){}
		#endregion

		#region Initialize
		/// <summary>
		/// このスクリプトがアクティブになったときに呼ばれる(もしくは強制初期化したいとき)
		/// </summary>
		protected void Start()
		{
			SetTag();
			SetLayer();
			Initialize();
		}

		/// <summary>
		/// 初期化用(Startの代わり)
		/// </summary>
		protected virtual void Initialize(){}

		/// <summary>
		/// タグのセット
		/// </summary>
		private void SetTag()
		{
			gameObject.tag = GetTag();
		}

		/// <summary>
		/// タグを取得する(Startで初期化する用)
		/// </summary>
		/// <returns>タグ</returns>
		protected abstract string GetTag();

		/// <summary>
		/// レイヤーのセット
		/// </summary>
		private void SetLayer()
		{
			SetLayerAllChildren(transform, LayerMask.NameToLayer(GetLayerName()));
		}

		private static void SetLayerAllChildren(Transform transform, int layer)
		{
			if(transform == null)
			{
				return;
			}

			transform.gameObject.layer = layer;

			Transform[] transforms = transform.GetComponentsInChildren<Transform>(true);
			for (int i = 0; i < transforms.Length; i++)
			{
				if(transform == transforms[i])
				{
					continue;
				}
				SetLayerAllChildren(transforms[i], layer);
			}
		}

		/// <summary>
		/// レイヤーを取得する
		/// </summary>
		/// <returns></returns>
		protected abstract string GetLayerName();
		#endregion // Initialize


		#region Heal
		/// <summary>
		/// 回復力
		/// </summary>
		[SerializeField]
		private int m_healPower = 0;

		/// <summary>
		/// 回復力を取得します。
		/// </summary>
		public int HealPower { get { return m_healPower; } }

		/// <summary>
		/// 回復力を設定します。
		/// </summary>
		/// <param name="power">回復力</param>
		protected void SetHealPower (int power){ m_healPower = power; }

		/// <summary>
		/// HPを回復させます。(0～MaxHp)
		/// </summary>
		/// <param name="heal">回復値</param>
		protected void Healed(int heal)
		{
			if (heal < 0)
			{
				return;
			}

			HP += heal;

			OnHealEvent(heal);
		}

		/// <summary>
		/// ヒールが行われたときのコールバック
		/// </summary>
		/// <param name="value">回復値</param>
		protected virtual void OnHealEvent(int value){}
		#endregion

		Rigidbody m_rigidbody;

		// いる？
		private Rigidbody Rigidbody
		{
			get
			{
				if (m_rigidbody == null)
				{
					m_rigidbody = GetComponent<Rigidbody>(); // まだ初期化されていなければrigidbodyをgameobjectから取得
				}
				return m_rigidbody;
			}
		}

		/// <summary>
		/// 移動の実行
		/// (Updateの中で実行される)
		/// </summary>
		public void DoMove()
		{
			Rigidbody.MovePosition(transform.position + GetMoveVector());
		}

		/// <summary>
		/// 移動に関わる内容はここで実装してください。
		/// </summary>
		/// <returns>移動差分</returns>
		protected abstract Vector3 GetMoveVector();

		#region Collision
		/// <summary>
		/// 衝突した時のコールバック
		/// </summary>
		/// <param name="other"></param>
		private void OnTriggerEnter(Collider other)
		{
			OnCollisionFlyingObject(other);
		}

		/// <summary>
		/// FlyingObject同士が接触したときの処理。
		/// ぶつかった相手の攻撃力分自分のHPを減少させて、回復力分HPを上昇させる。
		/// </summary>
		/// <param name="other"></param>
		private void OnCollisionFlyingObject(Collider other)
		{

			FlyingObjectBase flyingObj = other.GetComponentInChildren<FlyingObjectBase>();
			if (flyingObj == null)
			{
				//retry
				flyingObj = other.transform.parent.GetComponentInChildren<FlyingObjectBase>();
				if (flyingObj == null)
				{
					return;
				}
			}

			Damaged(flyingObj.AttackPower);
			Healed(flyingObj.HealPower);
		}
		#endregion // Collision
	}
}