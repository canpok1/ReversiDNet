using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.core;

namespace Reversi.io
{
	/// <summary>
	/// コンソールに出力するためのクラスです。
	/// </summary>
	public class ConsoleViewer : GameViewer
	{
		/// <summary>
		/// 先手の石があるマス目
		/// </summary>
		private const String FIRST_STONE = "Ｏ";

		/// <summary>
		/// 後手の石があるマス目
		/// </summary>
		private const String SECOND_STONE = "Ｘ";

		/// <summary>
		/// 石がないマス目
		/// </summary>
		private const String NOTHING = "・";

		/// <summary>
		/// ボードの状態を出力します。
		/// </summary>
		/// <param name="board">ボード</param>
		public void viewBoard( Board board )
		{
			// 引数チェック
			if( board == null )
			{
				throw new ArgumentNullException( "board", "Nullにはできません。" );
			}

			System.Console.WriteLine( "======================" );

			System.Console.Write(" ");
			for( int x = 0; x < Board.WIDTH; x++ )
			{
				System.Console.Write( " " + x );
			}
			System.Console.WriteLine();

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				System.Console.Write( y );
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					switch( board.getStone( x, y ) )
					{
						case TurnEnum.NONE:
							System.Console.Write( ConsoleViewer.NOTHING );
							break;
						case TurnEnum.FIRST:
							System.Console.Write( ConsoleViewer.FIRST_STONE );
							break;
						case TurnEnum.SECOND:
							System.Console.Write( ConsoleViewer.SECOND_STONE );
							break;
					}
				}
				System.Console.WriteLine();
			}
			System.Console.WriteLine(
				"先手:" + ConsoleViewer.FIRST_STONE + " "
				+ "後手:" + ConsoleViewer.SECOND_STONE );
			System.Console.WriteLine( "======================" );

		}

		/// <summary>
		/// ゲームの結果を表示します。
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <param name="firstCount">先手の石の数</param>
		/// <param name="secondCount">後手の石の数</param>
		public void viewGameResult( String message, int firstCount, int secondCount )
		{
			System.Console.WriteLine( message );
			System.Console.WriteLine( "先手:" + firstCount + " 後手:" + secondCount );
		}


		/// <summary>
		/// メッセージを表示します。
		/// </summary>
		/// <param name="message">メッセージ</param>
		public void viewMessage( String message )
		{
			System.Console.WriteLine( message );
		}
	}
}
