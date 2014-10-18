using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.ai;
using Reversi.io;
using System.Diagnostics;

namespace Reversi.core
{
	/// <summary>
	/// ゲームの管理を行うクラスです。
	/// </summary>
	public class GameManager
	{
		/// <summary>
		/// ゲームで使用するボード
		/// </summary>
		private Board gameBoard;

		/// <summary>
		/// ゲームの履歴
		/// </summary>
		private List<BoardPoint> gameHistory;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public GameManager()
		{
			this.gameBoard = new Board();
			this.gameHistory = new List<BoardPoint>();
		}

		/// <summary>
		/// ゲームを開始します。
		/// </summary>
		/// <param name="first">先手のプレイヤー</param>
		/// <param name="second">後手のプレイヤー</param>
		/// <param name="viewer">ゲームビューワー</param>
		/// <param name="waitTimeMs">途中経過を表示する時間(ms)</param>
		public void startGame( Player first, Player second, GameViewer viewer, int displayTime )
		{
			// 引数チェック
			if( first == null )
			{
				throw new ArgumentNullException( "first", "Nullにはできません。" );
			}
			if( second == null )
			{
				throw new ArgumentNullException( "second", "Nullにはできません。" );
			}
			if( viewer == null )
			{
				throw new ArgumentNullException( "viewer", "Nullにはできません。" );
			}
			if( displayTime < 0 )
			{
				throw new ArgumentOutOfRangeException( "displayTime", "負の値にはできません。" );
			}

			this.gameHistory.Clear();
			this.gameBoard.setInitialPlacement();
			int pathCount = 0;
			String gameResult = null;

			viewer.viewMessage( "ゲームを開始" );

			while( true )
			{
				pathCount = this.playerSequence( first, TurnEnum.FIRST, viewer, pathCount, displayTime );
				if( pathCount >= 2 )
				{
					viewer.viewMessage( "連続でパスしました。" );
					break;
				}
				if( pathCount < 0 )
				{
					gameResult = "先手がギブアップしました。";
					break;
				}

				pathCount = this.playerSequence( second, TurnEnum.SECOND, viewer, pathCount, displayTime );
				if( pathCount >= 2 )
				{
					viewer.viewMessage( "連続でパスしました。" );
					break;
				}
				if( pathCount < 0 )
				{
					gameResult = "後手がギブアップしました。";
					break;
				}

				if( this.gameBoard.getStoneCount( TurnEnum.NONE ) == 0 )
				{
					viewer.viewMessage( "すべての場所に石が置かれました。" );
					break;
				}
			}

			viewer.viewBoard( this.gameBoard );

			int firstCount = this.gameBoard.getStoneCount( TurnEnum.FIRST );
			int secondCount = this.gameBoard.getStoneCount( TurnEnum.SECOND );
			if( gameResult == null )
			{
				if( firstCount > secondCount )
				{
					gameResult = "先手の勝ちです。";
				}
				else if( firstCount < secondCount )
				{
					gameResult = "後手の勝ちです。";
				}
				else
				{
					gameResult = "引き分けです。";
				}
			}

			viewer.viewGameResult( gameResult, firstCount, secondCount );
		}

		/// <summary>
		/// 1プレイヤー分の処理
		/// </summary>
		/// <param name="p">プレイヤー</param>
		/// <param name="turn">先手or後手</param>
		/// <param name="viewer">ゲームビューワ</param>
		/// <param name="pathCount">パスの回数</param>
		/// <param name="displayTime">途中経過を表示する時間(ms)</param>
		/// <returns>パスの回数。負の値の場合はギブアップ。</returns>
		private int playerSequence( Player p,
									TurnEnum turn,
									GameViewer viewer,
									int pathCount,
									int displayTime )
		{
			Debug.Assert( p != null, "プレイヤーがNullになっている" );
			Debug.Assert( turn != TurnEnum.NONE, "順番がNONEにっている" );
			Debug.Assert( viewer != null, "ビューワーがNullになっている。" );

			String turnString;
			if( turn == TurnEnum.FIRST )
			{
				turnString = "[先手]";
			}
			else
			{
				turnString = "[後手]";
			}

			viewer.viewBoard( this.gameBoard );

			System.Threading.Thread.Sleep( displayTime );

			NextMove nextMove = p.getNextMove( this.gameBoard, turn );
			if( nextMove == null )
			{
				// ギブアップ
				viewer.viewMessage( turnString + "ギブアップします。" );
				return -1;
			}
			if( nextMove.getPoint() == null )
			{
				// パス
				viewer.viewMessage( turnString + "パスします。" );
				return pathCount + 1;
			}
			else if( this.gameBoard.canPut( nextMove.getPoint(), turn ) == false )
			{
				// 置けない場所に石を置こうとした
				viewer.viewMessage( turnString + "指定の場所には石を置けません。" + nextMove.ToString() );
				viewer.viewMessage( turnString + "パスします。" );
				return pathCount + 1;
			}
			else
			{
				// 石を置く
				this.gameBoard.putStone( nextMove.getPoint(), turn );
				this.gameHistory.Add( nextMove.getPoint() );
				viewer.viewMessage( turnString + nextMove.getPoint().ToString() + "に石を置きました。" );
				return 0;
			}
		}

		/// <summary>
		/// ゲームの履歴を取得します。
		/// </summary>
		/// <returns>ゲームの履歴</returns>
		public List<BoardPoint> getHistory()
		{
			return new List<BoardPoint>( this.gameHistory );
		}

	}
}
