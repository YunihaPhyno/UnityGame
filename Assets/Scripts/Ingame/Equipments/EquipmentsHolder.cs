﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	/// <summary>
	/// 装備を持つことができるクラス
	/// 全ての装備はこれを通して装備される
	/// </summary>
	public class EquipmentsHolder
	{
		// このクラスを持っているTransform
		Transform m_parent;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="parent">このクラスを持っているクラスのTransform</param>
		public EquipmentsHolder(Transform parent)
		{
			m_parent = parent;

			// 親のレイヤーを自分の装備にも伝播する
			SetLayerAllEquipments(parent.gameObject.layer);
		}

		/// <summary>
		/// 親のレイヤーを自分の装備にも伝播する
		/// 孫以降にも再帰的に伝播する
		/// </summary>
		/// <param name="layer">親のレイヤー</param>
		public void SetLayerAllEquipments(int layer)
		{
			if(m_equipments == null)
			{
				return;
			}

			// 全ての装備に対して
			for(int i = 0; i < m_equipments.Count; i++)
			{
				// レイヤーを設定
				m_equipments[i].gameObject.layer = layer;

				// その装備が持っている装備にも伝播する
				m_equipments[i].GetEquipmentsHolder().SetLayerAllEquipments(layer);
			}
		}

		// 持っている装備のリスト
		private List<Equipment> m_equipments;

		/// <summary>
		/// 装備を追加する
		/// </summary>
		/// <param name="equipment">追加する装備</param>
		/// <param name="localPos">親のpositionを原点としたlocalPosition(単純にgameObject.localPositionが設定される)</param>
		public void AddEquipment(Equipment equipment, Vector3 localPos)
		{
			if(m_equipments == null)
			{
				m_equipments = new List<Equipment>();
			}

			// 追加したときの処理を実行
			equipment.OnAddedHolder(m_parent, localPos);

			// 追加
			m_equipments.Add(equipment);			
		}

		/// <summary>
		/// 持ってる全ての装備のInvokeUpdateを実行
		/// </summary>
		public void UpdateAllEquipments()
		{
			if(m_equipments == null)
			{
				return;
			}

			for(int i = 0; i < m_equipments.Count; i++)
			{
				m_equipments[i].InvokeUpdate();
				m_equipments[i].GetEquipmentsHolder().UpdateAllEquipments();
			}
		}

		public void FixedUpdateAllEquipments()
		{
			if(m_equipments == null)
			{
				return;
			}

			for(int i = 0; i < m_equipments.Count; i++)
			{
				m_equipments[i].InvokeFixedUpdate();
				m_equipments[i].GetEquipmentsHolder().FixedUpdateAllEquipments();
			}
		}

			/// <summary>
			/// 持ってる全ての装備を破棄
			/// </summary>
		public void DestroyAllEquipments()
		{
			if(m_equipments == null)
			{
				return;
			}

			for(int i = 0; i < m_equipments.Count; i++)
			{
				GameObject.Destroy(m_equipments[i].gameObject);
			}

			m_equipments = null;
		}
	}
}
