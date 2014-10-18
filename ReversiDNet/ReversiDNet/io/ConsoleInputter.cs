using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.core;

namespace Reversi.io
{
	/// <summary>
	/// コンソールから入力をするクラスです。
	/// </summary>
	public class ConsoleInputter : BoardPointInputter
	{
		/// <summary>
		/// メッセージを表示しボードの座標を取得します。
		/// 負の値が入力された場合はNullを返します。
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <returns>入力された座標。負の値が入力されたらNull。</returns>
		public BoardPoint inputBoardPoint( String message )
		{
			if( String.IsNullOrEmpty( message ) == false )
			{
				System.Console.WriteLine( message );
			}

			Boolean complete = false;
			BoardPoint point = new BoardPoint(0, 0);

			while( complete == false )
			{
				try
				{
					System.Console.Write( "X => " );
					String strX = System.Console.ReadLine();
					int x = int.Parse( strX );
					if( x < 0 || x >= Board.WIDTH )
					{
						throw new ArgumentException( "X座標がボード外です。[" + x + "]" );
					}

					System.Console.Write( "Y => " );
					String strY = System.Console.ReadLine();
					int y = int.Parse( strY );
					if( y < 0 || y >= Board.HEIGHT )
					{
						throw new ArgumentException( "Y座標がボード外です。[" + y + "]" );
					}

					point.setX( x );
					point.setY( y );

					complete = true;
				}
				catch( Exception e )
				{
					System.Console.WriteLine( e.Message );
					ConfirmResultEnum isGiveup = this.inputConfirm( "ギブアップしますか？" );
					if( isGiveup == ConfirmResultEnum.OK )
					{
						complete = true;
						point = null;
					}
					else
					{
						System.Console.WriteLine( "座標を再入力してください。" );
					}
				}
			}

			return point;
		}

		/// <summary>
		/// 確認メッセージを表示し選択結果を取得します。
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <returns>選択結果</returns>
		public ConfirmResultEnum inputConfirm( String message )
		{
			if( String.IsNullOrEmpty( message ) == true )
			{
				throw new ArgumentException( "message", "メッセージを空にはできません。" );
			}

			Boolean complete = false;
			ConfirmResultEnum result = ConfirmResultEnum.OK;

			while( complete == false )
			{
				System.Console.WriteLine( message );
				System.Console.Write( "y or n => " );
				String input = System.Console.ReadLine();

				if( input.CompareTo( "y" ) == 0 )
				{
					result = ConfirmResultEnum.OK;
					complete = true;
				}
				else if( input.CompareTo( "n" ) == 0 )
				{
					result = ConfirmResultEnum.NG;
					complete = true;
				}
				else
				{
					System.Console.WriteLine( "入力値が不正です。" );
				}
			}

			return result;
		}
	}
}
