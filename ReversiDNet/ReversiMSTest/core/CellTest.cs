using Reversi.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ReversiTest
{
    
    
    /// <summary>
    ///CellTest のテスト クラスです。すべての
    ///CellTest 単体テストをここに含めます
    ///</summary>
	[TestClass()]
	public class CellTest
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


		/// <summary>
		///Cell コンストラクター のテスト
		///コンストラクタに与えたインスタンスのコピーが生成できることをテスト
		///</summary>
		[TestMethod()]
		public void CellConstructorTest1()
		{
			Cell original = new Cell();
			original.setStone( TurnEnum.FIRST );
			Cell target = new Cell( original );
			Assert.IsTrue( original.getStone() == target.getStone() );
		}

		/// <summary>
		///Cell コンストラクター のテスト
		///石が置かれていないことをテスト
		///</summary>
		[TestMethod()]
		public void CellConstructorTest2()
		{
			Cell target = new Cell();
			Assert.IsTrue( target.getStone() == TurnEnum.NONE );
		}

		/// <summary>
		///setStone のテスト
		///石を置けるかをテスト
		///</summary>
		[TestMethod()]
		public void setStoneTest()
		{
			Cell target = new Cell();

			TurnEnum stone = TurnEnum.FIRST;
			target.setStone( stone );
			Assert.IsTrue( stone == target.getStone() );

			stone = TurnEnum.SECOND;
			target.setStone( stone );
			Assert.IsTrue( stone == target.getStone() );

			stone = TurnEnum.NONE;
			target.setStone( stone );
			Assert.IsTrue( stone == target.getStone() );
		}

		/// <summary>
		/// Equals のテスト
		/// ２つのインスタンスの値が同じ時にtrueを返すかをテスト
		/// </summary>
		[TestMethod()]
		public void EqualsTest1()
		{
			Cell original = new Cell();
			Cell target = new Cell();

			original.setStone( TurnEnum.FIRST );
			target.setStone( TurnEnum.FIRST );

			Assert.AreNotSame( original, target );
			Assert.IsTrue( original.Equals( target ) );
			Assert.IsTrue( target.Equals( original ) );
		}

		/// <summary>
		/// Equals のテスト
		/// ２つのインスタンスの値が異なる時にfalseを返すかをテスト
		/// </summary>
		[TestMethod()]
		public void EqualsTest2()
		{
			Cell original = new Cell();
			Cell target = new Cell();

			original.setStone( TurnEnum.FIRST );
			target.setStone( TurnEnum.SECOND );

			Assert.AreNotEqual( original, target );
			Assert.IsFalse( original.Equals( target ) );
			Assert.IsFalse( target.Equals( original ) );
		}

		/// <summary>
		/// Equals のテスト
		/// nullを与えた時にfalseを返すかをテスト
		/// </summary>
		[TestMethod()]
		public void EqualsTest3()
		{
			Cell target = new Cell();
			Assert.IsFalse( target.Equals( null ) );
		}
	}
}
