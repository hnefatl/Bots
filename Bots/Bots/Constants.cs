using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Bots
{
    public class Constants
    {
        public static bool Load(string File)
        {
            try
            {
                StreamReader Reader = new StreamReader(File);

                while (!Reader.EndOfStream)
                {
                    List<string> Parts = Split(Reader.ReadLine(), ' ');

                    if (Parts.Count != 2)
                    {
                        continue;
                    }

                    switch (Parts[0])
                    {
                        case "Debug:": Debug = Convert.ToBoolean(Parts[1]); break;
                        case "ShowBulletCount:": ShowBulletCount = Convert.ToBoolean(Parts[1]); break;
                    }
                }

                Reader.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }
        protected static List<string> Split(string Input, char Delimiter)
        {
            List<string> Segments = new List<string>();

            string Buffer = string.Empty;
            for (int x = 0; x < Input.Length; x++)
            {
                if (Input[x] == Delimiter)
                {
                    if (Buffer.Length > 0)
                    {
                        Segments.Add(Buffer);
                        Buffer = string.Empty;
                    }
                }
                else
                {
                    Buffer += Input[x];
                }
            }
            if (Buffer.Length > 0)
            {
                Segments.Add(Buffer);
            }

            return Segments;
        }

        public static bool Debug { get; set; }
        public static bool ShowBulletCount { get; set; }
    }
}
