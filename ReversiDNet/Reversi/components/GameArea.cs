using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLibDNet.Drawing;
using GLibDNet.Drawing.Shapes;
using Reversi.core;
using System.Drawing;
using Reversi.io;
using GLibDNet.Drawing.Elements;
using GLibDNet.Key;

namespace Reversi.components
{
	/// <summary>
	/// ゲーム領域を表すクラスです。
	/// </summary>
	public class GameArea : BaseGameElement, GameViewer, BoardPointInputter
	{
		/// <summary>
		/// ボード上の線の太さ
		/// </summary>
		private const int LINE_SIZE = 1;

		private const DrawUtil.ColorType UNSELECTED_COLOR = DrawUtil.ColorType.GREEN;
		private const DrawUtil.ColorType SELECTED_COLOR = DrawUtil.ColorType.RED;

		/// <summary>
		/// 背景
		/// </summary>
		private GLibDNet.Drawing.Shapes.Rectangle backGround;

		/// <summary>
		/// マス目
		/// </summary>
		private Cell[,] cells;

		/// <summary>
		/// テキスト領域
		/// </summary>
		private TextViewer textViewer;

		/// <summary>
		/// 選択されたマスのインデックス
		/// 見選択の場合はボード外の座標
		/// </summary>
		private Point selectedPoint;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		/// <param name="w">横幅</param>
		/// <param name="h">縦幅</param>
		public GameArea( int x, int y, int w, int h ) : base( x, y, w, h )
		{
			this.backGround = new GLibDNet.Drawing.Shapes.Rectangle( x, y, w, h );
			this.backGround.brush = DrawUtil.GetBrush( DrawUtil.ColorType.BLACK );

			int cellWidth = ( w - ( Board.WIDTH + 1 ) * LINE_SIZE ) / Board.WIDTH;
			int cellHeight = ( h - ( Board.HEIGHT + 1 ) * LINE_SIZE ) / Board.HEIGHT;

			if( cellWidth <= 0 )
			{
				throw new ArgumentException( "w", "横幅が狭すぎます。" );
			}
			if( cellHeight <= 0 )
			{
				throw new ArgumentException( "h", "縦幅が狭すぎます。" );
			}

			this.cells = new Cell[ 8, 8 ];
			for( int row = 0; row < Board.HEIGHT; row++ )
			{
				for( int col = 0; col < Board.WIDTH; col++ )
				{
					int cellX = x + LINE_SIZE + col * ( LINE_SIZE + cellWidth );
					int cellY = y + LINE_SIZE + row * ( LINE_SIZE + cellHeight );

					this.cells[ row, col ] = new Cell( cellX, cellY, cellWidth, cellHeight );
					this.cells[ row, col ].brush = DrawUtil.GetBrush( SELECTED_COLOR );
				}
			}

			this.textViewer = new TextViewer( 10, 500, "メッセージ" );
			this.textViewer.brush = DrawUtil.GetBrush( DrawUtil.ColorType.BLACK );
			this.textViewer.font = DrawUtil.GetFont( DrawUtil.FontType.GOSHIC, 20 );

			this.selectedPoint = new Point( Board.WIDTH, Board.HEIGHT );
		}

		/// <summary>
		/// 指定座標が領域内か判定します。
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		/// <returns>true:領域内 false:領域外</returns>
		public override bool isContain( int x, int y )
		{
			int left = this.getPoint().getIntegerX();
			int right = left + this.getSize().Width;
			int top = this.getPoint().getIntegerY();
			int bottom = top + this.getSize().Height;

			if( x >= left && x < right
				&& y >= top && y < bottom )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 描画
		/// </summary>
		/// <param name="g">描画先</param>
		/// <returns>描画後の振る舞い</returns>
		public override GLibDNet.Update.DrawResultEnum drawMyself( System.Drawing.Graphics g )
		{
			this.backGround.drawMyself( g );

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					this.cells[ y, x ].drawMyself( g );
				}
			}

			this.textViewer.drawMyself( g );

			return GLibDNet.Update.DrawResultEnum.ONCE;
		}

		/// <summary>
		/// マウスカーソルの位置を反映
		/// </summary>
		/// <param name="cursorPoint">マウスカーソルの座標</param>
		public void setMouseCursor( Point cursorPoint )
		{
			if( cursorPoint == null )
			{
				return;
			}

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					GLibDNet.Drawing.Shapes.Rectangle target = this.cells[y, x];
					if( target.isContain( cursorPoint.X, cursorPoint.Y ) == true )
					{
						target.brush = DrawUtil.GetBrush( SELECTED_COLOR );
						this.selectedPoint.X = x;
						this.selectedPoint.Y = y;
					}
					else
					{
						target.brush = DrawUtil.GetBrush( UNSELECTED_COLOR );
					}
				}
			}
		}

		/// <summary>
		/// メッセージを表示します。
		/// </summary>
		/// <param name="message">メッセージ</param>
		public void viewMessage( String message )
		{
			this.textViewer.setText( message );
		}


		/// <summary>
		/// ゲームの結果を表示します。
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <param name="firstCount">先手の石の数</param>
		/// <param name="secondCount">後手の石の数</param>
		public void viewGameResult( String message, int firstCount, int secondCount )
		{
			this.textViewer.setText( message );
		}

		/// <summary>
		/// ボードを表示します。
		/// </summary>
		/// <param name="board">ボード</param>
		public void viewBoard( Board board )
		{
			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					this.cells[y, x].setStone( board.getStone( x, y ) );
				}
			}
		}

		/// <summary>
		/// 確認入力
		/// </summary>
		/// <param name="message">メッセージ</param>
		public ConfirmResultEnum inputConfirm( String message )
		{
			this.textViewer.setText( message );

			Boolean selected = false;

			while( selected == false )
			{
				if( InputManager.getInstance().isOneTimeModeKeyPressed(
						InputManager.KeyCodeEnum.ML ) == true )
				{
					selected = true;
				}
			}

			return ConfirmResultEnum.OK;
		}

		/// <summary>
		/// 座標を入力
		/// </summary>
		/// <param name="message">メッセージ</param>
		public BoardPoint inputBoardPoint( String message )
		{
			this.textViewer.setText( message );

			while( true )
			{
				if( InputManager.getInstance().isOneTimeModeKeyPressed(
						InputManager.KeyCodeEnum.ML ) == true )
				{
					if( this.selectedPoint.X >= 0
						&& this.selectedPoint.X < Board.WIDTH
						&& this.selectedPoint.Y >= 0
						&& this.selectedPoint.Y < Board.HEIGHT )
					{
						return new BoardPoint(
												this.selectedPoint.X,
												this.selectedPoint.Y );
					}
				}
			}
		}
	}
}
