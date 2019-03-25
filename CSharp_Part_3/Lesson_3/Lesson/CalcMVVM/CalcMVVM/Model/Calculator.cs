namespace CalcMVVM.Model
{
	public class Calculator
	{
		public int A { get; set; }
		public int B { get; set; }

		public int Add() => A + B;
		public int Sub() => A - B;
		public int Mul() => A * B;
		public int Del() => A / B;
	}
}