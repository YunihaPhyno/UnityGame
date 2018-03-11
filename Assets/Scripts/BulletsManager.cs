using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BulletManager<T>をまとめるクラス
/// </summary>
public class BulletsManager {

	StraightBulletManager m_straightBulletManager;

	public BulletsManager (int straight)
	{
		m_straightBulletManager = new StraightBulletManager(straight, "path");

	}
}
