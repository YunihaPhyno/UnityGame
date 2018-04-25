using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	/// <summary>
	/// 装備の抽象クラス
	/// 装備ホルダーを持つクラスに装備させることができる
	/// </summary>
	public abstract class Equipment : MonoBehaviour
	{
		#region EquipmentsHolder
		/// <summary>
		/// 実体。直接呼出し禁止。必ずGetEquipmentsHolder()を使うこと
		/// </summary>
		private EquipmentsHolder m_equipmentsHolder;
		
		/// <summary>
		/// 装備ホルダーを呼び出す。装備ホルダーのインスタンスが無ければ生成する。
		/// </summary>
		/// <returns>装備ホルダー</returns>
		public EquipmentsHolder GetEquipmentsHolder()
		{
			if(m_equipmentsHolder == null)
			{
				m_equipmentsHolder = new EquipmentsHolder(transform);
			}
			return m_equipmentsHolder;
		}
		#endregion // EquipmentsHolder

		/// <summary>装備ホルダーに追加されたときの処理</summary>
		public void OnAddedHolder(Transform parent, Vector3 localPos)
		{
			// 親を設定
			transform.parent = parent;

			// 位置を変更する
			transform.localPosition = localPos;

			// 親のレイヤーと同一になる
			gameObject.layer = parent.gameObject.layer;	

			// 自分の装備にもレイヤーを伝播する
			GetEquipmentsHolder().SetLayerAllEquipments(gameObject.layer);
		}

		/// <summary>
		/// Updateの代わり。overrideして使う
		/// </summary>
		public virtual void InvokeUpdate() { }

		public virtual void InvokeFixedUpdate() { }
	}
}
