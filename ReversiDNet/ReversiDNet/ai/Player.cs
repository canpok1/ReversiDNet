using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.core;

namespace Reversi.ai
{
	/// <summary>
	/// ゲームを行うプレイヤーを表すインターフェースです。
	/// </summary>
	public interface Player
	{
		/// <summary>
		/// 次の手を取得します。
		/// ギブアップするときはNullを返します。
		/// </summary>
		/// <param name="currentBoard">現在のボード</param>
		/// <param name="stone">置く石</param>
		/// <returns>次の手。Nullの場合はギブアップ</returns>
		NextMove getNextMove( Board currentBoard, TurnEnum stone );
	}
}
