namespace SignalR_Poc.Extensions
{
	public static class EnumExtensions
	{
		public static string EnumToString<TEnum>(this TEnum value) where TEnum : Enum
		{
			return Enum.GetName(typeof(TEnum), value) ?? string.Empty;
		}

		public static TEnum StringToEnum<TEnum>(this string value) where TEnum : struct, Enum
		{
			if (Enum.TryParse(value, true, out TEnum enumValue))
				return enumValue;
			else
				throw new ArgumentException($"Cannot convert '{value}' to enum type {typeof(TEnum).Name}");
		}
	}
}
