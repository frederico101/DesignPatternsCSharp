using System;

namespace Design
{
    class Program
    {
        static void Main(string[] args)
        {
            //decortor desing pattern
            Ipizza pizzaPequena = new Pizza(); 
            Ipizza pizzaMedia = new Pizza();
            Ipizza ComBordas = new BordasDecorator(pizzaMedia);
            Ipizza cheese = new CheeseDecorator(pizzaPequena);
            Ipizza frango = new FrangoDecorator(cheese);
            Ipizza palmito = new PalmitoDecorator(frango);
            Console.Write(palmito.PizzaPequena());
            Console.WriteLine( cheese.PizzaMedia());
            Console.WriteLine(pizzaMedia.PizzaMedia());
            Console.WriteLine(ComBordas.PizzaMedia());  // como vou saber se é com bordas ou sem ????
        }
    }
    // base interface 
    interface Ipizza
    {
        string PizzaPequena();
        string PizzaMedia();
    }
    //concrete class 
    
    class Pizza : Ipizza
    {
        public string PizzaPequena()
        {
            return "Pizza pequena\n";
        }

        public string PizzaMedia()
        {
            return "Pizza media\n";
        }
    }
    //base decorator class
    class PizzaDecorator : Ipizza
    {
        private Ipizza _pizza;
        public PizzaDecorator(Ipizza pizza)
        {
            _pizza = pizza;
        }
        public virtual string PizzaPequena()
        {
           return _pizza.PizzaPequena();
        }
        public virtual string PizzaMedia()
        {
             return _pizza.PizzaMedia();
        }

    }
    //derived decorator class 
    
     class BordasDecorator : PizzaDecorator
    {
        public BordasDecorator(Ipizza pizza): base(pizza){}

        public override string PizzaPequena()
        {
            string type = base.PizzaPequena();
            type += " Com bordas\n";
            return type;
        }
        public override string PizzaMedia()
        {
            string type = base.PizzaMedia();
            type += " Com bordas";
            return type;
        }

        
    }


    class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(Ipizza pizza): base(pizza){}

        public override string PizzaPequena()
        {
            string type = base.PizzaPequena();
            type += " Com queijo extra\n";
            return type;
        }
        public override string PizzaMedia()
        {
            string type = base.PizzaMedia();
            type += " Com queijo extra e bordas";
            return type;
        }

        
    }

    class FrangoDecorator : PizzaDecorator
    {
        public FrangoDecorator(Ipizza pizza): base(pizza){}

         public override string PizzaPequena()
        {
            string type = base.PizzaPequena();
            type += " Com Frango extra\n";
            return type;
        }
        
    }
     class PalmitoDecorator : PizzaDecorator
    {
        public PalmitoDecorator(Ipizza pizza): base(pizza){}

         public override string PizzaPequena()
        {
            string type = base.PizzaPequena();
            type += " Com Palmito extra\n";
            return type;
        }
        
    }
    
}
