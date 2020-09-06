using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment
{
    public abstract class Tariff                                                // Main parrent class
    {
        public static List<Tariff> allServices = new List<Tariff>();            // List with all services
        protected int additionalService;
        protected abstract string name { get; }                                 // Name of service
        protected abstract bool isComposite();                                  // Check : finite class or not
        protected abstract int itemCount { get; }                               // Value get from extended classes

        public abstract void AddService();                                      // Method allows adding some value to itemCount
        public abstract void RemoveService();                                   // Method allows removing some value from itemCount
        public static void showInfo()                                           // Show all elements of collection (String was overrided in extendet classes)
        {
            Console.WriteLine("ON YOUR ACCAUNT : ");
            foreach(Tariff item in allServices)
            {
                if(!item.isComposite())
                    Console.WriteLine(item);
            }
        }
    }
    public class Minutes : Tariff                                               // Just inhtermediate class. Contains Rouming minutes, 
    {                                                                           // and also one more intermidiate class Minutes inside contry with Minutes in Mesh and  Minutes out Mesh 
        protected override string name => throw new NotImplementedException();

        

        protected override int itemCount => throw new NotImplementedException();

        public override void AddService()
        {
            throw new NotImplementedException();
        }

        public override void RemoveService()
        {
            throw new NotImplementedException();
        }

        protected override bool isComposite()                             // This class is intermediate so set true
        {
            return true;
        }
    }
    public class RoumingMinutes : Minutes                               
    {
        private int rMinutes = 20;                                        // Base value of rouming minutes
        protected override int itemCount => rMinutes;                     // Send value to parrent class (Tariff)
        protected override string name => "Minutes in rouming";           // Send value to parrent class (Tariff)

        public override void AddService()                                 // Method from parrent class, alows adding 10 rouming minutes to rMinutes
        {
            base.additionalService += 10;                                 // We took varriable from parrent class Tariff
            rMinutes += 10;                                               // Add to our class varriable
            Console.WriteLine($"You added 10 {name}\nYou have {rMinutes} {name} on your accaunt");        // Show operation message
        }

        public override void RemoveService()                              // Removing method
        {
            if (base.additionalService >= 10)                             // We can't remove additional services if we don't have it
            {                                                             // so we check whether we have some additional minutes or not
                base.additionalService -= 10;
                rMinutes -= 10;
                Console.WriteLine($"You removed 10 {name}\nYou have {rMinutes} {name} on your accaunt");
            }
            else
                Console.WriteLine("You dont have additional minutes");
        }
        protected override bool isComposite()                             // Because this class is finite set : false
        {
            return false;
        }
        public override string ToString()                                // ovveride ToString method for more comfortable work
        {
            return $"You have {rMinutes}  {name} on your accaunt.\nOf wich {additionalService} {name} - additional";
        }
    }
    public class MinutesInContry : Minutes                               // Intermediate class, is extended by MinuteInMesh and MinuteOutMesh classes
    {
        protected override bool isComposite()                            // Class - intermediate so set : true
        {
            return true;
        }
        public override string ToString()                               // overrides ToString() for extandables classes
        {
            return $"You have {itemCount}  {name} on your accaunt.\nOf wich {additionalService} {name} - additional";
        }
    }
    public class MinutesInMesh : MinutesInContry                       // Just finite class extends MinuteInContry class. The same functionality as Rouming class 
    {
        private int inMeshMinutes = 500;

        protected override int itemCount => inMeshMinutes;
        protected override string name => "Minutes inside Mesh";

        public override void AddService()
        {
            base.additionalService += 100;
            inMeshMinutes += 100;
            Console.WriteLine($"You added 100 {name}\nYou have {inMeshMinutes} {name} on your accaunt");
        }

        public override void RemoveService()
        {
            if (base.additionalService >= 100)
            {
                base.additionalService -= 100;
                inMeshMinutes -= 100;
                Console.WriteLine($"You removed 100 {name}\nYou have {inMeshMinutes} {name} on your accaunt");
            }
            else
                Console.WriteLine("You dont have additional minutes");
        }
        protected override bool isComposite()
        {
            return false;
        }

    }
    public class MinutesOutMesh : MinutesInContry          // Just finite class extends MinuteInContry class. The same functionality as Rouming class
    {
        private int outMeshMinutes = 250;
        protected override int itemCount => outMeshMinutes;
        protected override string name => "Minutes outside Mesh";

        public override void AddService()
        {
            base.additionalService += 100;
            outMeshMinutes += 100;
            Console.WriteLine($"You added 100 {name}\nYou have {outMeshMinutes} {name} on your accaunt");
        }

        public override void RemoveService()
        {
            if (base.additionalService >= 100)
            {
                base.additionalService -= 100;
                outMeshMinutes -= 100;
                Console.WriteLine($"You removed 100 {name}\nYou have {outMeshMinutes} {name} on your accaunt");
            }
            else
                Console.WriteLine("You dont have additional minutes");
        }
        protected override bool isComposite()
        {
            return false;
        }
    }
    public class Sms : Tariff      // Just finite class extends Tariff class. The same functionality as Rouming class
    {
        private int sms = 50;
        protected override int itemCount => sms;
        protected override string name => "SMS";

        public override void AddService()
        {
            base.additionalService += 50;
            sms += 50;
            Console.WriteLine($"You added 50 {name}\nYou have {sms} {name} on your accaunt");
        }

        public override void RemoveService()
        {
            if (base.additionalService >= 50)
            {
                base.additionalService -= 50;
                sms -= 50;
                Console.WriteLine($"You removed 50 {name}\nYou have {sms} {name} on your accaunt");
            }
            else
                Console.WriteLine("You dont have additional sms");
        }
        protected override bool isComposite()
        {
            return false;
        }
        public override string ToString()
        {
            return $"You have {itemCount}  {name} on your accaunt.\nOf wich {additionalService} {name} - additional";
        }
    }
    public class Internet : Tariff        // Just finite class extends Tariff class. The same functionality as Rouming class
    {
        private int mb = 1500;
        protected override int itemCount => mb;
        protected override string name => "Mb";

        public override void AddService()
        {
            base.additionalService += 500;
            mb += 500;
            Console.WriteLine($"You added 500 Mb\nYou have {mb} {name} on your accaunt");
        }

        public override void RemoveService()
        {
            if (base.additionalService >= 500)
            {
                base.additionalService -= 500;
                mb -= 500;
                Console.WriteLine($"You removed 500 {name}\nYou have {mb} {name} on your accaunt");
            }
            else
                Console.WriteLine("You dont have additional Mb");
        }
        protected override bool isComposite()
        {
            return false;
        }
        public override string ToString()
        {
            return $"You have {itemCount}  {name} on your accaunt.\nOf wich {additionalService} {name} - additional";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Minutes minutes = new Minutes();                                // creating objects
            MinutesInContry minutesInContry = new MinutesInContry();
            Minutes roumingMinutes = new RoumingMinutes();
            MinutesInContry minutesInMesh = new MinutesInMesh();
            MinutesInContry minutesOutMesh = new MinutesOutMesh();
            Sms sms = new Sms();
            Internet internet = new Internet();
            Tariff.allServices.Add(internet);                              // adding to static massive in Tariffe class
            Tariff.allServices.Add(minutes);
            Tariff.allServices.Add(minutesInContry);
            Tariff.allServices.Add(sms);
            Tariff.allServices.Add(minutesInMesh);
            Tariff.allServices.Add(roumingMinutes);
            Tariff.allServices.Add(minutesOutMesh);
            showUserInterface();                                           // run user interface
        }
        static void showUserInterface()            // Method for manage user interface
        {
            string choose = "";
            while (true)
            {
                Tariff.showInfo();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("If you want to ADD additioanal service to your accaunt press : \"1\"");
                Console.WriteLine("If you want to REMOVE additioanal service from your accaunt press : \"2\"");
                Console.WriteLine("If you want to EXIT press : \"0\"");
                choose = Console.ReadLine();
                if (choose == "1")
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("ADDITION SERVICES MENU");
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("If you want to ADD additional SMS to your accaunt press : \"1\"");
                        Console.WriteLine("If you want to ADD additional MB to your accaunt press : \"2\"");
                        Console.WriteLine("If you want to ADD additional ROUMING MINUTES to your accaunt press : \"3\"");
                        Console.WriteLine("If you want to ADD additional MINUTES INSIDE MESH to your accaunt press : \"4\"");
                        Console.WriteLine("If you want to ADD additional MINUTES OUTSIDE MESH to your accaunt press : \"5\"");
                        Console.WriteLine("To EXIT in the previuos menu press : \"0\"");
                        choose = Console.ReadLine();
                        if (choose == "1")
                        {
                            foreach (Tariff item in Tariff.allServices)
                            {
                                if (item is Sms)
                                {
                                    Console.Clear();
                                    (item as Sms).AddService();
                                    break;
                                }

                            }
                        }
                        else if (choose == "2")
                        {
                            foreach (Tariff item in Tariff.allServices)
                            {
                                if (item is Internet)
                                {
                                    Console.Clear();
                                    (item as Internet).AddService();
                                    break;
                                }

                            }
                        }
                        else if (choose == "3")
                        {
                            foreach (Tariff item in Tariff.allServices)
                            {
                                if (item is RoumingMinutes)
                                {
                                    Console.Clear();
                                    (item as RoumingMinutes).AddService();
                                    break;
                                }

                            }
                        }
                        else if (choose == "4")
                        {
                            foreach (Tariff item in Tariff.allServices)
                            {
                                if (item is MinutesInMesh)
                                {
                                    Console.Clear();
                                    (item as MinutesInMesh).AddService();
                                    break;
                                }

                            }
                        }
                        else if (choose == "5")
                        {
                            foreach (Tariff item in Tariff.allServices)
                            {
                                if (item is MinutesOutMesh)
                                {
                                    Console.Clear();
                                    (item as MinutesOutMesh).AddService();
                                    break;
                                }

                            }
                        }
                        else if (choose == "0")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("-----------------------------------------------------------------");
                            Console.WriteLine("ERROR!!! Invalid value!!!");
                            Console.WriteLine("-----------------------------------------------------------------");
                        }

                    }

                }

                else if (choose == "2")
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("If you want to REMOVE additional SMS from your accaunt press : \"1\"");
                        Console.WriteLine("If you want to REMOVE additional MB from your accaunt press : \"2\"");
                        Console.WriteLine("If you want to REMOVE additional ROUMING MINUTES from your accaunt press : \"3\"");
                        Console.WriteLine("If you want to REMOVE additional MINUTES INSIDE MESH from your accaunt press: \"4\"");
                        Console.WriteLine("If you want to REMOVE additional MINUTES OUTSIDE MESH from your accaunt press: \"5\"");
                        Console.WriteLine("To EXIT in the previuos menu press : \"0\"");
                        choose = Console.ReadLine();
                        if (choose == "1")
                        {
                            foreach (Tariff item in Tariff.allServices)
                            {
                                if (item is Sms)
                                {
                                    Console.Clear();
                                    (item as Sms).RemoveService();
                                }

                            }
                        }
                        else if (choose == "2")
                        {
                            foreach (Tariff item in Tariff.allServices)
                            {
                                if (item is Internet)
                                {
                                    Console.Clear();
                                    (item as Internet).RemoveService();
                                }

                            }
                        }
                        else if (choose == "3")
                        {
                            foreach (Tariff item in Tariff.allServices)
                            {
                                if (item is RoumingMinutes)
                                {
                                    Console.Clear();
                                    (item as RoumingMinutes).RemoveService();
                                }

                            }
                        }
                        else if (choose == "4")
                        {
                            foreach (Tariff item in Tariff.allServices)
                            {
                                if (item is MinutesInMesh)
                                {
                                    Console.Clear();
                                    (item as MinutesInMesh).RemoveService();
                                }

                            }
                        }
                        else if (choose == "5")
                        {
                            foreach (Tariff item in Tariff.allServices)
                            {
                                if (item is MinutesOutMesh)
                                {
                                    Console.Clear();
                                    (item as MinutesOutMesh).RemoveService();
                                }

                            }
                        }
                        else if (choose == "0")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("-----------------------------------------------------------------");
                            Console.WriteLine("ERROR!!! Invalid value!!!");
                            Console.WriteLine("-----------------------------------------------------------------");
                        }
                    }
                    

                }
                else if (choose == "0")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("ERROR!!! Invalid value!!!");
                    Console.WriteLine("-----------------------------------------------------------------");
                }


            }
        }
    }
}
