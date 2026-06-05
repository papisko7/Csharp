using System.Numerics;

namespace NumericTypesSuggester
{
	public static class TypeSuggester
	{
		public static string Suggest(BigInteger min, BigInteger max,
			bool isIntegral, bool mustBePrecise)
		{
			if (isIntegral)
			{
				return SuggestIntegral(min, max);
			}

			return SuggestFloatingPoint(min, max, mustBePrecise);
		}

		private static string SuggestIntegral(BigInteger min, BigInteger max)
		{
			if (min >= 0)
			{
				if (max <= byte.MaxValue)
				{
					return "byte";
				}

				if (max <= ushort.MaxValue)
				{
					return "ushort";
				}

				if (max <= uint.MaxValue)
				{
					return "uint";
				}

				if (max <= ulong.MaxValue)
				{
					return "ulong";
				}

				return "BigInteger";
			}

			if (min >= sbyte.MinValue && max <= sbyte.MaxValue)
			{
				return "sbyte";
			}

			if (min >= short.MinValue && max <= short.MaxValue)
			{
				return "short";
			}

			if (min >= int.MinValue && max <= int.MaxValue)
			{
				return "int";
			}

			if (min >= long.MinValue && max <= long.MaxValue)
			{
				return "long";
			}

			return "BigInteger";
		}

		private static string SuggestFloatingPoint(BigInteger min, BigInteger max, bool mustBePrecise)
		{
			if (mustBePrecise)
			{
				var decimalMin = new BigInteger(decimal.MinValue);
				var decimalMax = new BigInteger(decimal.MaxValue);

				if (min >= decimalMin && max <= decimalMax)
				{
					return "decimal";
				}

				return AppStrings.ImpossibleRepresentation;
			}

			var minAsDouble = (double)min;
			var maxAsDouble = (double)max;

			if (double.IsInfinity(minAsDouble) || double.IsInfinity(maxAsDouble))
			{
				return AppStrings.ImpossibleRepresentation;
			}

			var minAsFloat = (float)min;
			var maxAsFloat = (float)max;

			if (!float.IsInfinity(minAsFloat) && !float.IsInfinity(maxAsFloat))
			{
				return "float";
			}

			return "double";
		}
	}
}