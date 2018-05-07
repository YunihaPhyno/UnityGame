using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public static class StageBuilder {
		// デバッグの書きなぐりあとでjson化する
		public static void Build(FlyingObjectManager flyingObjectManager, Transform parent)
		{
			Player(flyingObjectManager, parent);

	

		}

		private static void Player(FlyingObjectManager flyingObjectManager, Transform parent)
		{
			Player player = MakePlayer(parent);
			flyingObjectManager.AddObject(player);
		}

		private static Player MakePlayer(Transform parent)
		{
			GameObject playerObject = new GameObject("Player");
			Player player = playerObject.AddComponent<Player>();
			player.transform.parent = parent;
			player.SetParameter(GetPlayerParameter());
			return player;
		}

		private static Player.Parameter GetPlayerParameter()
		{
			var param = new Player.Parameter();
			param.position = new Vector3(0, -10, 0);
			param.maxHp = 20;
			param.currentHp = 10;
			param.attackPower = 1;
			param.healPower = 0;
			return param;
		}
	}
}
