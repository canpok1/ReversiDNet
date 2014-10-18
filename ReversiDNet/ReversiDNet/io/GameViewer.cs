using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.core;

namespace Reversi.io
{
	/// <summary>
	/// ゲームの状態を表示するインターフェースです。
	/// </summary>
	public interface GameViewer
	{
		/// <summary>
		/// ボードの状態を表示します。
		/// </summary>
		/// <param name="board">ボード</param>
		void viewBoard( Board board );

		/// <summary>
		/// ゲームの結果を表示します。
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <param name="firstCount">先手の石の数</param>
		/// <param name="secondCount">後手の石の数</param>
		void viewGameResult( String message, int firstCount, int secondCount );

		/// <summary>
		/// メッセージを表示します。
		/// </summary>
		/// <param name="message">メッセージ</param>
		void viewMessage( String message );
	}
}
