using CalcMVVM.Model;

namespace CalcMVVM.ViewModel
{
	public class CalculatorViewModel : ViewModelBase
	{
		private Calculator _calculator;
		private string _result;

		public CalculatorViewModel()
		{
			_calculator = new Calculator();
		}

		public int A
		{
			get => _calculator.A;
			set
			{
				_calculator.A = value;
				//Calc();
			}
		}

		public int B
		{
			get => _calculator.B;
			set
			{
				_calculator.B = value;
				//Calc();
			}
		}

		public string Result
		{
			get => _result;
			set
			{
				_result = value;
				OnPropertyChanged(nameof(Result));
			}
		}

		private void Calc()
		{
			Result = _calculator.Add().ToString();
		}

		#region CalcCommand
		private RelayCommand _calcCommand;
		public RelayCommand CalcCommand => _calcCommand ?? (_calcCommand =
			                                new RelayCommand(ExecuteCalcCommand,
				                                CanCalcCommand));
		public void ExecuteCalcCommand(object parameter)
		{
			Calc();
		}

		public bool CanCalcCommand(object parameter) => B!=0;
		#endregion
	}
}