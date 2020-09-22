namespace Faceted_Builder
{
    public class Person
    {
        public string StreetAddress, PostCode, City;

        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, " +
                   $"{nameof(PostCode)}: {PostCode}," +
                   $" {nameof(City)}: {City}," +
                   $" {nameof(CompanyName)}: {CompanyName}," +
                   $" {nameof(Position)}: {Position}," +
                   $" {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }
}