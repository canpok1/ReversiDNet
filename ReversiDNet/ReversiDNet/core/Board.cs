using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Reversi.core
{
	/// <summary>
	/// リバーシのボードを表すクラスです。
	/// </summary>
	public class Board
	{
		// 方向を表す列挙
		private enum Direction
		{
			UP,
			RIGHT_UP,
			RIGHT,
			RIGHT_DOWN,
			DOWN,
			LEFT_DOWN,
			LEFT,
			LEFT_UP,
		}

		/// <summary>
		/// 横に並ぶマス目の数
		/// </summary>
		public static readonly int WIDTH = 8;

		/// <summary>
		/// 縦に並ぶマス目の数
		/// </summary>
		public static readonly int HEIGHT = 8;

		/// <summary>
		/// マス目
		/// [縦, 横]で指定する
		/// </summary>
		private Cell[,] cells;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Board()
		{
			this.cells = new Cell[ HEIGHT, WIDTH ];
			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					this.cells[y, x] = new Cell();
				}
			}
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="original">コピー元</param>
		/// <exception cref="ArgumentNullException">引数がNullの場合</exception>
		public Board( Board original )
			: this()
		{
			// 引数チェック
			if( original == null )
			{
				throw new ArgumentNullException( "original", "Nullにはできません。" );
			}

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					this.setStone( x, y, original.getStone( x, y ) );
				}
			}
		}

		/// <summary>
		/// 指定座標のマス目に石を配置します。
		/// </summary>
		/// <param name="p">座標</param>
		/// <param name="stone">石の種類</param>
		/// <exception cref="ArgumentNullException">引数がNullの場合</exception>
		public void setStone( BoardPoint p, TurnEnum stone )
		{
			// 引数チェック
			if( p == null )
			{
				throw new ArgumentNullException( "p", "Nullにはできません。" );
			}

			this.setStone( p.getX(), p.getY(), stone );
		}

		/// <summary>
		/// 指定座標のマス目に石を配置します。
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		/// <param name="stone">石の種類</param>
		/// <exception cref="ArgumentOutOfRangeException">座標がボード外の場合</exception>
		public void setStone( int x, int y, TurnEnum stone )
		{
			// 引数チェック
			this.checkRangeX( x );
			this.checkRangeY( y );

			this.cells[y, x].setStone( stone );
		}

		/// <summary>
		/// 指定座標のマス目に石を置きます。
		/// リバーシのルールに従って、周辺の石を反転します。
		/// </summary>
		/// <param name="p">座標</param>
		/// <param name="stone">石の種類</param>
		/// <exception cref="ArgumentNullException">引数がNullの場合</exception>
		/// <exception cref="ArgumentException">石の種類が先手・後手でない場合</exception>
		public void putStone( BoardPoint p, TurnEnum stone )
		{
			// 引数チェック
			if( p == null )
			{
				throw new ArgumentNullException( "p", "Nullにはできません。" );
			}
			this.putStone( p.getX(), p.getY(), stone );
		}

		/// <summary>
		/// 指定座標のマス目に石を置きます。
		/// リバーシのルールに従って、周辺の石を反転します。
		/// </summary>
		/// <param name="p">座標</param>
		/// <param name="stone">石の種類</param>
		/// <exception cref="ArgumentOutOfRangeException">座標がボードの範囲外の場合</exception>
		/// <exception cref="ArgumentException">石の種類が先手・後手でない場合</exception>
		public void putStone( int x, int y, TurnEnum stone )
		{
			// 引数チェック
			this.checkRangeX( x );
			this.checkRangeY( y );
			if( stone == TurnEnum.NONE )
			{
				throw new ArgumentException( "stone", "先手か後手でなければなりません。" );
			}
			if( this.getStone( x, y ) != TurnEnum.NONE )
			{
				throw new ArgumentException( " stone", "石がある場所は指定できません。" );
			}

			List<BoardPoint> targetStones = this.getReversTargets( x, y, stone );
			if( targetStones.Count == 0 )
			{
				throw new ArgumentException( "stone", "反転できる石がないため置けません。" );
			}
			foreach( BoardPoint target in targetStones )
			{
				this.reverse( target );
			}
			this.setStone( x, y, stone );
		}

		/// <summary>
		/// 指定座標の石を反転します。
		/// </summary>
		/// <param name="p">座標</param>
		private void reverse( BoardPoint p )
		{
			Debug.Assert( p != null, "引数がNull" );

			switch( this.getStone(p) )
			{
				case TurnEnum.FIRST :
					this.setStone( p, TurnEnum.SECOND );
					break;
				case TurnEnum.SECOND :
					this.setStone( p, TurnEnum.FIRST );
					break;
			}
		}

		/// <summary>
		/// 全てのマスから石を除去します。
		/// </summary>
		public void clearAll()
		{
			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					this.setStone( x, y, TurnEnum.NONE );
				}
			}
		}

		/// <summary>
		/// ゲーム開始時の配置に石を並べます。
		/// </summary>
		public void setInitialPlacement()
		{
			this.clearAll();
			this.setStone( 3, 4, TurnEnum.FIRST );
			this.setStone( 4, 3, TurnEnum.FIRST );
			this.setStone( 3, 3, TurnEnum.SECOND );
			this.setStone( 4, 4, TurnEnum.SECOND );
		}

		/// <summary>
		/// 指定座標の石の種類を取得します。
		/// </summary>
		/// <param name="p">座標</param>
		/// <returns>石の種類</returns>
		/// <exception cref="ArgumentNullException">引数がNullの場合</exception>
		public TurnEnum getStone( BoardPoint p )
		{
			// 引数チェック
			if( p == null )
			{
				throw new ArgumentNullException( "p", "Nullにはできません。" );
			}

			return this.getStone( p.getX(), p.getY() );
		}

		/// <summary>
		/// 指定座標の石の種類を取得します。
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		/// <returns>石の種類</returns>
		/// <exception cref="ArgumentOutOfRangeException">ボードの範囲外の場合</exception>
		public TurnEnum getStone( int x, int y )
		{
			// 引数チェック
			this.checkRangeX( x );
			this.checkRangeY( y );

			return this.cells[y, x].getStone();
		}

		/// <summary>
		/// ボード上の石の数を数えます。
		/// </summary>
		/// <param name="stone">石の種類</param>
		/// <returns>石の数</returns>
		public int getStoneCount( TurnEnum stone )
		{
			int count = 0;

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					if( this.getStone(x, y) == stone )
					{
						count++;
					}
				}
			}

			return count;
		}

		/// <summary>
		/// 石を置くことができるかを判定します。
		/// </summary>
		/// <param name="p">座標</param>
		/// <param name="stone">石</param>
		/// <returns>true:置ける false:置けない</returns>
		/// <exception cref="ArgumentNullException">引数がNULLの場合</exception>
		public Boolean canPut( BoardPoint p, TurnEnum stone )
		{
			// 引数チェック
			if( p == null )
			{
				throw new ArgumentNullException( "p", "Nullにはできません。" );
			}
			return this.canPut( p.getX(), p.getY(), stone );
		}

		/// <summary>
		/// 石を置くことができるかを判定します。
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		/// <param name="stone">石</param>
		/// <returns>true:置ける false:置けない</returns>
		/// <exception cref="ArgumentOutOfRangeException">ボードの範囲外の場合</exception>
		public Boolean canPut( int x, int y, TurnEnum stone )
		{
			// 引数チェック
			this.checkRangeX( x );
			this.checkRangeY( y );

			if( this.getStone( x, y ) != TurnEnum.NONE )
			{
				// すでに石が置いてある
				return false;
			}

			List<BoardPoint> targetList = this.getReversTargets( x, y, stone );

			if( targetList.Count == 0 )
			{
				// 石を反転できない
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// 石を置くことで反転する石を取得します。
		/// </summary>
		/// <param name="puttedStoneX">石を置いた場所のX座標</param>
		/// <param name="puttedStoneY">石をおいた場所のY座標</param>
		/// <param name="puttedStone">置いた石の種類</param>
		/// <returns>反転できる石の座標</returns>
		private List<BoardPoint> getReversTargets(
											int puttedStoneX,
											int puttedStoneY,
											TurnEnum puttedStone )
		{
			String point = "(x,y)=(" + puttedStoneX + "," + puttedStoneY + ")";
			Debug.Assert( puttedStoneX >= 0 && puttedStoneX < Board.WIDTH,
						"座標がボード外を指している。" + point );
			Debug.Assert( puttedStoneY >= 0 && puttedStoneY < Board.WIDTH,
						"座標がボード外を指している。" + point );

			List<BoardPoint> targetList = new List<BoardPoint>();

			if( this.getStone( puttedStoneX, puttedStoneY ) != TurnEnum.NONE )
			{
				// すでに石が置いてある
				return targetList;
			}

			Direction[] directions = {
										Direction.UP,
										Direction.RIGHT_UP,
										Direction.RIGHT,
										Direction.RIGHT_DOWN,
										Direction.DOWN,
										Direction.LEFT_DOWN,
										Direction.LEFT,
										Direction.LEFT_UP };

			foreach( Direction d in directions )
			{
				targetList.AddRange(
					this.getReversTargetsOneDirection( d, puttedStoneX, puttedStoneY, puttedStone ) );
			}

			return targetList;
		}

		/// <summary>
		/// 反転できる石の座標を取得します。
		/// </summary>
		/// <param name="direction">チェックする方向</param>
		/// <param name="puttedStoneX">石を置いた場所のX座標</param>
		/// <param name="puttedStoneY">石を置いた場所のY座標</param>
		/// <param name="puttedStone">置いた石の種類</param>
		/// <returns>反転できる石の座標</returns>
		private List<BoardPoint> getReversTargetsOneDirection(	
											Direction direction,
											int puttedStoneX,
											int puttedStoneY,
											TurnEnum puttedStone )
		{
			BoardPoint point = new BoardPoint( puttedStoneX, puttedStoneY );
			Debug.Assert( puttedStoneX >= 0 && puttedStoneX < Board.WIDTH,
						"座標がボード外を指している。" + point.ToString() );
			Debug.Assert( puttedStoneY >= 0 && puttedStoneY < Board.WIDTH,
						"座標がボード外を指している。" + point.ToString() );
			Debug.Assert( this.getStone( point ) == TurnEnum.NONE,
						"石が置いてある場所を選択している。" );

			// 方向に合わせる
			int vx = 0;
			int vy = 0;

			switch( direction )
			{
				case Direction.UP:
					vy = -1;
					break;
				case Direction.RIGHT_UP:
					vx = 1;
					vy = -1;
					break;
				case Direction.RIGHT:
					vx = 1;
					break;
				case Direction.RIGHT_DOWN:
					vx = 1;
					vy = 1;
					break;
				case Direction.DOWN:
					vy = 1;
					break;
				case Direction.LEFT_DOWN:
					vx = -1;
					vy = 1;
					break;
				case Direction.LEFT:
					vx = -1;
					break;
				case Direction.LEFT_UP:
					vx = -1;
					vy = -1;
					break;
			}

			// 反転候補の石の座標リスト
			List<BoardPoint> reversableList = new List<BoardPoint>();

			// チェック対象の石の座標
			int targetX = puttedStoneX;
			int targetY = puttedStoneY;
			TurnEnum targetStone = this.getStone(targetX, targetY);

			while( true )
			{
				// チェック対象の座標を移動
				targetX += vx;
				targetY += vy;

				if( targetX < 0
					|| targetX >= Board.WIDTH
					|| targetY < 0
					|| targetY >= Board.HEIGHT )
				{
					// ボードの範囲外
					reversableList.Clear();
					break;
				}

				targetStone = getStone( targetX, targetY );

				if( targetStone == puttedStone )
				{
					// 置いた石と同じ種類の石ならチェック終了
					break;
				}

				if( targetStone == TurnEnum.NONE )
				{
					// 石がないなら反転候補をなしにしてチェック終了
					reversableList.Clear();
					break;
				}

				reversableList.Add( new BoardPoint( targetX, targetY ) );
			}

			return reversableList;
		}

		/// <summary>
		/// X座標の範囲をチェックします。
		/// </summary>
		/// <param name="x">X座標</param>
		/// <exception cref="ArgumentOutOfRangeException">ボードの範囲外の場合</exception>
		private void checkRangeX(int x)
		{
			if( x < 0 || x >= Board.WIDTH )
			{
				throw new ArgumentOutOfRangeException( "x", "ボードの範囲外です。[" + x + "]" );
			}
		}

		/// <summary>
		/// Y座標の範囲をチェックします。
		/// </summary>
		/// <param name="y">Y座標</param>
		/// <exception cref="ArgumentOutOfRangeException">ボードの範囲外の場合</exception>
		private void checkRangeY( int y )
		{
			if( y < 0 || y >= Board.HEIGHT )
			{
				throw new ArgumentOutOfRangeException( "y", "ボードの範囲外です。[" + y + "]" );
			}
		}

		/// <summary>
		/// 石を置くことができる場所の数を取得します。
		/// </summary>
		/// <param name="stone">置く石の種類</param>
		/// <returns>置ける場所</returns>
		public List<BoardPoint> getPuttableSpaces( TurnEnum stone )
		{
			// 引数チェック
			if( stone == TurnEnum.NONE )
			{
				throw new ArgumentException( "stone", "石を指定しなければなりません。" );
			}

			List<BoardPoint> list = new List<BoardPoint>();

			for(int y = 0; y < Board.WIDTH; y++)
			{
				for(int x = 0; x < Board.HEIGHT; x++ )
				{
					if( this.canPut(x, y, stone ) == true )
					{
						list.Add( new BoardPoint( x, y ) );
					}
				}
			}

			return list;
		}


		/// <summary>
		/// 石の配置が等しいかをチェックします。
		/// </summary>
		/// <param name="obj">比較対象のオブジェクト</param>
		/// <returns>石の配置が等しいならtrue それ以外はfalse</returns>
		public override Boolean Equals( object obj )
		{
			if( obj == null )
			{
				return false;
			}

			if( !( obj is Board ) )
			{
				return false;
			}

			Board board = (Board)obj;

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					if( this.getStone( x, y ) != board.getStone( x, y ) )
					{
						return false;
					}
				}
			}

			return true;
		}


		/// <summary>
		/// 石の配置が等しいかをチェックします。
		/// </summary>
		/// <param name="board">比較対象</param>
		/// <returns>石の配置が等しいならtrue それ以外はfalse</returns>
		public Boolean Equals( Board board )
		{
			if( board == null )
			{
				return false;
			}

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					if( this.getStone( x, y ) != board.getStone( x, y ) )
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
