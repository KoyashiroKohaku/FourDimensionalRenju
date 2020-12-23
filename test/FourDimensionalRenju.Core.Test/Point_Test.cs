using FourDimensionalRenju.Core;
using Xunit;

namespace FourDimensionalRenju.Core.Test
{
    public class Point_Test
    {
        [Fact]
        public void Constructor_Test()
        {
            for (byte x = 0; x < Point.X_COUNT; x++)
            {
                for (byte y = 0; y < Point.Y_COUNT; y++)
                {
                    for (byte z = 0; z < Point.Z_COUNT; z++)
                    {
                        for (byte s = 0; s < Point.S_COUNT; s++)
                        {
                            var point = new Point(x, y, z, s);
                            Assert.Equal(x, point.X);
                            Assert.Equal(y, point.Y);
                            Assert.Equal(z, point.Z);
                            Assert.Equal(s, point.S);
                        }
                    }
                }
            }
        }
    }
}
