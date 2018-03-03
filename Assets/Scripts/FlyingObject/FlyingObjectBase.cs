using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlyingObjectBase : MonoBehaviour {

	Rigidbody m_rigidbody;
	protected Rigidbody Rigidbody
	{
		get {
			if (m_rigidbody == null) {
				m_rigidbody = GetComponent<Rigidbody>();
			}
			return m_rigidbody;
		}
	}

    // Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	/// <summary>
	/// 移動に関わる内容はここで実装します。
	/// (Updateで実効される関数)
	/// </summary>
	protected abstract void Move();
}
