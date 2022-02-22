using System;

namespace _04_Array_Diskussion
{
    class Program
    {
        static string[] Phus = new string[101]; // P-rutans nummer = indexet
                                                // (vi ställer inget i ruta nummer 0)

        static void Initialize()
        {
            for (int i = 1; i < Phus.Length; i++)
            {
                Phus[i] = "";
            }

            // Sätt upp litet testdata
            Phus[1] = "C#ABC123";   // Bil med regnummer ABC123
            Phus[3] = "C#CAR002";
            Phus[4] = "M#MC001";
            Phus[7] = "M#MC002|M#MC003";
            Phus[9] = "M#SYP305";
        }
        static void Main(string[] args)
        {
            Initialize();

            int pRuta;

            if (Search("CAR002", out pRuta))
            {
                Console.WriteLine("Regnummer {0} finns på plats {1}", "CAR002", pRuta);
            }
            else
            {
                Console.WriteLine("Regnumret finns inte");
            }
            if (Search('C', out pRuta))
            {
                Console.WriteLine("Du kan parkera en bil på plats {0}", pRuta);
                Phus[pRuta] = "C#CCC654";
            }
            if (Search('M', out pRuta))
            {
                Console.WriteLine("Du kan parkera en MC på plats {0}", pRuta);
                if (Phus[pRuta].Length == 0)
                {
                    Phus[pRuta] = "M#KLM987";
                }
                else
                {
                    // Ställ dit en MC till
                    Phus[pRuta] += ("|" + "M#JHG750");
                }
            }
            if (CheckSpace('M', 9))
            {
                Console.WriteLine("Det ryms en MC på plats 9");
            }
            else
            {
                Console.WriteLine("Det ryms INTE en MC på plats 9");
            }
            RemoveVehicle("CAR002");
            RemoveVehicle("SYP305");
            RemoveVehicle("MC002");



            Console.ReadKey();
        }

        public static bool Search(string regNummer, out int platsNummer)
        {
            for (int i = 1; i < Phus.Length; i++)
            {
                // Se om vårt regnummer finns i ruta nummer i
                if (Phus[i]?.IndexOf(regNummer) > 0)   // "?" kollar om null
                {
                    platsNummer = i;
                    return true;
                }
            }
            // Vi har sökt igenom hela Phuset, men regnumret fanna ingenstans
            platsNummer = -1;
            return false;
        }
        public static bool Search(char vehicleType, out int platsNummer)
        {
            // Leta reda på första p-rutan som har plats till ett fordon av given typ
            for (int i = 1; i < Phus.Length; i++)
            {
                if (Phus[i] == null || Phus[i] == "")    // Rutan är tom. Alla fordonstyper ryms
                {
                    platsNummer = i;
                    return true;
                }
                else                       // Det finns något där. Kolla vad det är och vad vi vill ställa in
                {
                    if (vehicleType == 'M')
                    {
                        // En ruta med EN MC ser ut som "M#ABC222"
                        // En ruta med TVÅ MC ser ut som "M#ABC222|M#KLM987"
                        // Det vill säga: vi kollar om det finns "M#" men inte "|"
                        if (Phus[i].IndexOf("M#") >= 0)
                        {
                            if (!Phus[i].Contains("|"))
                            {
                                // Ställ MCn här
                                platsNummer = i;
                                return true;
                            }
                        }
                    }
                }
            }
            // Om vi kommer hit, har vi sökt igenom hela P-huset förgäves.
            platsNummer = -1;
            return false;
        }
        public static bool CheckSpace(char vehicleType, int platsNummer)
        {
            string pPlats = Phus[platsNummer];

            // Kolla om ett fordon av goven typ ryms i en given p-plats
            if (pPlats == "")
            {
                return true;
            }
            if (pPlats.Contains("M#") && !pPlats.Contains("|") && vehicleType == 'M')
            {
                return true;
            }
            return false;
        }
        public static bool ParkVehicle(char vehicleType, string regNummer, int platsNummer)
        {
            if (!CheckSpace(vehicleType, platsNummer))
            {
                return false;
            }

            if (vehicleType == 'C')
            {
                Phus[platsNummer] = vehicleType + "#" + regNummer;
            }
            if (vehicleType == 'M')
            {
                if (Phus[platsNummer] == "")
                {
                    Phus[platsNummer] = vehicleType + "#" + regNummer;
                }
                else
                {
                    Phus[platsNummer] += "|" + vehicleType + "#" + regNummer;
                }
            }

            return true;
        }
        public static void RemoveVehicle(string regNummer)
        {
            int platsNummer;
            if (Search(regNummer, out platsNummer))
            {
                if (Phus[platsNummer].StartsWith("C#"))
                {
                    Phus[platsNummer] = "";
                }
                else if (Phus[platsNummer].StartsWith("M#"))
                {
                    if (Phus[platsNummer].Contains("|"))
                    {
                        string mc = "M#" + regNummer;
                        string pPlats = Phus[platsNummer];
                        string[] mcs = pPlats.Split('|');
                        for (int i = 0; i < mcs.Length - 1; i++)
                        {
                            if (mcs[i] == mc)
                            {
                                mcs[i] = "";
                            }
                        }
                        pPlats = mcs[0] + mcs[1];
                        Phus[platsNummer] = pPlats;
                    }
                    else
                    {
                        Phus[platsNummer] = "";
                    }
                }

                return;
            }
        }
        public static bool RemoveVehicle(int platsNummer)
        {
            if (!Phus[platsNummer].Contains("|"))
            {
                Phus[platsNummer] = "";
                return true;
            }

            return false;
        }
    }
}
