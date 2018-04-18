using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public class Player : Aircraft
	{
		[SerializeField]
		private float m_defaultSpeed = 5.0f;

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

		#region input
		/// <summary>InputManagerから受け取るためのクラス</summary>
		public class InputParameter
		{
			/// <summary>ゲームパッドからの入力を保持するクラス</summary>
			public class PlayerInput
			{
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

			EnemyManager m_enemyManager = null;

			public InputParameter(PlayerInput playerInput, EnemyManager enemyManager)
			{
				Input = playerInput;
				m_enemyManager = enemyManager;
			}
		}

		// 外部入力
		InputParameter m_inputParam;

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
	}
}