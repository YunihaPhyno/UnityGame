using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class FlyingObjectManager
	{
		#region Initialize
		private FlyingObjectBase[] m_flyingObjects;

		private List<FlyingObjectBase> m_tmpFlyingObjectsList = new List<FlyingObjectBase>();

		public void AddObject(List<FlyingObjectBase> objList)
		{
			m_tmpFlyingObjectsList.AddRange(objList);
		}

		/// <summary>
		/// マネージャーが管理するオブジェクトを追加します。
		/// Addし終わったらCommitObjectを実行してください。
		/// </summary>
		/// <param name="obj">Object.</param>
		public void AddObject(FlyingObjectBase obj)
		{
			m_tmpFlyingObjectsList.Add(obj);
		}

		/// <summary>
		/// Addされたオブジェクトを管理下におきます
		/// </summary>
		public void CommitObject()
		{
			m_flyingObjects = m_tmpFlyingObjectsList.ToArray();
		}
		#endregion //Initialize

		#region CommonProcess
		delegate void PartProcessDelegate(FlyingObjectBase obj);
		private void CommonProcess(PartProcessDelegate processDelegate)
		{
			if(m_flyingObjects == null)
			{
				return;
			}

			for(int i = 0; i < m_flyingObjects.Length; i++)
			{
				if(m_flyingObjects[i] == null)
				{
					continue;
				}

				processDelegate(m_flyingObjects[i]);
			}
		}
		#endregion // CommonProcess

		#region Processes
		public void DoInitialize()
		{
			CommonProcess((obj) => { obj.Initialize(); });
		}

		public void DoUpdate()
		{
			CommonProcess((obj) => { obj.InvokeUpdate(); });
		}

		public void DoFixedUpdate()
		{
			CommonProcess((obj) => { obj.InvokeFixedUpdate(); });
		}

		public void DoMove()
		{
			CommonProcess((obj) => { obj.InvokeMove(); });
		}
		#endregion // Processes
	}
}
