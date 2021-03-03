using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reader
{
    class DataReader
    {
        StreamReader reader;
        public List<double> DataPregnant()
        {
            
            reader = new StreamReader("preg_data.csv");
            List<double> listPregnant = new List<double>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                listPregnant.Add(Convert.ToDouble(values[0]));
            }
            reader.Close();
            return listPregnant;
        }
        public List<List<double>> Data()
        {
            reader = new StreamReader(@"data.csv");
            List<List<double>> data = new List<List<double>>();

            for (int i = 0; i < 1000; i++)
            {
                data.Add(new List<double>());
            }

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');

                for (int i = 0; i < data.Count; i++)
                {
                    List<double> inner_list = new List<double>();
                    for (int j = 0; j < 20; j++)
                    {
                        inner_list.Add(Convert.ToDouble(values[j]));
                    }
                    data[i] = inner_list;
                }
            }
            reader.Close();

            return data;
        }
    }
}
