using System;
using System.Linq;
using PowerBIDotNet;

namespace Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var authentication = new Authentication();
            //var tokens = authentication.GetTokens("8a5eb107-97bf-40ea-96c4-5c6a2d10ea9a");
            //var tokens = authentication.GetTokens("563d6944-fa12-43ca-afa7-e40f95357321");



            var workspace = Workspace.GetFor(token);
            
            var dashboards = workspace.Dashboards.GetAll();

            foreach( var dashboard in dashboards )
            {
                var tiles = workspace.Tiles.GetFor(dashboard);

                foreach( var tile in tiles )
                {
                    Console.WriteLine("HEllo");
                }
            }


            /*

            var datasets = workspace.Datasets.GetAll();
            */
            
            var reports = workspace.Reports.GetAll();

            
            //var groups = workspace.Groups.GetAll();

            //workspace.Reports.GetFor
            
            

        }
    }
}
