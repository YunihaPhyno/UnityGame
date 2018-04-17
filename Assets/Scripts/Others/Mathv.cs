using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
	public class Mathv
	{
		/// <summary>
		/// 移動ベクトル計算用
		/// </summary>
		/// <param name="direction">移動方向</param>
		/// <param name="speed">移動速度</param>
		/// <returns>移動方向*移動速度*1フレームの時間</returns>
		public static Vector3 CalculateMoveVector(Vector3 direction, float speed)
		{
			return direction * speed * ScalableTime.DeltaTime;
		}
	}
}
