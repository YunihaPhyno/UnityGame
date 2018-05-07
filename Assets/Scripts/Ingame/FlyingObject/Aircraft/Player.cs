using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System;

namespace Ingame
{
	public class Player : Aircraft
	{
		private float m_defaultSpeed = 5.0f;
		private float m_shootTimer = 0;
		private float m_shootTime;

		#region FlyingObjectParam
		protected override string GetTag()
		{
			return "Player";
		}

		protected override string GetLayerName()
		{
			return "Friend";
		}
		#endregion // FlyingObjectParam

		#region input
		/// <summary>InputManagerから受け取るためのクラス</summary>
		public class InputParameter
		{
			/// <summary>ゲームパッドからの入力を保持するクラス</summary>
			public class PlayerInput
			{
				public PlayerInput() : this(false, false, false, Vector3.zero) { }

				public PlayerInput(bool isShoot, bool isSpeedUp, bool isSpeedDown, Vector3 moveDirection)
				{
					IsShoot = isShoot;
					IsSpeedUp = isSpeedUp;
					IsSpeedDown = isSpeedDown;
					MoveDirection = moveDirection;
				}

				/// <summary>ショットボタンが押されているかどうか</summary>
				public bool IsShoot { get; private set; }

				/// <summary>スピードアップボタンが押されているかどうか</summary>
				public bool IsSpeedUp { get; private set; }

				/// <summary>スピードダウンボタンが押されているかどうか</summary>
				public bool IsSpeedDown { get; private set; }

				/// <summary>プレイヤーの入力した方向ベクトル(長さ1)</summary>
				public Vector3 MoveDirection { get; private set; }
			}

			/// <summary>ゲームパッドからの入力</summary>
			public PlayerInput Input { get; private set; }

			public InputParameter() : this(new PlayerInput()) { }

			public InputParameter(PlayerInput playerInput)
			{
				Input = playerInput;
			}
		}

		// 外部入力
		InputParameter m_inputParam = new InputParameter();

		public void Input(InputParameter param)
		{
			m_inputParam = param;
		}

		#endregion //input

		protected override Vector3 GetMoveVector()
		{
			float speed = CalculationSpeed(m_defaultSpeed, m_inputParam.Input);
			Vector3 moveVector = Mathv.CalculateMoveVector(m_inputParam.Input.MoveDirection, speed);
			return moveVector;
		}

		// inputに基づいた速度計算用。恐らくPlayerでしか使わないだろう
		private static float CalculationSpeed(float defaultSpeed, InputParameter.PlayerInput input)
		{
			float speed = defaultSpeed;

			if(input.IsSpeedUp)
			{
				speed *= 2;
			}

			else if(input.IsSpeedDown)
			{
				speed /= 2;
			}

			return speed;
		}

		protected override bool CanShoot()
		{
			m_shootTimer -= Time.deltaTime;
			if(m_shootTimer > 0)
			{
				return false;
			}

			if(m_inputParam.Input.IsShoot)
			{
				m_shootTimer = m_shootTime;
				return true;
			}

			return false;
		}

		public override void InvokeFixedUpdate()
		{
			ReloadAllTurrets();
		}

		private void ReloadAllTurrets()
		{
			List<Turret.Controller> turretControllers = GetTurretControllers();
			for(int i = 0; i < turretControllers.Count; i++)
			{
				if(!turretControllers[i].IsExisted())
				{
					continue;
				}

				if(turretControllers[i].IsReloaded())
				{
					continue;
				}

				LinearAccelBullet[] bullets = BulletSupplier.GetBullets<LinearAccelBullet>(3);

				InitializeBullets(bullets);

				turretControllers[i].Reload(bullets);
			}
		}

		private static void InitializeBullets(LinearAccelBullet[] bullets)
		{
			for(int i = 0; i < bullets.Length; i++)
			{
				bullets[i].SetParam(Vector3.up * 5, Bullet.LAYER.FRIEND);
			}
		}
	}
}