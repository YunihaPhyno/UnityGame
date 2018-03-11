using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagerBase<T> where T : Bullet {

	private T[] m_ringBuffer;
	private int m_numMaxBullets;
	public int numMaxBullets { get { return m_numMaxBullets; } }

	public BulletManagerBase (int max, string prefabPath) 
	{
		m_numMaxBullets = max;
		m_ringBuffer = new T[max];

		GameObject prefab = Resources.Load<GameObject>(prefabPath);
		for(int i = 0; i < m_ringBuffer.Length; i++)
		{
			GameObject gobj = GameObject.Instantiate<GameObject> (prefab);
			m_ringBuffer[i] = gobj.GetComponent<T>();
		}
	}
}
