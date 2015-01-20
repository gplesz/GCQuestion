using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
            var max = 1;

            for (int i = 0; i < max; i++)
            {
                var inherited = new GCInherited(i);

                //if explicit set to null, the finalizer started:
                //inherited = null;
            }
            GC.Collect(2);
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCApproach(-1);
            GC.WaitForFullGCComplete(-1);
            Console.ReadLine();
        }
    }

    class GCInherited : GCBase
    {
        public GCInherited(int nr) : base(nr) { }

        ~GCInherited() { Console.WriteLine("GCInherited finalizer ({0})", this.nr); }
    }

    class GCBase
    {
        public int nr { get; private set; }

        public GCBase(int nr) { this.nr = nr; }

        ~GCBase() { Console.WriteLine("GCBase finalizer"); }
    }
}
