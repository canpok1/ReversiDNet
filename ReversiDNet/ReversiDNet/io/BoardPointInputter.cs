using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.core;

namespace Reversi.io
{
	/// <summary>
	/// 次の手を取得する機能を提供するインターフェースです。
	/// </summary>
	public interface BoardPointInputter
	{
		/// <summary>
		/// メッセージを表示して次の手を取得します。
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		BoardPoint inputBoardPoint( String message );

		/// <summary>
		/// 確認メッセージを表示して選択結果を取得します。
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		ConfirmResultEnum inputConfirm( String message );
	}
}
