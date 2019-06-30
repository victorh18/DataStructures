using Xunit;
using DataStructures;
using System;
using System.Collections;
using System.Linq;

namespace DataStructures.Tests{

    public class SorterTests{

        public SorterTests(){

        }

        [Fact]
        public void TestName()
        {
        //Given
        bool verify;
        int[] lol = {3,2,1,5,4};
        
        //When
        Sorter.QuickSort(lol);
        //verify = (lol[0] == 1 && lol[1] == 2 && lol[2] == 3 && lol[3] == 4 && lol[4] == 5);
        verify = lol.SequenceEqual(new int[] {1,2,3,4,5});

        //Then
        Assert.True(verify, "QuickSort tiene problemas de implementacion");
        }
    }
}