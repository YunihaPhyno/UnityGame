using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public abstract class FlyingObjectBase : MonoBehaviour
	{

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
			Rigidbody.MovePosition(Move());
		}

		/// <summary>
		/// 移動に関わる内容はここで実装してください。
		/// </summary>
		/// <returns>移動差分</returns>
		protected abstract Vector3 Move();
	}
}