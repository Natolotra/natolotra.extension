using natolotra.extension.Enum;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace natolotra.extension.test
{
    internal enum EnumTest
    {
        [Description("Enum test none")]
        None = 0,
        [Description("Enum test anyone")]
        Anyone = 1,
        Neither = 2,
        Nobody = 11
    }

    internal static class EnumTestExt
    {
        public static string ToString(this EnumTest t) 
        {
            if (!t.Equals(11))
            { return t.ToString(); }
            else { return null; }
        }
    }

    internal struct Point : IConvertible
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        { X = x; Y = y; }

        public double GetValue()
        { return Math.Sqrt(X * X + Y * Y); }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider? provider)
        {
            if ((X != 0) || (Y != 0))
                return true;
            else
                return false;
        }

        public byte ToByte(IFormatProvider? provider)
        {
            return Convert.ToByte(GetValue());
        }

        public char ToChar(IFormatProvider? provider)
        {
            return Convert.ToChar(GetValue());
        }

        public DateTime ToDateTime(IFormatProvider? provider)
        {
            return Convert.ToDateTime(GetValue());
        }

        public decimal ToDecimal(IFormatProvider? provider)
        {
            return Convert.ToDecimal(GetValue());
        }

        public double ToDouble(IFormatProvider? provider)
        {
            return Convert.ToDouble(GetValue());
        }

        public short ToInt16(IFormatProvider? provider)
        {
            return Convert.ToInt16(GetValue());
        }

        public int ToInt32(IFormatProvider? provider)
        {
            return Convert.ToInt32(GetValue());
        }

        public long ToInt64(IFormatProvider? provider)
        {
            return Convert.ToInt64(GetValue());
        }

        public sbyte ToSByte(IFormatProvider? provider)
        {
            return Convert.ToSByte(GetValue());
        }

        public float ToSingle(IFormatProvider? provider)
        {
            return Convert.ToSingle(GetValue());
        }

        public string ToString(IFormatProvider? provider)
        {
            return Convert.ToString(GetValue());
        }

        public object ToType(Type conversionType, IFormatProvider? provider)
        {
            return Convert.ChangeType(GetValue(), conversionType);
        }

        public ushort ToUInt16(IFormatProvider? provider)
        {
            return Convert.ToUInt16(GetValue());
        }

        public uint ToUInt32(IFormatProvider? provider)
        {
            return Convert.ToUInt32(GetValue());
        }

        public ulong ToUInt64(IFormatProvider? provider)
        {
            return Convert.ToUInt64(GetValue());
        }
    }

    public class EnumExtensionTestU
    {
        [Fact]
        public void EnumExtensionToInt_01()
        {
            //Arrange
            var varEnum = EnumTest.Anyone;

            //Acte
            var result = varEnum.ToInt();

            //Assert
            result.Should().Be(1);
        }

        [Fact]
        public void EnumExtensionToInt_02()
        {
            //Arrange
            var varEnum = EnumTest.Nobody;

            //Acte
            var result = varEnum.ToInt();

            //Assert
            result.Should().Be(11);
        }

        [Fact]
        public void EnumExtensionToInt_03() 
        {
            //Arrange
            var varPoint = new Point(12, 11);

            //Acte and Assert
            varPoint.Invoking(p => p.ToInt()).Should().Throw<ArgumentException>(EnumConst.ENUM_TO_INT_MESSAGE_ARG_EXC);
        }


        [Fact]
        public void EnumExtensionGetDesc_01() 
        {
            //Arrange
            var varEnum = EnumTest.None;

            //Acte
            var result = varEnum.GetDesc();

            //Assert
            result.Should().Be("Enum test none");
        }

        [Fact]
        public void EnumExtensionGetDesc_02()
        {
            //Arrange
            var varEnum = EnumTest.Neither;

            //Acte
            var result = varEnum.GetDesc();

            //Assert
            result.Should().Be("Neither");
        }

        [Fact]
        public void EnumExtensionGetDesc_03()
        {
            //Arrange
            var varPoint = new Point(5, 7);

            //Acte and Assert
            varPoint.Invoking(p => p.GetDesc()).Should().Throw<ArgumentException>(EnumConst.ENUM_TO_INT_MESSAGE_ARG_EXC);
        }



        [Fact]
        public void EnumExtensionGetEnumValue_01()
        {
            //Arrange
            var varStr = "Neither";

            //Acte
            var result = varStr.GetEnumValue<EnumTest>();

            //Assert
            result.Should().Be(EnumTest.Neither);
        }

        [Fact]
        public void EnumExtensionGetEnumValue_02()
        {
            //Arrange
            var varPoint = "Test";

            //Acte and Assert
            varPoint.Invoking(p => p.GetEnumValue<EnumTest>()).Should().Throw<ArgumentException>(EnumConst.ENUM_GET_ENUM_VALUE_MESSAGE_ARG_VALUE_EXC);
        }

        [Fact]
        public void EnumExtensionGetEnumValue_03()
        {
            //Arrange
            var varStr = "11";

            //Acte
            var result = varStr.GetEnumValue<EnumTest>();

            //Assert
            result.Should().Be(EnumTest.Nobody);
        }
    }
}