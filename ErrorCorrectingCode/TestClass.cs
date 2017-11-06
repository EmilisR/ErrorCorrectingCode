using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ErrorCorrectingCode
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void TransposeMatrixTest()
        {
            var matrix = new byte[4, 4] { { 1, 0, 0, 1 }, { 0, 0, 1, 0 }, { 1, 1, 0, 0 }, { 0, 0, 1, 0 } };
            MatrixManager manager = new MatrixManager();
            var transposed = manager.TransposeMatrix(matrix);
            Assert.IsTrue(transposed.OfType<byte>().SequenceEqual(new byte[4, 4] { { 1, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 1, 0, 1 }, { 1, 0, 0, 0 } }.OfType<byte>()));
        }

        [TestMethod]
        public void TransposeMatrixDifferentRanksTest()
        {
            var matrix = new byte[3, 4] { { 1, 1, 0, 1 }, { 0, 1, 1, 1 }, { 0, 0, 0, 1 } };
            MatrixManager manager = new MatrixManager();
            var transposed = manager.TransposeMatrix(matrix);
            Assert.IsTrue(transposed.OfType<byte>().SequenceEqual(new byte[4, 3] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 0 }, { 1, 1, 1 } }.OfType<byte>()));
        }

        [TestMethod]
        public void GeneratingToParityCheckMatrixTest()
        {
            var matrix = new byte[2, 5] { { 1, 0, 1, 0, 1 }, { 0, 1, 1, 1, 0 } };
            MatrixManager manager = new MatrixManager();
            var parity = manager.GenerateParityCheckFromGeneratingMatrix(matrix);
            Assert.IsTrue(parity.OfType<byte>().SequenceEqual(new byte[3, 5] { { 1, 1, 1, 0, 0 }, { 0, 1, 0, 1, 0 }, { 1, 0, 0, 0, 1 } }.OfType<byte>()));
        }

        [TestMethod]
        public void MultiplyMatrixAndVectorTest()
        {
            var matrix = new byte[2, 5] { { 1, 0, 1, 0, 1 }, { 0, 1, 1, 1, 0 } };
            var vector = new byte[] { 1, 1, 1, 0, 0 };
            MatrixManager manager = new MatrixManager();
            var result = manager.MultiplyMatrixAndVector(matrix, vector);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 0, 0 }.OfType<byte>()));
        }

        [TestMethod]
        public void MultiplyMatrixAndVectorTest2()
        {
            var matrix = new byte[2, 5] { { 1, 0, 1, 0, 1 }, { 0, 1, 1, 1, 0 } };
            var vector = new byte[] { 1, 0, 1, 1, 1 };
            MatrixManager manager = new MatrixManager();
            var result = manager.MultiplyMatrixAndVector(matrix, vector);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0 }.OfType<byte>()));
        }

        [TestMethod]
        public void AddVectorTest()
        {
            var vector1 = new byte[] { 0, 0, 0, 1, 1 };
            var vector2 = new byte[] { 1, 0, 1, 1, 1 };
            MatrixManager manager = new MatrixManager();
            var result = manager.AddVector(vector1, vector2);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0, 0 }.OfType<byte>()));
        }

        [TestMethod]
        public void EncodeVectorTest()
        {
            var vector = new byte[] { 1, 0, 1, 0 };
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            EncodeManager manager = new EncodeManager();
            var result = manager.EncodeVector(vector, matrix);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0, 1, 0, 1 }.OfType<byte>()));
        }

        [TestMethod]
        public void EncodeVectorTest2()
        {
            var vector1 = new byte[] { 1, 1, 0 };
            var vector2 = new byte[] { 0, 1, 0 };
            var vector3 = new byte[] { 0, 0, 1 };
            var vector4 = new byte[] { 1, 1, 1 };
            var vector5 = new byte[] { 1, 0, 1 };
            var vector6 = new byte[] { 0, 1, 0 };
            var matrix = new byte[3, 4]
            {
                { 1, 1, 0, 0 },
                { 0, 1, 1, 1 },
                { 1, 0, 1, 0 }
            };
            EncodeManager manager = new EncodeManager();
            var result1 = manager.EncodeVector(vector1, matrix);
            var result2 = manager.EncodeVector(vector2, matrix);
            var result3 = manager.EncodeVector(vector3, matrix);
            var result4 = manager.EncodeVector(vector4, matrix);
            var result5 = manager.EncodeVector(vector5, matrix);
            var result6 = manager.EncodeVector(vector6, matrix);
            Assert.IsTrue(result1.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 1 }.OfType<byte>()));
            Assert.IsTrue(result2.OfType<byte>().SequenceEqual(new byte[] { 0, 1, 1, 1 }.OfType<byte>()));
            Assert.IsTrue(result3.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0 }.OfType<byte>()));
            Assert.IsTrue(result4.OfType<byte>().SequenceEqual(new byte[] { 0, 0, 0, 1 }.OfType<byte>()));
            Assert.IsTrue(result5.OfType<byte>().SequenceEqual(new byte[] { 0, 1, 1, 0 }.OfType<byte>()));
            Assert.IsTrue(result6.OfType<byte>().SequenceEqual(new byte[] { 0, 1, 1, 1 }.OfType<byte>()));
        }

        [TestMethod]
        public void GetEncodingTableTest()
        {
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            MatrixManager manager = new MatrixManager();
            var result = manager.GetEncodingTable(matrix, matrix.GetLength(0));
            Assert.IsTrue(result.Count == Math.Pow(2, matrix.GetLength(0)));
        }

        [TestMethod]
        public void DecodeVectorTest()
        {
            var vector = new byte[] { 1, 0, 1, 0, 1, 0, 1 };
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            DecodeManager manager = new DecodeManager();
            manager.PrepareForDecoding(matrix);
            var result = manager.DecodeVector(vector);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0 }.OfType<byte>()));
        }

        [TestMethod]
        public void DecodeAllVectorsTest()
        {
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            DecodeManager manager = new DecodeManager();
            manager.PrepareForDecoding(matrix);
            for (int i = 0; i < Math.Pow(2, matrix.GetLength(1)); i++)
            {
                var vector = Convert.ToString(i, 2).PadLeft(matrix.GetLength(1), '0').Select(x => (byte)char.GetNumericValue(x)).ToArray();
                var decodedVector = manager.DecodeVector(vector);
            }
        }

        [TestMethod]
        public void DecodeVectorOneErrorTest5_2()
        {
            var vector0 = new byte[] { 0, 0, 0, 0, 0 };
            var vector1 = new byte[] { 0, 0, 0, 0, 1 };
            var vector2 = new byte[] { 0, 0, 0, 1, 0 };
            var vector3 = new byte[] { 0, 0, 0, 1, 1 };
            var vector4 = new byte[] { 0, 0, 1, 0, 0 };
            var vector5 = new byte[] { 0, 0, 1, 0, 1 };
            var vector6 = new byte[] { 0, 0, 1, 1, 0 };
            var vector7 = new byte[] { 0, 0, 1, 1, 1 };
            var vector8 = new byte[] { 0, 1, 0, 0, 0 };
            var vector9 = new byte[] { 0, 1, 0, 0, 1 };
            var vector10 = new byte[] { 0, 1, 0, 1, 0 };
            var vector11 = new byte[] { 0, 1, 0, 1, 1 };
            var vector12 = new byte[] { 0, 1, 1, 0, 0 };
            var vector13 = new byte[] { 0, 1, 1, 0, 1 };
            var vector14 = new byte[] { 0, 1, 1, 1, 0 };
            var vector15 = new byte[] { 0, 1, 1, 1, 1 };
            var matrix = new byte[2, 5]
            {
                { 1, 0, 1, 1, 0 },
                { 0, 1, 0, 1, 1 }
            };
            DecodeManager manager = new DecodeManager();
            manager.PrepareForDecoding(matrix);
            var result0 = manager.DecodeVector(vector0);
            var result1 = manager.DecodeVector(vector1);
            var result2 = manager.DecodeVector(vector2);
            var result3 = manager.DecodeVector(vector3);
            var result4 = manager.DecodeVector(vector4);
            var result5 = manager.DecodeVector(vector5);
            var result6 = manager.DecodeVector(vector6);
            var result7 = manager.DecodeVector(vector7);
            var result8 = manager.DecodeVector(vector8);
            var result9 = manager.DecodeVector(vector9);
            var result10 = manager.DecodeVector(vector10);
            var result11 = manager.DecodeVector(vector11);
            var result12 = manager.DecodeVector(vector12);
            var result13 = manager.DecodeVector(vector13);
            var result14 = manager.DecodeVector(vector14);
            var result15 = manager.DecodeVector(vector15);

            Assert.IsTrue(result0.OfType<byte>().SequenceEqual(new byte[] { 0, 0 }.OfType<byte>()), $"0.Expected: [00], Actual: {string.Join("", result0.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result1.OfType<byte>().SequenceEqual(new byte[] { 0, 0 }.OfType<byte>()), $"1.Expected: [00], Actual: {string.Join("", result1.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result2.OfType<byte>().SequenceEqual(new byte[] { 0, 0 }.OfType<byte>()), $"2.Expected: [00], Actual: {string.Join("", result2.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result3.OfType<byte>().SequenceEqual(new byte[] { 0, 1 }.OfType<byte>()), $"3.Expected: [01], Actual: {string.Join("", result3.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result4.OfType<byte>().SequenceEqual(new byte[] { 0, 0 }.OfType<byte>()), $"4.Expected: [00], Actual: {string.Join("", result4.Select(x => x.ToString()).ToArray())}");
            //Assert.IsTrue(result5.OfType<byte>().SequenceEqual(new byte[] { 1, 1 }.OfType<byte>()), $"5.Expected: [11], Actual: {string.Join("", result5.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result6.OfType<byte>().SequenceEqual(new byte[] { 1, 0 }.OfType<byte>()), $"6.Expected: [10], Actual: {string.Join("", result6.Select(x => x.ToString()).ToArray())}");
            //Assert.IsTrue(result7.OfType<byte>().SequenceEqual(new byte[] { 0, 1 }.OfType<byte>()), $"7.Expected: [01], Actual: {string.Join("", result7.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result8.OfType<byte>().SequenceEqual(new byte[] { 0, 0 }.OfType<byte>()), $"8.Expected: [00], Actual: {string.Join("", result8.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result9.OfType<byte>().SequenceEqual(new byte[] { 0, 1 }.OfType<byte>()), $"9.Expected: [01], Actual: {string.Join("", result9.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result10.OfType<byte>().SequenceEqual(new byte[] { 0, 1 }.OfType<byte>()), $"10.Expected: [01], Actual: {string.Join("", result10.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result11.OfType<byte>().SequenceEqual(new byte[] { 0, 1 }.OfType<byte>()), $"11.Expected: [01], Actual: {string.Join("", result11.Select(x => x.ToString()).ToArray())}");
            //Assert.IsTrue(result12.OfType<byte>().SequenceEqual(new byte[] { 0, 0 }.OfType<byte>()), $"12.Expected: [00], Actual: {string.Join("", result12.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result13.OfType<byte>().SequenceEqual(new byte[] { 1, 1 }.OfType<byte>()), $"13.Expected: [11], Actual: {string.Join("", result13.Select(x => x.ToString()).ToArray())}");
            //Assert.IsTrue(result14.OfType<byte>().SequenceEqual(new byte[] { 1, 0 }.OfType<byte>()), $"14.Expected: [10], Actual: {string.Join("", result14.Select(x => x.ToString()).ToArray())}");
            Assert.IsTrue(result15.OfType<byte>().SequenceEqual(new byte[] { 0, 1 }.OfType<byte>()), $"15.Expected: [01], Actual: {string.Join("", result15.Select(x => x.ToString()).ToArray())}");
        }




        [TestMethod]
        public void DecodeVectorOneErrorPosition1Test()
        {
            var vector = new byte[] { 0, 0, 1, 0, 1, 0, 1 };
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            DecodeManager manager = new DecodeManager();
            manager.PrepareForDecoding(matrix);
            var result = manager.DecodeVector(vector);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0 }.OfType<byte>()), $"Expected: {1010}, Actual: {string.Join("", result.Select(x => x.ToString()).ToArray())}");
        }

        [TestMethod]
        public void DecodeVectorOneErrorPosition2Test()
        {
            var vector = new byte[] { 1, 1, 1, 0, 1, 0, 1 };
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            DecodeManager manager = new DecodeManager();
            manager.PrepareForDecoding(matrix);
            var result = manager.DecodeVector(vector);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0 }.OfType<byte>()), $"Expected: {1010}, Actual: {string.Join("", result.Select(x => x.ToString()).ToArray())}");
        }

        [TestMethod]
        public void DecodeVectorOneErrorPosition3Test()
        {
            var vector = new byte[] { 1, 0, 0, 0, 1, 0, 1 };
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            DecodeManager manager = new DecodeManager();
            manager.PrepareForDecoding(matrix);
            var result = manager.DecodeVector(vector);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0 }.OfType<byte>()), $"Expected: {1010}, Actual: {string.Join("", result.Select(x => x.ToString()).ToArray())}");
        }

        [TestMethod]
        public void DecodeVectorOneErrorPosition4Test()
        {
            var vector = new byte[] { 1, 0, 1, 1, 1, 0, 1 };
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            DecodeManager manager = new DecodeManager();
            manager.PrepareForDecoding(matrix);
            var result = manager.DecodeVector(vector);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0 }.OfType<byte>()), $"Expected: {1010}, Actual: {string.Join("", result.Select(x => x.ToString()).ToArray())}");
        }

        [TestMethod]
        public void DecodeVectorOneErrorPosition5Test()
        {
            var vector = new byte[] { 1, 0, 1, 0, 0, 0, 1 };
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            DecodeManager manager = new DecodeManager();
            manager.PrepareForDecoding(matrix);
            var result = manager.DecodeVector(vector);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0 }.OfType<byte>()), $"Expected: {1010}, Actual: {string.Join("", result.Select(x => x.ToString()).ToArray())}");
        }

        [TestMethod]
        public void DecodeVectorOneErrorPosition6Test()
        {
            var vector = new byte[] { 1, 0, 1, 0, 1, 1, 1 };
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            DecodeManager manager = new DecodeManager();
            manager.PrepareForDecoding(matrix);
            var result = manager.DecodeVector(vector);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0 }.OfType<byte>()), $"Expected: {1010}, Actual: {string.Join("", result.Select(x => x.ToString()).ToArray())}");
        }

        [TestMethod]
        public void DecodeVectorOneErrorPosition7Test()
        {
            var vector = new byte[] { 1, 0, 1, 0, 1, 0, 0 };
            var matrix = new byte[4, 7]
            {
                { 1, 0, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 1, 1 },
                { 0, 0, 0, 1, 1, 0, 0 }
            };
            DecodeManager manager = new DecodeManager();
            manager.PrepareForDecoding(matrix);
            var result = manager.DecodeVector(vector);
            Assert.IsTrue(result.OfType<byte>().SequenceEqual(new byte[] { 1, 0, 1, 0 }.OfType<byte>()), $"Expected: {1010}, Actual: {string.Join("", result.Select(x => x.ToString()).ToArray())}");
        }
    }
}
