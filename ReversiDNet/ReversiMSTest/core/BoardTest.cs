using Reversi.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ReversiTest
{
    
    
    /// <summary>
    ///BoardTest のテスト クラスです。すべての
    ///BoardTest 単体テストをここに含めます
    ///</summary>
	[TestClass()]
	public class BoardTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///現在のテストの実行についての情報および機能を
		///提供するテスト コンテキストを取得または設定します。
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region 追加のテスト属性
		// 
		//テストを作成するときに、次の追加属性を使用することができます:
		//
		//クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//各テストを実行する前にコードを実行するには、TestInitialize を使用
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//各テストを実行した後にコードを実行するには、TestCleanup を使用
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion

		private Random random = new System.Random();

		/// <summary>
		/// 石をランダムに配置したボードを生成します。
		/// </summary>
		/// <returns></returns>
		private Board createRandomBoard()
		{
			Board board = new Board();

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					switch( random.Next( 3 ) )
					{
						case 0:
							board.setStone( x, y, TurnEnum.NONE );
							break;
						case 1:
							board.setStone( x, y, TurnEnum.FIRST );
							break;
						case 2:
							board.setStone( x, y, TurnEnum.SECOND );
							break;
					}
				}
			}

			return board;
		}

		/// <summary>
		/// 石をパターン1で配置したボードを生成します。
		/// <para>●－－●－－●－</para>
		/// <para>－○－○－○－－</para>
		/// <para>－－○○○－－－</para>
		/// <para>●○○－○○○●</para>
		/// <para>－－○○○－－－</para>
		/// <para>－○－○－○－－</para>
		/// <para>●－－○－－○－</para>
		/// <para>－－－●－－－●</para>
		/// </summary>
		/// <returns></returns>
		private Board createPatarn1( TurnEnum black, TurnEnum white )
		{
			Board board = new Board();

			board.setStone( 0, 0, black );
			board.setStone( 3, 0, black );
			board.setStone( 6, 0, black );
			board.setStone( 0, 3, black );
			board.setStone( 7, 3, black );
			board.setStone( 0, 6, black );
			board.setStone( 3, 7, black );
			board.setStone( 7, 7, black );

			board.setStone( 1, 1, white );
			board.setStone( 3, 1, white );
			board.setStone( 5, 1, white );
			board.setStone( 2, 2, white );
			board.setStone( 3, 2, white );
			board.setStone( 4, 2, white );
			board.setStone( 1, 3, white );
			board.setStone( 2, 3, white );
			board.setStone( 4, 3, white );
			board.setStone( 5, 3, white );
			board.setStone( 6, 3, white );
			board.setStone( 2, 4, white );
			board.setStone( 3, 4, white );
			board.setStone( 4, 4, white );
			board.setStone( 1, 5, white );
			board.setStone( 3, 5, white );
			board.setStone( 5, 5, white );
			board.setStone( 3, 6, white );
			board.setStone( 6, 6, white );

			return board;
		}

		/// <summary>
		/// 石をパターン2で配置したボードを生成します。
		/// <para>●－－●－－●－</para>
		/// <para>－●－●－●－－</para>
		/// <para>－－●●●－－－</para>
		/// <para>●●●●●●●●</para>
		/// <para>－－●●●－－－</para>
		/// <para>－●－●－●－－</para>
		/// <para>●－－●－－●－</para>
		/// <para>－－－●－－－●</para>
		/// </summary>
		/// <returns></returns>
		private Board createPatarn2( TurnEnum black, TurnEnum white )
		{
			Board board = this.createPatarn1( black, black );

			board.setStone( 3, 3, black );

			return board;
		}

		/// <summary>
		/// 石をパターン3で配置したボードを生成します。
		/// <para>－－－－－－●－</para>
		/// <para>－－－－－○－－</para>
		/// <para>－－－－○－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// </summary>
		/// <returns></returns>
		private Board createPatarn3( TurnEnum black, TurnEnum white )
		{
			Board board = new Board();

			board.setStone( 6, 0, black );
			board.setStone( 5, 1, white );
			board.setStone( 4, 2, white );

			return board;
		}

		/// <summary>
		/// 石をパターン4で配置したボードを生成します。
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－○○●－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// </summary>
		/// <returns></returns>
		private Board createPatarn4( TurnEnum black, TurnEnum white )
		{
			Board board = new Board();

			board.setStone( 6, 3, black );
			board.setStone( 5, 3, white );
			board.setStone( 4, 3, white );

			return board;
		}

		/// <summary>
		/// 石をパターン5で配置したボードを生成します。
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－○－－－</para>
		/// <para>－－－－－○－－</para>
		/// <para>－－－－－－●－</para>
		/// <para>－－－－－－－－</para>
		/// </summary>
		/// <returns></returns>
		private Board createPatarn5( TurnEnum black, TurnEnum white )
		{
			Board board = new Board();

			board.setStone( 6, 6, black );
			board.setStone( 5, 5, white );
			board.setStone( 4, 4, white );

			return board;
		}

		/// <summary>
		/// 石をパターン6で配置したボードを生成します。
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－○－－－－</para>
		/// <para>－－－○－－－－</para>
		/// <para>－－－●－－－－</para>
		/// <para>－－－－－－－－</para>
		/// </summary>
		/// <returns></returns>
		private Board createPatarn6( TurnEnum black, TurnEnum white )
		{
			Board board = new Board();

			board.setStone( 3, 6, black );
			board.setStone( 3, 5, white );
			board.setStone( 3, 4, white );

			return board;
		}

		/// <summary>
		/// 石をパターン7で配置したボードを生成します。
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－○－－－－－</para>
		/// <para>－○－－－－－－</para>
		/// <para>●－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// </summary>
		/// <returns></returns>
		private Board createPatarn7( TurnEnum black, TurnEnum white )
		{
			Board board = new Board();

			board.setStone( 0, 6, black );
			board.setStone( 1, 5, white );
			board.setStone( 2, 4, white );

			return board;
		}

		/// <summary>
		/// 石をパターン8で配置したボードを生成します。
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>●○○－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// </summary>
		/// <returns></returns>
		private Board createPatarn8( TurnEnum black, TurnEnum white )
		{
			Board board = new Board();

			board.setStone( 0, 3, black );
			board.setStone( 1, 3, white );
			board.setStone( 2, 3, white );

			return board;
		}

		/// <summary>
		/// 石をパターン9で配置したボードを生成します。
		/// <para>●－－－－－－－</para>
		/// <para>－○－－－－－－</para>
		/// <para>－－○－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// </summary>
		/// <returns></returns>
		private Board createPatarn9( TurnEnum black, TurnEnum white )
		{
			Board board = new Board();

			board.setStone( 0, 0, black );
			board.setStone( 1, 1, white );
			board.setStone( 2, 2, white );

			return board;
		}

		/// <summary>
		///Board コンストラクター のテスト
		///生成後は石が置かれていない状態かをテスト
		///</summary>
		[TestMethod()]
		public void BoardConstructorTest1()
		{
			Board target = new Board();

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					Assert.IsTrue( target.getStone( x, y ) == TurnEnum.NONE );
				}
			}
		}

		/// <summary>
		///Board コンストラクター のテスト
		///コンストラクタに与えたボードと同じ配置になっていることをテスト
		///</summary>
		[TestMethod()]
		public void BoardConstructorTest2()
		{
			// 何度か繰り返す
			for( int tryCount = 0; tryCount < 1000; tryCount++ )
			{
				Board original = this.createRandomBoard();
				Board copy = new Board( original );

				// 石の配置をチェック
				for( int y = 0; y < Board.HEIGHT; y++ )
				{
					for( int x = 0; x < Board.WIDTH; x++ )
					{
						Assert.IsTrue( original.getStone( x, y ) == copy.getStone( x, y ) );
					}
				}
			}

		}

		/// <summary>
		///canPut のテスト
		///置ける場所を指定した時にtrueを返すことをテスト
		///</summary>
		[TestMethod()]
		public void canPutTest1()
		{
			Board board = null;

			board = this.createPatarn3( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( 3, 3, TurnEnum.FIRST ) );

			board = this.createPatarn4( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( 3, 3, TurnEnum.FIRST ) );

			board = this.createPatarn5( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( 3, 3, TurnEnum.FIRST ) );

			board = this.createPatarn6( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( 3, 3, TurnEnum.FIRST ) );

			board = this.createPatarn7( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( 3, 3, TurnEnum.FIRST ) );

			board = this.createPatarn8( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( 3, 3, TurnEnum.FIRST ) );

			board = this.createPatarn9( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( 3, 3, TurnEnum.FIRST ) );

		}

		/// <summary>
		///canPut のテスト
		///置ける場所を指定した時にtrueを返すことをテスト
		///</summary>
		[TestMethod()]
		public void canPutTest2()
		{
			Board board = null;

			board = this.createPatarn3( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( new BoardPoint( 3, 3), TurnEnum.FIRST ) );

			board = this.createPatarn4( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( new BoardPoint( 3, 3 ), TurnEnum.FIRST ) );

			board = this.createPatarn5( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( new BoardPoint( 3, 3 ), TurnEnum.FIRST ) );

			board = this.createPatarn6( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( new BoardPoint( 3, 3 ), TurnEnum.FIRST ) );

			board = this.createPatarn7( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( new BoardPoint( 3, 3 ), TurnEnum.FIRST ) );

			board = this.createPatarn8( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( new BoardPoint( 3, 3 ), TurnEnum.FIRST ) );

			board = this.createPatarn9( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsTrue( board.canPut( new BoardPoint( 3, 3 ), TurnEnum.FIRST ) );

		}

		/// <summary>
		///canPut のテスト
		///置けない場所を指定した時にfalseを返すことをテスト
		///</summary>
		[TestMethod()]
		public void canPutTest3()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsFalse( board.canPut( 3, 3, TurnEnum.SECOND ) );
		}

		/// <summary>
		///canPut のテスト
		///置けない場所を指定した時にfalseを返すことをテスト
		///</summary>
		[TestMethod()]
		public void canPutTest4()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );
			Assert.IsFalse( board.canPut( new BoardPoint( 3, 3 ), TurnEnum.SECOND ) );
		}

		/// <summary>
		///canPut のテスト
		///nullを与えた時に例外が発生することをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void canPutTest5()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );
			board.canPut( null, TurnEnum.FIRST );
		}

		/// <summary>
		///clearAll のテスト
		///</summary>
		[TestMethod()]
		public void clearAllTest()
		{
			for( int tryCount = 0; tryCount < 1000; tryCount++ )
			{
				Board target = this.createRandomBoard();

				target.clearAll();

				for( int y = 0; y < Board.HEIGHT; y++ )
				{
					for( int x = 0; x < Board.WIDTH; x++ )
					{
						Assert.IsTrue( target.getStone( x, y ) == TurnEnum.NONE );
					}
				}
			}
		}

		/// <summary>
		///getPuttableSpaces のテスト
		///</summary>
		[TestMethod()]
		public void getPuttableSpacesTest1()
		{
			for( int tryCount = 0; tryCount < 1000; tryCount++ )
			{
				Board board = this.createRandomBoard();

				List<BoardPoint> firstPuttable = new List<BoardPoint>();
				List<BoardPoint> secondPuttable = new List<BoardPoint>();

				for( int y = 0; y < Board.HEIGHT; y++ )
				{
					for( int x = 0; x < Board.WIDTH; x++ )
					{
						BoardPoint p = new BoardPoint( x, y );
						if( board.canPut( p, TurnEnum.FIRST ) == true )
						{
							firstPuttable.Add( p );
						}
						if( board.canPut( p, TurnEnum.SECOND ) == true )
						{
							secondPuttable.Add( p );
						}
					}
				}

				CollectionAssert.AreEqual( firstPuttable, board.getPuttableSpaces( TurnEnum.FIRST ) );
				CollectionAssert.AreEqual( secondPuttable, board.getPuttableSpaces( TurnEnum.SECOND ) );

			}

		}

		/// <summary>
		///getPuttableSpaces のテスト
		///TurnEnum.NONEを与えると例外を発生することをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException(typeof(ArgumentException))]
		public void getPuttableSpacesTest2()
		{
			Board board = new Board();
			board.getPuttableSpaces( TurnEnum.NONE );
		}

		/// <summary>
		///getStone のテスト
		///</summary>
		[TestMethod()]
		public void getStoneTest1()
		{
			Board target = new Board();

			for( int tryCount = 0; tryCount < 1000; tryCount++ )
			{
				int x = this.random.Next( Board.WIDTH );
				int y = this.random.Next( Board.HEIGHT );
				TurnEnum stone = TurnEnum.NONE;
				switch( this.random.Next( 3 ) )
				{
					case 1:
						stone = TurnEnum.FIRST;
						break;
					case 2:
						stone = TurnEnum.SECOND;
						break;
				}

				target.setStone( x, y, stone );

				Assert.IsTrue( target.getStone( x, y ) == stone );
				Assert.IsTrue( target.getStone( new BoardPoint( x, y ) ) == stone );
			}
		}

		/// <summary>
		///getStone のテスト
		///nullを与えた時に例外が発生するかをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void getStoneTest2()
		{
			Board target = new Board();
			target.getStone( null );
		}

		/// <summary>
		///getStoneCount のテスト
		///</summary>
		[TestMethod()]
		public void getStoneCountTest()
		{
			int noneCount = 0;
			int firstCount = 0;
			int secondCount = 0;
			Board target = new Board();

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					switch( this.random.Next( 3 ) )
					{
						case 0:
							target.setStone( x, y, TurnEnum.NONE );
							noneCount++;
							break;
						case 1:
							target.setStone( x, y, TurnEnum.FIRST );
							firstCount++;
							break;
						case 2:
							target.setStone( x, y, TurnEnum.SECOND );
							secondCount++;
							break;
					}
				}
			}

			Assert.IsTrue( target.getStoneCount( TurnEnum.NONE ) == noneCount );
			Assert.IsTrue( target.getStoneCount( TurnEnum.FIRST ) == firstCount );
			Assert.IsTrue( target.getStoneCount( TurnEnum.SECOND ) == secondCount );
		}

		/// <summary>
		///putStone のテスト
		///先手が石を置いた時に正しく反転できているかをテスト
		///</summary>
		[TestMethod()]
		public void putStoneTest1()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );
			Board answer = this.createPatarn2( TurnEnum.FIRST, TurnEnum.SECOND );

			board.putStone( 3, 3, TurnEnum.FIRST );

			Assert.IsTrue( board.Equals( answer ) );
		}

		/// <summary>
		///putStone のテスト
		///先手が石を置いた時に正しく反転できているかをテスト
		///</summary>
		[TestMethod()]
		public void putStoneTest2()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );
			Board answer = this.createPatarn2( TurnEnum.FIRST, TurnEnum.SECOND );

			board.putStone( new BoardPoint( 3, 3 ), TurnEnum.FIRST );

			Assert.IsTrue( board.Equals( answer ) );
		}

		/// <summary>
		///putStone のテスト
		///後手が石を置いた時に正しく反転できているかをテスト
		///</summary>
		[TestMethod()]
		public void putStoneTest3()
		{
			Board board = this.createPatarn1( TurnEnum.SECOND, TurnEnum.FIRST );
			Board answer = this.createPatarn2( TurnEnum.SECOND, TurnEnum.FIRST );

			board.putStone( 3, 3, TurnEnum.SECOND );

			Assert.IsTrue( board.Equals( answer ) );
		}

		/// <summary>
		///putStone のテスト
		///後手が石を置いた時に正しく反転できているかをテスト
		///</summary>
		[TestMethod()]
		public void putStoneTest4()
		{
			Board board = this.createPatarn1( TurnEnum.SECOND, TurnEnum.FIRST );
			Board answer = this.createPatarn2( TurnEnum.SECOND, TurnEnum.FIRST );

			board.putStone( new BoardPoint( 3, 3 ), TurnEnum.SECOND );

			Assert.IsTrue( board.Equals( answer ) );
		}

		/// <summary>
		///putStone のテスト
		///置けない場所を与えた時に例外が発生することをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( ArgumentException ) )]
		public void putStoneTest5()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );

			board.putStone( 3, 3, TurnEnum.SECOND );
		}

		/// <summary>
		///putStone のテスト
		///置けない場所を与えた時に例外が発生することをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( ArgumentException ) )]
		public void putStoneTest6()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );

			board.putStone( new BoardPoint( 3, 3 ), TurnEnum.SECOND );
		}

		/// <summary>
		///putStone のテスト
		///nullを与えた時に例外が発生することをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void putStoneTest7()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );

			board.putStone( null, TurnEnum.SECOND );
		}

		/// <summary>
		///putStone のテスト
		///TurnEnum.NONEを与えた時に例外が発生することをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( ArgumentException ) )]
		public void putStoneTest8()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );

			board.putStone( 3, 3, TurnEnum.NONE );
		}

		/// <summary>
		///putStone のテスト
		///TurnEnum.NONEを与えた時に例外が発生することをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( ArgumentException ) )]
		public void putStoneTest9()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );

			board.putStone( new BoardPoint( 3, 3), TurnEnum.NONE );
		}

		/// <summary>
		///putStone のテスト
		///既に石が置いてある場所を与えた時に例外が発生することをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( ArgumentException ) )]
		public void putStoneTest10()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );

			board.putStone( 4, 3, TurnEnum.FIRST );
		}

		/// <summary>
		///putStone のテスト
		///既に石が置いてある場所を与えた時に例外が発生することをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( ArgumentException ) )]
		public void putStoneTest11()
		{
			Board board = this.createPatarn1( TurnEnum.FIRST, TurnEnum.SECOND );

			board.putStone( new BoardPoint( 4, 3 ), TurnEnum.FIRST );
		}


		/// <summary>
		///setInitialPlacement のテスト
		///次の並びになるかをテスト
		///●が先手、○が後手
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－○●－－－</para>
		/// <para>－－－●○－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		/// <para>－－－－－－－－</para>
		///</summary>
		[TestMethod()]
		public void setInitialPlacementTest()
		{
			Board target = createRandomBoard();
			target.setInitialPlacement();

			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					if( ( x == 3 && y == 3 )
						|| ( x == 4 && y == 4 ) )
					{
						Assert.IsTrue( target.getStone( x, y ) == TurnEnum.SECOND );
					}
					else if( ( x == 4 && y == 3 )
						|| ( x == 3 && y == 4 ) )
					{
						Assert.IsTrue( target.getStone( x, y ) == TurnEnum.FIRST );
					}
					else
					{
						Assert.IsTrue( target.getStone( x, y ) == TurnEnum.NONE );
					}
				}
			}
		}

		/// <summary>
		///setStone のテスト
		///正しい場所に石を配置できるかをテスト
		///</summary>
		[TestMethod()]
		public void setStoneTest1()
		{
			Board target = new Board();
			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					target.setStone( x, y, TurnEnum.FIRST );
					Assert.IsTrue( target.getStone( x, y ) == TurnEnum.FIRST );
					target.setStone( x, y, TurnEnum.SECOND );
					Assert.IsTrue( target.getStone( x, y ) == TurnEnum.SECOND );
					target.setStone( x, y, TurnEnum.NONE );
					Assert.IsTrue( target.getStone( x, y ) == TurnEnum.NONE );
				}
			}
		}

		/// <summary>
		///setStone のテスト
		///正しい場所に石を配置できるかをテスト
		///</summary>
		[TestMethod()]
		public void setStoneTest2()
		{
			Board target = new Board();
			for( int y = 0; y < Board.HEIGHT; y++ )
			{
				for( int x = 0; x < Board.WIDTH; x++ )
				{
					BoardPoint p = new BoardPoint( x, y );
					target.setStone( p, TurnEnum.FIRST );
					Assert.IsTrue( target.getStone( p ) == TurnEnum.FIRST );
					target.setStone( p, TurnEnum.SECOND );
					Assert.IsTrue( target.getStone( p ) == TurnEnum.SECOND );
					target.setStone( p, TurnEnum.NONE );
					Assert.IsTrue( target.getStone( p ) == TurnEnum.NONE );
				}
			}
		}

		/// <summary>
		///setStone のテスト
		///X座標の最小値より小さい場所には置けないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void setStoneTest3()
		{
			Board target = new Board();
			target.setStone( -1, 0, TurnEnum.FIRST );
		}

		/// <summary>
		///setStone のテスト
		///X座標の最大値より大きい場所には置けないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void setStoneTest4()
		{
			Board target = new Board();
			target.setStone( Board.WIDTH, 0, TurnEnum.FIRST );
		}

		/// <summary>
		///setStone のテスト
		///Y座標の最小値より小さい場所には置けないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void setStoneTest5()
		{
			Board target = new Board();
			target.setStone( 0, -1, TurnEnum.FIRST );
		}

		/// <summary>
		///setStone のテスト
		///Y座標の最大値より大きい場所には置けないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void setStoneTest6()
		{
			Board target = new Board();
			target.setStone( 0, Board.HEIGHT, TurnEnum.FIRST );
		}

		/// <summary>
		/// Equals のテスト
		/// ２つのインスタンスの石の配置が同じ場合にtrueを返すかをテスト
		/// </summary>
		[TestMethod()]
		public void EqualsTest1()
		{
			for( int tryCount = 0; tryCount < 1000; tryCount++ )
			{
				Board board1 = this.createRandomBoard();
				Board board2 = new Board( board1 );

				Assert.AreNotSame( board1, board2 );
				Assert.IsTrue( board1.Equals( board2 ) );
				Assert.IsTrue( board2.Equals( board1 ) );
			}
		}

		/// <summary>
		/// Equals のテスト
		/// ２つのインスタンスの石の配置が異なる場合にfalseを返すかをテスト
		/// </summary>
		[TestMethod()]
		public void EqualsTest2()
		{
			for( int tryCount = 0; tryCount < 1000; tryCount++ )
			{
				Board board1 = this.createRandomBoard();
				Board board2 = new Board( board1 );

				int x = this.random.Next( Board.WIDTH );
				int y = this.random.Next( Board.HEIGHT );

				board1.setStone( x, y, TurnEnum.FIRST );
				board2.setStone( x, y, TurnEnum.SECOND );

				Assert.AreNotEqual( board1, board2 );
				Assert.IsFalse( board1.Equals( board2 ) );
				Assert.IsFalse( board2.Equals( board1 ) );
			}
		}

		/// <summary>
		/// Equals のテスト
		/// nullを与えた場合にfalseを返すかをテスト
		/// </summary>
		[TestMethod()]
		public void EqualsTest3()
		{
			Board board = new Board();
			Assert.IsFalse( board.Equals( null ) );
		}

	}
}
