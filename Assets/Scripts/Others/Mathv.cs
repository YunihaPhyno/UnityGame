using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
	public class Mathv
	{
		#region CalculateMoveVector
		/// <summary>
		/// 移動ベクトル計算用
		/// </summary>
		/// <param name="direction">移動方向</param>
		/// <param name="speed">移動速度</param>
		/// <returns>移動方向*移動速度*1フレームの経過時間</returns>
		public static Vector3 CalculateMoveVector(Vector3 direction, float speed)
		{
			return CalculateMoveVector(direction, speed, Time.deltaTime);
		}

		/// <summary>
		/// 移動ベクトル計算用
		/// </summary>
		/// <param name="direction">移動方向</param>
		/// <param name="speed">移動速度</param>
		/// <param name="deltaTime">経過時間</param>
		/// <returns>移動方向*移動速度*経過時間</returns>
		public static Vector3 CalculateMoveVector(Vector3 direction, float speed, float deltaTime)
		{
			return direction * speed * deltaTime;
		}
		#endregion CalculateMoveVector

		#region CalculateVelocity
		/// <summary>
		/// 速度ベクトル計算用
		/// </summary>
		/// <param name="prevVelocity">1フレーム前の速度</param>
		/// <param name="acceleration">加速度</param>
		/// <returns>1f前の速度+加速度*1フレームの経過時間</returns>
		public static Vector3 CalculateVelocity (Vector3 prevVelocity, Vector3 acceleration)
		{
			return CalculateVelocity(prevVelocity, acceleration, Time.deltaTime);
		}

		/// <summary>
		/// 速度ベクトル計算用
		/// </summary>
		/// <param name="prevVelocity">1フレーム前の速度</param>
		/// <param name="acceleration">加速度</param>
		/// <param name="deltaTime">経過時間</param>
		/// <returns>1f前の速度+加速度*経過時間</returns>
		public static Vector3 CalculateVelocity(Vector3 prevVelocity, Vector3 acceleration, float deltaTime)
		{
			return prevVelocity + acceleration * deltaTime;
		}
		#endregion // CalculateVelocity
	}
}
