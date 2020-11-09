using BoardOrder.Domain.Models;
using BoardOrder.Common.Interfaces;
using GalaSoft.MvvmLight;
using System;

namespace BoardOrder.ViewModel {
	public class CostsSummaryItemViewModel : ViewModelBase, ICostSummaryItem {
		private int boardsQuantity;
		private BoardOrderItem item;
		private double totalCost;
		private double totalTime;

		public BoardOrderItem Item {
			get => this.item;
			set {
				this.Set(nameof(this.Item), ref this.item, value);
				RaisePropertyChanged(nameof(this.PercentageTime));
				RaisePropertyChanged(nameof(this.PercentageCost));
			}
		}

		public int BoardsQuantity {
			get => this.boardsQuantity;
			set {
				this.Set(nameof(this.BoardsQuantity), ref this.boardsQuantity, value);
				RaisePropertyChanged(nameof(this.PercentageTime));
				RaisePropertyChanged(nameof(this.PercentageCost));
			}
		}

		public double TotalTime {
			get => this.totalTime;
			set {
				this.Set(nameof(this.TotalTime), ref this.totalTime, value);
				RaisePropertyChanged(nameof(this.PercentageTime));
			}
		}

		public double TotalCost {
			get => this.boardsQuantity;
			set {
				this.Set(nameof(this.TotalCost), ref this.totalCost, value);
				RaisePropertyChanged(nameof(this.PercentageCost));
			}
		}

		public double PercentageTime => this.TotalTime > 0 ? (this.Item?.WorkdaysModifier * this.BoardsQuantity / this.totalTime) * 100 ?? 0 : 0;

		public double PercentageCost => this.TotalCost > 0 ? (this.Item?.CostModifier * this.BoardsQuantity / this.totalCost) * 100 ?? 0 : 0;

		public double CumulatedCost => Math.Round(this.Item?.CostModifier * this.BoardsQuantity ?? 0);

		public int CumulatedTime => (int)(Math.Round(this.Item?.WorkdaysModifier * this.BoardsQuantity ?? 0));
	}
}
