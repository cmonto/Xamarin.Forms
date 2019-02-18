﻿namespace Xamarin.Forms.Core.Design
{
	using System.Collections.Generic;
	using System.Linq;
	using System.ComponentModel;
	using System;

	public class DerivedTypesConverter<T> : TypeConverter
	{
		public DerivedTypesConverter()
		{
		}

		protected StandardValuesCollection Values
		{
			get;
			set;
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			// This tells XAML this converter can be used to process strings
			// Without this the values won't show up as hints
			if (sourceType == typeof(string))
				return true;

			return base.CanConvertFrom(context, sourceType);
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			if(Values == null)
			{
				var derivedNames = new List<string>();
				var baseType = typeof(T);

				var typeElements = typeof(View).Assembly.ExportedTypes.Where(t => baseType.IsAssignableFrom(t));

				foreach (var typeElement in typeElements)
					if (typeElement.Name != baseType.Name)
						derivedNames.Add(typeElement.Name);

				Values = new StandardValuesCollection(derivedNames);
			}

			return Values;
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return false;
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}