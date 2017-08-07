using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GlobalLogicTestTask
{
    class Program
    {
       
        static void Main(string[] args)
        {

             
            List<FileSrtuct> Fileslist = new List<FileSrtuct>();
              string address,address2;
              Console.WriteLine("Enter full address to folder");
              address= Console.ReadLine();
             // address = @"D:\\Games";
            Serialize(address);
           address2= Console.ReadLine();

           // address2 = @"D:\";
            DeSerialDir(address2);

              Console.ReadLine();
        
        }

     static void DeSerialDir(string dirpath)
        {
            List<FileSrtuct> list = new List<FileSrtuct>();
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                try
                {

                    FileSrtuct newFileSrtuct = (FileSrtuct)formatter.Deserialize(fs);


                    if (!Directory.Exists(dirpath))
                    {
                        DirectoryInfo dir = new DirectoryInfo(@"D:\");

                        foreach (var item in list)
                        {
                            System.IO.Directory.CreateDirectory(list.ToString());
                            

                            foreach (var it in list)
                            {
                                System.IO.Directory.CreateDirectory(list.ToString());


                                foreach (var item2 in list)
                                {
                                    File.Create(list.ToString()).Dispose();
                                }
                            }


                        }

                    }

                    
                    Console.WriteLine("DeSerialization done");
                }

                catch
                {
                    Console.WriteLine("Error");
                }

            }
        }

        static void Serialize(string dirpath)
    {
            List<FileSrtuct> list = new List<FileSrtuct>();
            try
            {
                if (!Directory.Exists(dirpath))
                {
                    DirectoryInfo dir = new DirectoryInfo(@"F:\MEDIA");

                    foreach (var item in dir.GetDirectories())
                    {
                        FileSrtuct f = new FileSrtuct(item.Name);
                        list.Add(f);

                        foreach (var it in item.GetDirectories())
                        {
                            FileSrtuct f1 = new FileSrtuct(item.Name);
                            list.Add(f1);


                            foreach (var item2 in dir.GetFiles())
                            {
                                FileSrtuct f2 = new FileSrtuct(item.Name);
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

        }
        }
    [Serializable]
    public class FileSrtuct
    {
        public FileSrtuct(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    
}



