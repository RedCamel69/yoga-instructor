using SharedModels;

namespace Test
{
    public class ClassTests
    {
        [Fact]
        public void Class_Start_Time_Set_Correctly_PM ()
        {

            // arrange
            var newClass = new Class();


            // act
            newClass.StartTime = TimeOnly.FromDateTime(new DateTime(2024, 12, 6, 23, 45, 30));


            // assert
            Assert.True(newClass.StartTime.Hour == 23);
            //Assert.True(newClass.DisplayStartTime == "11 PM");

        }

        [Fact]
        public void Class_Start_Time_Set_Correctly_AM()
        {

            // arrange
            var newClass = new Class();


            // act
            newClass.StartTime = TimeOnly.FromDateTime(new DateTime(2024, 12, 6, 6, 45, 30));


            // assert
            Assert.True(newClass.StartTime.Hour == 6);
            //Assert.True(newClass.DisplayStartTime == " PM");

        }

        [Fact]
        public void Class_Display_Start_Time_Set_Correctly_PM()
        {

            // arrange
            var newClass = new Class();


            // act
            newClass.StartTime = TimeOnly.FromDateTime(new DateTime(2024, 12, 6, 23, 45, 30));


            // assert
            Assert.True(newClass.StartTime.Hour == 23);
            Assert.True(newClass.DisplayStartTime == "11 PM");

        }

        [Fact]
        public void Class_Display_Start_Time_Set_Correctly_AM()
        {

            // arrange
            var newClass = new Class();


            // act
            newClass.StartTime = TimeOnly.FromDateTime(new DateTime(2024, 12, 6, 6, 45, 30));


            // assert
            Assert.True(newClass.StartTime.Hour == 6);
            Assert.True(newClass.DisplayStartTime == "6 AM");

        }

        [Fact]
        public void Class_Display_Start_Time_Set_Correctly_For_Noon()
        {

            // arrange
            var newClass = new Class();


            // act
            newClass.StartTime = TimeOnly.FromDateTime(new DateTime(2024, 12, 6, 12, 00, 00));


            // assert
            Assert.True(newClass.StartTime.Hour == 12);
            Assert.True(newClass.DisplayStartTime == "12 noon");

        }

        [Fact]
        public void Class_Display_End_Time_Set_Correctly_For_Noon()
        {

            // arrange
            var newClass = new Class();


            // act
            newClass.EndTime = TimeOnly.FromDateTime(new DateTime(2024, 12, 6, 12, 00, 00));


            // assert
            Assert.True(newClass.EndTime.Hour == 12);
            Assert.True(newClass.DisplayEndTime == "12 noon");

        }
    }
}