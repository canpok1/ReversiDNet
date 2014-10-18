using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reversi.core
{
	/// <summary>
	/// ボード上の座標を表すクラスです。
	/// </summary>
	public class BoardPoint
	{
		/// <summary>
		/// X座標
		/// </summary>
		private int x;

		/// <summary>
		/// Y座標
		/// </summary>
		private int y;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		/// <exception cref="ArgumentOutOfRangeException">
		/// 座標がボード外の場合</exception>
		public BoardPoint( int x, int y )
		{
			this.setX( x );
			this.setY( y );
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="original">コピー元</param>
		/// <exception cref="ArgumentNullException">引数がNullの場合</exception>
		public BoardPoint( BoardPoint original )
		{
			// 引数チェック
			if( original == null )
			{
				throw new ArgumentNullException( "original", "Nullにはできません。" );
			}

			this.setX( original.getX() );
			this.setY( original.getY() );
		}

		/// <summary>
		/// X座標を設定します。
		/// </summary>
		/// <param name="x">X座標</param>
		/// <exception cref="ArgumentOutOfRangeException">座標がボード外の場合</exception>
		public void setX( int x )
		{
			// 引数チェック
			if( x < 0 )
			{
				throw new ArgumentOutOfRangeException( "x", "負の値にはできません。" );
			}
			if( x >= Board.WIDTH )
			{
				throw new ArgumentOutOfRangeException( 
					"x",
					Board.WIDTH + "以上の値にはできません。[" + x + "]" );
			}

			this.x = x;
		}

		/// <summary>
		/// Y座標を設定します。
		/// </summary>
		/// <param name="y">Y座標</param>
		/// <exception cref="ArgumentOutOfRangeException">座標がボード外の場合</exception>
		public void setY( int y )
		{
			// 引数チェック
			if( y < 0 )
			{
				throw new ArgumentOutOfRangeException( "y", "負の値にはできません。" );
			}
			if( y >= Board.HEIGHT )
			{
				throw new ArgumentOutOfRangeException(
					"y",
					Board.HEIGHT + "以上の値にはできません。" + y + "]" );
			}

			this.y = y;
		}

		/// <summary>
		/// X座標を取得します。
		/// </summary>
		/// <returns>X座標</returns>
		public int getX()
		{
			return this.x;
		}

		/// <summary>
		/// Y座標を取得します。
		/// </summary>
		/// <returns>Y座標</returns>
		public int getY()
		{
			return this.y;
		}

		/// <summary>
		/// 座標を文字列で表します。
		/// </summary>
		/// <returns>座標を表す文字列</returns>
		public override String ToString()
		{
			return "(x,y)=(" + this.getX() + "," + this.getY() + ")";
		}

		/// <summary>
		/// 座標を比較します。
		/// </summary>
		/// <param name="obj">比較対象のオブジェクト</param>
		/// <returns>座標が同じならtrue それ以外はfalse</returns>
		public override Boolean Equals( object obj )
		{
			if( obj == null )
			{
				return false;
			}

			if( obj is BoardPoint )
			{
				BoardPoint p = (BoardPoint)obj;

				if( this.x == p.x && this.y == p.y )
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 座標を比較します。
		/// </summary>
		/// <param name="obj">比較対象のオブジェクト</param>
		/// <returns>座標が同じならtrue それ以外はfalse</returns>
		public Boolean Equals( BoardPoint boardPoint )
		{
			if( boardPoint == null )
			{
				return false;
			}

			if( this.x == boardPoint.x && this.y == boardPoint.y )
			{
				return true;
			}

			return false;
		}

	}
}
