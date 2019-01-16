using System;
using SimpleInjector;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            U04uzGEntities entities = new U04uzGEntities();

            if(entities.users.Count() == 0)
            {
                user initUser = new user();
                initUser.userName = "test";
                initUser.password = "test";
                initUser.userId = 1;
                initUser.lastUpdate = DateTime.Now;
                initUser.lastUpdatedBy = "test";
                initUser.active = 1;
                initUser.createBy = "test";
                initUser.createDate = DateTime.Now;

                entities.users.Add(initUser);
                entities.SaveChanges();
            }

            user myUser = entities.users.FirstOrDefault(user => user.userName.Equals("test"));
            Console.WriteLine(myUser);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Bootstrap()
        {
            //container = new Container();
            //container.Register<InventoryInterface, Inventory>(Lifestyle.Singleton);
            //container.Register<IFormManager, FormManager>();

        }
    }
}
