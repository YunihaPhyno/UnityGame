using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	[CreateAssetMenu(menuName = "Manager/Create ResourceManager", fileName = "ResourceManager")]
	public class ResourceManager : ScriptableObject
	{
		[SerializeField]
		private GameObject m_straightBulletPrefab;
		public GameObject StraightBulletPrefab { get { return m_straightBulletPrefab; } }
	}
}
