using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace FirstFloor.ModernUI.Windows.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumToStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Enum.Parse(targetType, value.ToString(), true);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PassThruConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ObjectToBoolConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetTypeConverter : MarkupExtension, IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            return value.GetType();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AdditionConverter : MarkupExtension, IValueConverter
    {
        #region Shift

        double _shift;

        /// <summary>
        /// 
        /// </summary>
        public double Shift
        {
            get { return _shift; }
            set { _shift = value; }
        }

        #endregion

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var val = value as Double?;
                if (val == null)
                {
                    val = value as Int32?;
                }
                return val + Shift;
            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var val = value as Double?;
                if (val == null)
                {
                    val = value as Int32?;
                }
                return val - Shift;
            }
            catch
            {
                return value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MultiplicationConverter : MarkupExtension, IValueConverter
    {
        #region Shift

        double _shift;

        /// <summary>
        /// 
        /// </summary>
        public double Factor
        {
            get { return _shift; }
            set { _shift = value; }
        }

        #endregion

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var val = value as Double?;
                if (val == null)
                {
                    val = value as Int32?;
                }
                return val * Factor;
            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var val = value as Double?;
                if (val == null)
                {
                    val = value as Int32?;
                }
                return val / Factor;
            }
            catch
            {
                return value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class BoolToNumberConverter : MarkupExtension, IValueConverter
    {
        #region FalseValue

        /// <summary>
        /// 
        /// </summary>
        public double FalseValue { get; set; }

        #endregion

        #region TrueValue

        /// <summary>
        /// 
        /// </summary>
        public BoolToNumberConverter()
        {
            TrueValue = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public double TrueValue { get; set; }

        #endregion

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return (((bool?)value).Value) ? TrueValue : FalseValue;
            }
            catch
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class BoolNegateConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return (!((bool?)value).Value);
            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return (!((bool?)value).Value);
            }
            catch
            {
                return value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class MaxValueConverter : MarkupExtension, IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double maxVal = Double.MinValue;
            try
            {
                foreach (var term in values)
                {
                    var val = term as Double?;
                    if (val == null)
                    {
                        val = term as Int32?;
                        if (val != null) maxVal = Math.Max(maxVal, val.Value);
                    }
                    else
                    {
                        maxVal = Math.Max(maxVal, val.Value);
                    }
                }
            }
            catch (Exception)
            {
                return maxVal;
            }
            return maxVal;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("");
        }

        #endregion

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
