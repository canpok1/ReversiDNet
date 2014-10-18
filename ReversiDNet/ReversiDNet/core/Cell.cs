using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reversi.core
{
	/// <summary>
	/// ボードのマス目を表すクラスです。
	/// </summary>
	public class Cell
	{
		/// <summary>
		/// マス目に置いてある石
		/// </summary>
		private TurnEnum stone;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Cell()
		{
			this.stone = TurnEnum.NONE;
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="original">コピー元</param>
		/// <exception cref="ArgumentNullException">引数がNullの場合</exception>
		public Cell( Cell original )
		{
			if( original == null )
			{
				throw new ArgumentNullException( "original", "Nullにはできません。" );
			}
			this.setStone( original.getStone() );
		}

		/// <summary>
		/// マス目上の石を設定します。
		/// </summary>
		/// <param name="stone">マス目上の石</param>
		public void setStone( TurnEnum stone )
		{
			this.stone = stone;
		}

		/// <summary>
		/// 石の種類を取得します。
		/// </summary>
		/// <returns>マス目上の石</returns>
		public TurnEnum getStone()
		{
			return this.stone;
		}

		/// <summary>
		/// 置いてある石が同じかを比較します。
		/// </summary>
		/// <param name="obj">比較対象のオブジェクト</param>
		/// <returns>同じ種類の石ならtrue それ以外はfalse</returns>
		public override Boolean Equals( object obj )
		{
			if( obj == null )
			{
				return false;
			}

			if( obj is Cell )
			{
				Cell cell = (Cell)obj;

				if( this.stone == cell.stone )
				{
					return true;
				}
			}

			return false;
		}


		/// <summary>
		/// 置いてある石が同じかを比較します。
		/// </summary>
		/// <param name="cell">比較対象のオブジェクト</param>
		/// <returns>同じ種類の石ならture それ以外はfalse</returns>
		public Boolean Equals( Cell cell )
		{
			if( cell == null )
			{
				return false;
			}

			if( this.stone == cell.stone )
			{
				return true;
			}

			return false;
		}
	}
}
