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
