using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.io;
using Reversi.core;

namespace Reversi.ai
{
	public class HumanPlayer : Player
	{
		/// <summary>
		/// 入力用
		/// </summary>
		private BoardPointInputter inputter;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="inputter">入力</param>
		/// <exception cref="ArgumentNullException">引数がNullの場合</exception>
		public HumanPlayer( BoardPointInputter inputter )
		{
			// 引数チェック
			if( inputter == null )
			{
				throw new ArgumentNullException( "inputter", "Nullにできません。" );
			}

			this.inputter = inputter;
		}

		/// <summary>
		/// 次の手を取得します。
		/// </summary>
		/// <param name="currentBoard">現在のボード</param>
		/// <param name="stone">置く石</param>
		/// <returns>次の手。ギブアップの場合はNull。</returns>
		public NextMove getNextMove( Board currentBoard, TurnEnum stone )
		{
			// 引数チェック
			if( currentBoard == null )
			{
				throw new ArgumentNullException( "currentBoard", "Nullにはできません。" );
			}
			if( stone == TurnEnum.NONE )
			{
				throw new ArgumentException( "stone", "先手か後手でなければなりません。" );
			}

			String turnString = (stone == TurnEnum.FIRST) ? "[先手]" : "[後手]";

			List<BoardPoint> list = currentBoard.getPuttableSpaces( stone );

			if( list.Count == 0 )
			{
				this.inputter.inputConfirm( "石を置く場所がないためパスします。" );
				return null;
			}
			else
			{
				BoardPoint point = this.inputter.inputBoardPoint(
										turnString + "石を置く場所を入力してください。" );
				NextMove nextMove = null;
				while( true )
				{
					// ギブアップかチェック
					if( point == null )
					{
						break;
					}
					// 置ける場所かをチェック
					if( currentBoard.canPut( point, stone ) == true )
					{
						nextMove = new NextMove( point );
						break;
					}

					point = this.inputter.inputBoardPoint(
									point.ToString() + "には置けないため別の場所を入力してください。" );
				}

				return nextMove;
			}
		}
	}
}
