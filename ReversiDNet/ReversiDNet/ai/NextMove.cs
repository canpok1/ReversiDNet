using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.core;

namespace Reversi.ai
{
	/// <summary>
	/// 次の手を表すクラスです。
	/// </summary>
	public class NextMove
	{
		/// <summary>
		/// 次に指す手
		/// </summary>
		private BoardPoint boardPoint;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="p">次に差す手の座標。パスの場合はNull。</param>
		public NextMove( BoardPoint p )
		{
			if( p == null )
			{
				this.boardPoint = null;
			}
			else
			{
				this.boardPoint = new BoardPoint( p );
			}
		}

		/// <summary>
		/// 次に指す手の座標を取得します。
		/// </summary>
		/// <returns>次に差す手の座標。Nullの場合はパス。</returns>
		public BoardPoint getPoint()
		{
			if( this.boardPoint == null )
			{
				return null;
			}
			else
			{
				return new BoardPoint( this.boardPoint );
			}
		}
	}
}
