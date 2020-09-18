Imports System.Globalization

Public Class EnumRadioConverter
	Implements IValueConverter

	Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
		Return value?.Equals(parameter)
	End Function

	Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
		Return If(value?.Equals(True) = True, parameter, Binding.DoNothing)
	End Function

End Class