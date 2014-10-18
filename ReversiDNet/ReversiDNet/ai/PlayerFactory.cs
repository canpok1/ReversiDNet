using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.io;

namespace Reversi.ai
{
	/// <summary>
	/// プレイヤーを生成するクラスです。
	/// </summary>
	public class PlayerFactory
	{
		/// <summary>
		/// 座標を入力するプレイヤーの生成番号
		/// </summary>
		public const int HUMAN = 0;

		/// <summary>
		/// ランダムに配置するプレイヤー
		/// </summary>
		public const int RANDOM = 1;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private PlayerFactory()
		{
		}

		/// <summary>
		/// プレイヤーを生成します。
		/// </summary>
		/// <param name="playerNo">プレイヤーの生成番号</param>
		/// <returns>生成したプレイヤー</returns>
		public static Player create( int playerNo )
		{
			switch( playerNo )
			{
				case PlayerFactory.HUMAN:
					throw new ArgumentOutOfRangeException(
									"playerNo",
									playerNo + "のプレイヤー生成には別のメソッドを使用してください。" );
				case PlayerFactory.RANDOM :
					return new RandomSelectPlayer();
				default:
					throw new ArgumentOutOfRangeException(
									"playerNo",
									"対応するプレイヤーなし[" + playerNo + "]" );
			}
		}

		/// <summary>
		/// 次の手を入力によって決定するプレイヤーを生成します。
		/// </summary>
		/// <param name="inputter">入力</param>
		/// <returns>生成したプレイヤー</returns>
		public static Player create( BoardPointInputter inputter )
		{
			return new HumanPlayer( inputter );
		}
	}
}
