using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidator
{
    public class DataValid<T>
    {
		public T Data { get; set; }
		public string DisplayName { get; set; }
		public DataValid(T data, string displayName)
		{
			Data = data;
			DisplayName = displayName;
 		}

		/// <summary>
		/// 文字必填
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValid<T> StringRequired()
		{
			if(typeof(T) == typeof(string))
			{
				string value = Convert.ToString(Data);
				if (string.IsNullOrEmpty(value)) throw new Exception($"{DisplayName}必填");
			}
			
			return this;
		}

		/// <summary>
		/// 文字長度限制必須小於等於maxValue
		/// </summary>
		/// <param name="maxValue">要小於等於多少文字長度</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValid<T> StringLengthLessThan(int maxValue)
		{
			if (typeof(T) == typeof(string))
			{
				string value = Convert.ToString(Data);
				if (value.Length > maxValue) throw new Exception($"{DisplayName}超過長度限制");
			}

			return this;
		}

		/// <summary>
		/// 最少要幾個字 要大於minValue
		/// </summary>
		/// <param name="minValue">最少字數</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValid<T> StringLengthGreaterThan(int minValue)
		{
			if (typeof(T) == typeof(string))
			{
				string value = Convert.ToString(Data);
				if (value.Length < minValue) throw new Exception($"{DisplayName}小於長度限制");
			}

			return this;
		}

		/// <summary>
		/// 最少要幾個字 要大於等於minValue
		/// </summary>
		/// <param name="minValue">最少字數</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValid<T> StringLengthGreaterOrEqualThan(int minValue)
		{
			if (typeof(T) == typeof(string))
			{
				string value = Convert.ToString(Data);
				if (value.Length <= minValue) throw new Exception($"{DisplayName}小於長度限制");
			}

			return this;
		}

		/// <summary>
		/// 數值必須大於minValue
		/// </summary>
		/// <param name="minValue">需要大於的數</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValid<T> GreaterThan(int minValue)
		{
			if(typeof(T) == typeof(int))
			{
				int value = Convert.ToInt32(Data);
				if (value <= minValue) throw new Exception($"{DisplayName}必須大於{minValue}");
			}

			return this;
		}

		/// <summary>
		/// 數值必須大於等於minValue
		/// </summary>
		/// <param name="minValue">需要大於等於的數</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValid<T> GreaterOrEqualThan(int minValue)
		{
			if (typeof(T) == typeof(int))
			{
				int value = Convert.ToInt32(Data);
				if (value < minValue) throw new Exception($"{DisplayName}必須大於等於{minValue}");
			}

			return this;
		}

		/// <summary>
		/// 某數值必須小於maxValue
		/// </summary>
		/// <param name="maxValue"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValid<T> LessThan(int maxValue)
		{
			if (typeof(T) == typeof(int))
			{
				int value = Convert.ToInt32(Data);
				if (value >= maxValue) throw new Exception($"{DisplayName}必須小於{maxValue}");
			}

			return this;
		}

		/// <summary>
		/// 某數值必須小於等於maxValue
		/// </summary>
		/// <param name="maxValue"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public DataValid<T> LessOrEqualThan(int maxValue)
		{
			if (typeof(T) == typeof(int))
			{
				int value = Convert.ToInt32(Data);
				if (value > maxValue) throw new Exception($"{DisplayName}必須小於等於{maxValue}");
			}

			return this;
		}
	}
}
