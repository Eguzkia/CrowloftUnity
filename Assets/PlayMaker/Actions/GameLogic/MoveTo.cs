using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory(ActionCategory.GameLogic)]
	public class MoveTo : FsmStateAction
	{

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			Finish();
		}


	}

}
