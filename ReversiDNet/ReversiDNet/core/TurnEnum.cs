using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reversi.core
{
	/// <summary>
	/// ゲームの順番を表す列挙です。
	/// </summary>
	public enum TurnEnum
	{
		NONE,	// なし
		FIRST,	// 先手
		SECOND,	// 後手
	}
}
