using FizzBuzz.Game;

namespace FizzBuzz.Tests
{
    public class GameTest
    {
        //[Fact]
        //public void ItExists()
        //{
        //    var game = new GameBoard();
        //    int number = 3;
        //    string output = game.GetWord(number);

        //}

        /*
         * Ben bir oyuncu olarak
         * 3 Sayısını gönderdiğimde
         * Fizz sonucunu almalıyım.
         */

        [Fact]
        public void Given_3_Then_Fizz()
        {
            //AAA:
            //Arrange            
            var game = new GameBoard();
            int number = 3;

            //Act:
            string output = game.GetWord(number);
            //Assert:

            Assert.Equal("Fizz", output);       



        }

        [Fact]
        public void Given_5_Then_Buzz()
        {
            //AAA:
            //Arrange            
            var game = new GameBoard();
            int number = 5;

            //Act:
            string output = game.GetWord(number);
            //Assert:

            Assert.Equal("Buzz", output);



        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        public void Given_Number_Then_Number(int number)
        {
            //AAA:
            //Arrange            
            var game = new GameBoard();
        

            //Act:
            string output = game.GetWord(number);
            //Assert:

            Assert.Equal(number.ToString(), output);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        public void Given_Multiply_3_Fizz(int number)
        {
            var game = new GameBoard();
            //Act:
            string output = game.GetWord(number);
            Assert.Equal("Fizz", output);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(35)]
        public void Given_Multiply_5_Buzz(int number)
        {
            var game = new GameBoard();
            //Act:
            string output = game.GetWord(number);
            Assert.Equal("Buzz", output);
        }


        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void Given_Multiply_15_Buzz(int number)
        {
            var game = new GameBoard();
            //Act:
            string output = game.GetWord(number);
            Assert.Equal("FizzBuzz", output);
        }



    }
}