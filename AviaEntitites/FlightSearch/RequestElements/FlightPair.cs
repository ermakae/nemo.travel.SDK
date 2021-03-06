﻿using System;
using System.Runtime.Serialization;

namespace AviaEntities.FlightSearch.RequestElements
{
	/// <summary>
	/// Содержит информацию о запрашиваемом сегменте перелёта
	/// </summary>
	[DataContract(Namespace = "http://nemo-ibe.com/Avia")]
	public class FlightPair : ICloneable
	{
		/// <summary>
		/// Дата и время отправления в формате yyyy-MM-ddTHH:mm:ss
		/// </summary>
		[DataMember(IsRequired = true, Order = 0)]
		public string DepDate { get; set; }

		/// <summary>
		/// Верхняя граница допустимого диапазона времени вылета, нижняя задаётся в DepDate
		/// </summary>
		[DataMember(Order = 1, EmitDefaultValue = false)]
		public string MaxDepatureTime { get; set; }

		/// <summary>
		/// Код аэропорта (города) отправления
		/// </summary>
		[DataMember(IsRequired = true, Order = 2)]
		public string DepAirp { get; set; }

		/// <summary>
		/// Код аэропорта (города) прибытия
		/// </summary>
		[DataMember(IsRequired = true, Order = 3)]
		public string ArrAirp { get; set; }

		/// <summary>
		/// Выполняет полное копирование объекта, реализация интерфейса ICloneable
		/// </summary>
		/// <returns>Результат копирования</returns>
		public object Clone()
		{
			var newFlp = new FlightPair();

			newFlp.DepDate = DepDate;
			newFlp.ArrAirp = ArrAirp;
			newFlp.DepAirp = DepAirp;
			newFlp.MaxDepatureTime = MaxDepatureTime;

			return newFlp;
		}

		/// <summary>
		/// Обёртка над интерфейсным Clone() с приведением результата к нужному типу
		/// </summary>
		/// <returns>Результат копирования, приведённый к типу данного класса</returns>
		public FlightPair FullCopy()
		{
			return (FlightPair)Clone();
		}
	}
}