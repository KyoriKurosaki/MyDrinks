using MyDrinks.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyDrinks.Controller
{
    internal class RecordController
    {
        public List<Record> Records { get; set; }
        private string _path;
        public RecordController(string path)
        {
            _path = path;
            Records = RunRecord();
        }
        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<Record> RunRecord()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    List<Record> rec = formatter.Deserialize(fs) as List<Record>;
                    fs.Close();
                    if (rec != null)
                        return rec;
                    else
                        return new List<Record>();
                }
            }
            catch (SerializationException ex)
            {
                return new List<Record>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SaveRecordFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Records);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void add(string NameOfDrink, string TypeOfDrink)
        {
            Records.Add(new Record(NameOfDrink, TypeOfDrink));
            try
            {
                SaveRecordFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
