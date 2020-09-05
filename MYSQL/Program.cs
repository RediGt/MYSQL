using System;
using System.Collections.Generic;
using System.Text;

namespace MYSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Connections con = new Connections();
            //Console.WriteLine(con.Open());
            con.Insert();
            con.Select();
        }
    }
}
