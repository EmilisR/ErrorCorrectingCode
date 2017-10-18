using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
