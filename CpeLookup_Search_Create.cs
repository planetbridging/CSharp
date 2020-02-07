using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPEMENUCREATE
{
    class CpeMenuCreate
    {
        private static string cpedbloc = @"cpe.txt";
        private HashSet<String> CpeLst;
        public CpeMenuCreate()
        {
            CpeLst = new HashSet<string>();
            Start();
            Save();
        }

        private void Start()
        {
            using (StreamReader file = new StreamReader(cpedbloc))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    if (ln.Contains(","))
                    {
                        foreach (string i in ln.Split(','))
                        {
                            if (!CpeLst.Contains(i))
                            {
                                CpeLst.Add(i);
                            }
                        }
                        
                    }
                    //Console.WriteLine(ln);
                    //counter++;
                }
                file.Close();
            }
        }

        private void Save()
        {
            int count = 0;
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"export.txt", true))
            {
                foreach (string i in CpeLst)
                {
                    file.WriteLine(i);
                    count += 1;
                }                
            }
            Console.WriteLine(count);
        }
    }
}
