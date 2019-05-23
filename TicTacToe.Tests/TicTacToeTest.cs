using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicTacToe;
using Xunit;


namespace TicTacToe.Tests
{
    
    public class TicTacToeTest
    {
        State state = new State(new PictureBox[3, 3], null, null, null, false);
        [Fact]
        public void CheckVertical_ShouldBeTrue()
        {
            Sign[,] map = { { Sign.X, Sign.Nothing, Sign.Nothing }, { Sign.X, Sign.Nothing, Sign.Nothing }, { Sign.X, Sign.Nothing, Sign.Nothing } };
            state.Map = map;
            bool isVertical = state.CheckVertical(Sign.X);
            Assert.True(isVertical);
        }

        [Fact]
        public void CheckVertical_ShouldBefalse()
        {
            Sign[,] map = { { Sign.X, Sign.Nothing, Sign.Nothing }, { Sign.X, Sign.Nothing, Sign.Nothing }, { Sign.O, Sign.Nothing, Sign.Nothing } };
            state.Map = map;
            bool isVertical = state.CheckVertical(Sign.X);
            Assert.False(isVertical);
        }

        [Fact]
        public void CheckHorizontal_ShouldBeTrue()
        {
            Sign[,] map = { { Sign.Nothing, Sign.Nothing, Sign.Nothing }, { Sign.X, Sign.X, Sign.X }, { Sign.Nothing, Sign.Nothing, Sign.Nothing } };
            state.Map = map;
            bool isHorizontal = state.CheckHorizontal(Sign.X);
            Assert.True(isHorizontal);
        }

        [Fact]
        public void CheckHorizontal_ShouldBeFalse()
        {
            Sign[,] map = { { Sign.Nothing, Sign.Nothing, Sign.Nothing }, { Sign.X, Sign.X, Sign.Nothing }, { Sign.Nothing, Sign.Nothing, Sign.Nothing } };
            state.Map = map;
            bool isVertical = state.CheckHorizontal(Sign.X);
            Assert.False(isVertical);
        }

        [Fact]
        public void CheckTopLeftToBottomRightDiagonal_ShouldBeTrue()
        {
            Sign[,] map = { { Sign.X, Sign.Nothing, Sign.Nothing }, { Sign.X, Sign.X, Sign.Nothing }, { Sign.Nothing, Sign.Nothing, Sign.X } };
            state.Map = map;
            bool isDiagonal = state.CheckTopLeftToBottomRightDiagonal(Sign.X);
            Assert.True(isDiagonal);
        }

        [Fact]
        public void CheckTopLeftToBottomRightDiagonal_ShouldBeFalse()
        {
            Sign[,] map = { { Sign.Nothing, Sign.Nothing, Sign.Nothing }, { Sign.X, Sign.X, Sign.Nothing }, { Sign.Nothing, Sign.Nothing, Sign.Nothing } };
            state.Map = map;
            bool isDiagonal = state.CheckTopLeftToBottomRightDiagonal(Sign.X);
            Assert.False(isDiagonal);
        }

        [Fact]
        public void CheckBottomLeftToTopRightDiagonal_ShouldBeTrue()
        {
            Sign[,] map = { { Sign.Nothing, Sign.Nothing, Sign.X }, { Sign.X, Sign.X, Sign.X }, { Sign.X, Sign.Nothing, Sign.Nothing } };
            state.Map = map;
            bool isDiagonal = state.CheckBottomLeftToTopRightDiagonal(Sign.X);
            Assert.True(isDiagonal);
        }

        [Fact]
        public void CheckBottomLeftToTopRightDiagonal_ShouldBeFalse()
        {
            Sign[,] map = { { Sign.Nothing, Sign.Nothing, Sign.Nothing }, { Sign.X, Sign.X, Sign.X }, { Sign.Nothing, Sign.Nothing, Sign.Nothing } };
            state.Map = map;
            bool isDiagonal = state.CheckBottomLeftToTopRightDiagonal(Sign.X);
            Assert.False(isDiagonal);
        }
    }
}
