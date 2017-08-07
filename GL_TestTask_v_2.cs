using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GL_TestTask_v_2
{
    class Program
    {
        [Serializable]
        class SerializeTest
        {


            public string Name { get; set; }
            public byte[] ArrData { get; set; }


            public SerializeTest(string name, byte[] arrData)
            {

                Name = name;
               ArrData = arrData;

            }

        }   
           
            static void Main(string[] args)
            {
                string userpath;

            //userpath = @"F:\MEDIA";
            userpath = Console.ReadLine();
         

                List<SerializeTest> list = new List<SerializeTest>();
                try
                {
                    if (!Directory.Exists(@"F:\MEDIA"))
                    {
                        DirectoryInfo dir = new DirectoryInfo(@"F:\MEDIA");

                        foreach (var item in dir.GetDirectories())
                        {
                            SerializeTest f = new SerializeTest( item.Name,  new byte[0]);
                            list.Add(f);

                            foreach (var it in item.GetDirectories())
                            {
                                SerializeTest f1 = new SerializeTest(item.Name,  new byte[0]);
                                list.Add(f1);


                                foreach (var item2 in dir.GetFiles())
                                {
                                    SerializeTest f2 = new SerializeTest( item.Name,  new byte[new System.IO.FileInfo(item.Name).Length]);
                                    list.Add(f2);
                                }
                            }


                        }

                    }
                }

                catch
                {
                    Console.WriteLine("Error creating bat file");
                }

            
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);

                Console.WriteLine("Serialization done");
            }





             Console.WriteLine("\n Reading SerializeTest object from disk\n");
            /* Stream input = File.OpenRead("file.dat");
             BinaryFormatter bread = new BinaryFormatter();
             SerializeTest fromdisk = (SerializeTest)bread.Deserialize(input);
             input.Close();
             */
                
            using (FileStream fs = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                SerializeTest newSerializeTest = (SerializeTest)formatter.Deserialize(fs);
                
            }
                Console.ReadKey();
        }
        }
    }

