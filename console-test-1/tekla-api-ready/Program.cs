using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace tekla_api_ready
{
    class Program
    {
        static int Main(string[] args)
        {
            
            //return 0;

            Model teklaModel = new Model();
            //if (teklaModel.GetConnectionStatus())
            if (true)
            {
                ModelHandler teklaModelHandler = new ModelHandler();
                teklaModelHandler.Open("c:\\TeklaStructuresModels\\Новая модель");
                ModelInfo info = teklaModel.GetInfo();
                Console.WriteLine($"ModelName: {info.ModelName}");
                Console.WriteLine($"ModelPath: {info.ModelPath}");
                return 0;
            }
            else
                return 1;
        }
    }
}
