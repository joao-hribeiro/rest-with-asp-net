namespace ParamnsAndExceptionHandle.Services
{
    public class MathService
    {
        public decimal Sum(decimal a, decimal b) => a + b;
        public decimal Sub(decimal a, decimal b) => a - b;
        public decimal Multiply(decimal a, decimal b) => a * b;
        public decimal Div(decimal a, decimal b)
        {
            if (b == 0) throw new DivideByZeroException("Can't divide by zero!");
            return a / b;
        }
        public decimal Pow(decimal a, decimal b) => (decimal)Math.Pow((double)a, (double)b);
        public decimal Root(decimal a, decimal b)
        {
            if(b == 0)
            {
                throw new ArgumentOutOfRangeException("Cant be zero!");
            }
            return (decimal)System.Math.Pow((double)a, (double)b);
        }           
        public decimal Mean(decimal a, decimal b) => (a + b) / 2;

    }
}
