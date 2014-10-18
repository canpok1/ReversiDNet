using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLibDNet.Update;

namespace Reversi.scenes
{
	/// <summary>
	/// リバーシのパラメータを表すクラスです。
	/// </summary>
	public class ReversiParameters : SceneParameter
	{
		/// <summary>
		/// P1(先手)の強さ
		/// </summary>
		private int p1Level;

		/// <summary>
		/// P2(後手)の強さ
		/// </summary>
		private int p2Level;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="p1Level">先手の強さ</param>
		/// <param name="p2Level">後手の強さ</param>
		/// <exception cref="ArgumentOutOfRangeException">引数が負の場合</exception>
		public ReversiParameters( int p1Level, int p2Level )
		{
			if( p1Level < 0 )
			{
				throw new ArgumentOutOfRangeException( "p1Level", "負の値にはできません。" );
			}
			if( p2Level < 0 )
			{
				throw new ArgumentOutOfRangeException( "p2Level", "負の値にはできません。" );
			}

			this.p1Level = p1Level;
			this.p2Level = p2Level;
		}

		/// <summary>
		/// 先手の強さを取得します。
		/// </summary>
		/// <returns>先手の強さ</returns>
		public int getP1Level()
		{
			return this.p1Level;
		}

		/// <summary>
		/// 後手の強さを取得します。
		/// </summary>
		/// <returns>後手の強さ</returns>
		public int getP2Level()
		{
			return this.p2Level;
		}
	}
}
