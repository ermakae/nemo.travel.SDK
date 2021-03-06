﻿using GeneralEntities.Constants;
using System.Runtime.Serialization;
using System.Text;

namespace GeneralEntities.PriceContent.PricingDebug
{
	[DataContract(Namespace = "http://nemo-ibe.com/STL")]
	public class RuleData
	{
		[DataMember(Order = 0)]
		public int ID { get; set; }

		[DataMember(Order = 1, EmitDefaultValue = false)]
		public int? Priority { get; set; }

		[DataMember(Order = 2, EmitDefaultValue = false)]
		public string ManualVV { get; set; }

		[DataMember(Order = 3)]
		public string ValCompany { get; set; }

		[DataMember(Order = 4)]
		public string Commission { get; set; }

		[DataMember(Order = 5)]
		public string ComResult { get; set; }

		[DataMember(Order = 6)]
		public string AgencyCommission { get; set; }

		[DataMember(Order = 7)]
		public string Bonus { get; set; }

		[DataMember(Order = 8)]
		public string BonusResult { get; set; }

		[DataMember(Order = 9)]
		public string ChargeExt { get; set; }

		[DataMember(Order = 10)]
		public string Charge { get; set; }

		[DataMember(Order = 11)]
		public string ChargeValue { get; set; }

		[DataMember(Order = 12)]
		public string MinProfit { get; set; }

		[DataMember(Order = 13)]
		public string MinProfitPriority { get; set; }

		[DataMember(Order = 14)]
		public bool MinProfitEnable { get; set; }

		[DataMember(Order = 15)]
		public string Discount { get; set; }

		[DataMember(Order = 16)]
		public string AuthCode { get; set; }

		[DataMember(Order = 17)]
		public string TourCode { get; set; }

		[DataMember(Order = 18)]
		public string AcquiringMode { get; set; }

		[DataMember(Order = 19)]
		public bool? IsAtoticketingDisabled { get; set; }

		[DataMember(Order = 20)]
		public bool BestRule { get; set; }

		[DataMember(Order = 21)]
		public bool Success { get; set; }

		[DataMember(Order = 22)]
		public CheckResultsCollection CheckResults { get; set; }

		public string Dump()
		{
			var logBuilder = new StringBuilder().
				Append(ValCompany).
				Append(';').
				Append(ID).
				Append(';');

			if (IsAtoticketingDisabled.HasValue)
			{
				logBuilder.Append(IsAtoticketingDisabled.Value ? "on" : "off");
			}

			logBuilder.Append(';');

			var checkConstants = FlightPricingCheckName.GetConstList;
			foreach (var checkName in checkConstants)
			{
				CheckInfo checkInfo;
				if (CheckResults.TryGetValue(checkName, out checkInfo))
				{
					logBuilder.Append(checkInfo.Value).Append('\t').Append(checkInfo.Result ? '+' : '-');
				}
				logBuilder.Append(';');
			}

			logBuilder.
				Append(Priority).
				Append(';').
				Append(ManualVV).
				Append(';').
				Append(Commission).
				Append(';').
				Append(ComResult).
				Append(';').
				Append(AgencyCommission).
				Append(';').
				Append(Bonus).
				Append(';').
				Append(BonusResult).
				Append(';').
				Append(Charge).
				Append(';').
				Append(ChargeExt).
				Append(';').
				Append(ChargeValue).
				Append(';').
				Append(MinProfitPriority).
				Append(';').
				Append(MinProfit).
				Append(';').
				Append(Discount).
				Append(';').
				Append(AuthCode).
				Append(';').
				Append(TourCode).
				Append(';').
				Append(Success ? "+" : "-").
				Append(';').
				Append(BestRule ? "+" : "-").
				Append(';');

			return logBuilder.ToString();
		}
	}
}