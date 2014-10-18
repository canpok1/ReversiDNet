using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.core;

namespace Reversi.ai
{
	/// <summary>
	/// 置ける場所に適当に置くプレイヤーです。
	/// </summary>
	public class RandomSelectPlayer : Player
	{
		/// <summary>
		/// 乱数発生器
		/// </summary>
		private Random random = new Random();

		/// <summary>
		/// 次の手を決めます。
		/// </summary>
		/// <param name="currentBoard">現在のボード</param>
		/// <param name="stone">置く石</param>
		/// <returns>置く場所</returns>
		public NextMove getNextMove( Board currentBoard, TurnEnum stone )
		{
			if( currentBoard == null )
			{
				throw new ArgumentNullException( "currentBoard", "Nullにすることはできません。" );
			}

			List<BoardPoint> list = currentBoard.getPuttableSpaces(stone);

			if( list.Count == 0 )
			{
				return new NextMove( null );
			}

			int select = random.Next( list.Count );

			return new NextMove( list[select] );
		}
	}
}
