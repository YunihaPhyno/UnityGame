using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
	public static class ScalableTime
	{
		const float MAX_DELTA_TIME = 1.0f / 60.0f * 2.0f;
		public static float scale = 1.0f;

		private static class Cache
		{
			static float deltaTime;
			static float scale;
			static float result;
			public static float Result { get { return result; } }

			public static bool IsSame(float _deltaTime, float _scale)
			{
				if(deltaTime != _deltaTime)
				{
					return false;
				}

				if(scale != _scale)
				{
					return false;
				}

				return true;
			}

			public static void Set(float _deltaTime, float _scale, float _result)
			{
				deltaTime = _deltaTime;
				scale = _scale;
				result = _result;
			}
		}
		
		public static float DeltaTime {
			get
			{
				float deltaTime = Time.deltaTime;

				if (!Cache.IsSame(deltaTime, scale))
				{
					float result = RestrictTime(Time.deltaTime) * scale;
					Cache.Set(deltaTime, scale, result);
				}

				return Cache.Result;
			}
		}
		private static float RestrictTime(float deltaTime)
		{
			if(deltaTime > MAX_DELTA_TIME)
			{
				return MAX_DELTA_TIME;
			}
			return deltaTime;
		}
	}
}
