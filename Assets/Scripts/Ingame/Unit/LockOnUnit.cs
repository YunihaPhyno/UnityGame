using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	/// <summary>
	/// 何かをロックオンしたいときに使う
	/// </summary>
	public class LockOnUnit
	{
		// ロックオンしたオブジェクトのTransformを格納する
		private Transform m_targetTransform;

		/// <summary>
		/// ロックオン対象のターゲットをセット
		/// </summary>
		/// <param name="tgt">ロックオンするターゲットのTransfrom</param>
		public void SetTarget(Transform tgt){ m_targetTransform = tgt; }

		/// <summary>
		/// ロックオンしたターゲット情報を破棄する
		/// </summary>
		public void DropTarget(){ m_targetTransform = null; }

		/// <summary>
		/// このユニットにターゲットは設定されている？
		/// </summary>
		/// <returns>ターゲットが設定されていれば<c>true</c></returns>
		public bool TargetIsValid()
		{
			return (m_targetTransform != null);
		}

		/// <summary>
		/// ロックオンしたターゲットの位置情報を取得する
		/// </summary>
		/// <returns>The target position.</returns>
		public Vector3 GetTargetPosition()
		{
			if(m_targetTransform == null)
			{
				return Vector3.zero;
			}
			return m_targetTransform.position;
		}
	}
}
