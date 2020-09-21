namespace Solid_Principles
{
    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter _printer;
        private IScanner _scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            _printer = printer;
            _scanner = scanner;
        }
        
        // Decorator Pattern
        public void Print(Document document) => _printer.Print(document);
        public void Scan(Document document) => _scanner.Scan(document);
    }
}