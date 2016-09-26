using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BluetoothServer
{
    class ProgramMark
    {
        Dictionary<string, string> programlist = new Dictionary<string, string>();
        string filepaths = @"C:/programMark.txt";
        public ProgramMark()
        {
            
            string data, name, path;
            string[] datatemp;
           
            if (!System.IO.File.Exists(filepaths))
            {
                FileStream fp = File.Create(filepaths);
                fp.Close();
            }
            else
            {
                StreamReader sr = new StreamReader(filepaths);

                while(sr.Peek() >= 0)
                {
                    data = sr.ReadLine();
                    datatemp = data.Split('|');

                    name = datatemp[0];
                    path = datatemp[1];

                    programlist.Add(name, path);
                }

                sr.Close();
            }
        }

        public Dictionary<string, string> returnProgramlist()
        {

            return programlist;
        }

        public bool containProgram(string name)
        {
            bool result = false;

            if (programlist.ContainsKey(name))
            {
                result = true;
            }
            return result;
        }

        public void deleteProgram(string name)
        {
            programlist.Remove(name);

            StreamWriter sw = new StreamWriter(filepaths);
            foreach (KeyValuePair<string, string> kvp in programlist)
            {
                sw.WriteLine(kvp.Key + "|" + kvp.Value);
            }
            
            sw.Close();
        }
        public void saveProgram(string name, string path)
        {
            if (!programlist.ContainsKey(name)) { 
                programlist.Add(name, path);


                using (StreamWriter sw = File.AppendText(filepaths))
                {
                    sw.WriteLine(name + "|" + path);
                    sw.Close();

                }
                
            }
        }
    }
}
