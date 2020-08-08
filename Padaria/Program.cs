using System;

namespace Padaria
{
    class Program
    {
        static void Main(string[] args)
        {
            IPao manteiga = new ManteigaDecorator(new Pao());
            Console.WriteLine(manteiga.PaoFrances());
        }
    }

    interface IPao
    {
        string PaoFrances();
    }
    class Pao : IPao
    {
        public string PaoFrances()
         => "Pão Frances\n";
    }
    class PaoDecorator : IPao
    {
        private IPao _ipao;
        public PaoDecorator(IPao pao)
        {
            _ipao = pao;
        }
        public virtual string PaoFrances()
         =>_ipao.PaoFrances();
    }

    class ManteigaDecorator : PaoDecorator
    {
        public ManteigaDecorator(IPao pao) : base(pao){}

        public override string PaoFrances()
        {
             var paoFrances = base.PaoFrances();
             paoFrances += "Com manteiga";
             return paoFrances;
        }

    }
}
