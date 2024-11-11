using System;

namespace DecoratorPattern
{
    // "Component"
    abstract class ChristmasTree
    {
        public abstract void Decorate();
    }

    // "ConcreteComponent"
    class BasicChristmasTree : ChristmasTree
    {
        public override void Decorate()
        {
            Console.WriteLine("Decorating the basic Christmas tree.");
        }
    }

    // "Decorator"
    abstract class ChristmasTreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public ChristmasTreeDecorator(ChristmasTree tree)
        {
            this.tree = tree;
        }

        public override void Decorate()
        {
            tree.Decorate();
        }
    }

    // "ConcreteDecorator" for ornaments
    class WithOrnaments : ChristmasTreeDecorator
    {
        public WithOrnaments(ChristmasTree tree) : base(tree) { }

        public override void Decorate()
        {
            base.Decorate();
            AddOrnaments();
        }

        private void AddOrnaments()
        {
            Console.WriteLine("Adding ornaments to the Christmas tree.");
        }
    }

    // "ConcreteDecorator" for lights
    class WithLights : ChristmasTreeDecorator
    {
        public WithLights(ChristmasTree tree) : base(tree) { }

        public override void Decorate()
        {
            base.Decorate();
            AddLights();
        }

        private void AddLights()
        {
            Console.WriteLine("Adding lights to the Christmas tree.");
        }
    }

    // "ConcreteDecorator" for both ornaments and lights
    class WithOrnamentsAndLights : ChristmasTreeDecorator
    {
        public WithOrnamentsAndLights(ChristmasTree tree) : base(tree) { }

        public override void Decorate()
        {
            base.Decorate();
            AddOrnaments();
            AddLights();
        }

        private void AddOrnaments()
        {
            Console.WriteLine("Adding ornaments to the Christmas tree.");
        }

        private void AddLights()
        {
            Console.WriteLine("Adding lights to the Christmas tree.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення основної ялинки
            ChristmasTree myTree = new BasicChristmasTree();
            myTree.Decorate();

            // Декорування ялинки прикрасами
            Console.WriteLine("\nDecorating with ornaments:");
            ChristmasTree treeWithOrnaments = new WithOrnaments(myTree);
            treeWithOrnaments.Decorate();

            // Декорування ялинки прикрасами та гірляндами
            Console.WriteLine("\nDecorating with ornaments and lights:");
            ChristmasTree treeWithOrnamentsAndLights = new WithOrnamentsAndLights(myTree);
            treeWithOrnamentsAndLights.Decorate();

            // Декорування ялинки тільки гірляндами
            Console.WriteLine("\nDecorating with lights only:");
            ChristmasTree treeWithLights = new WithLights(myTree);
            treeWithLights.Decorate();

            Console.ReadKey();
        }
    }
}
